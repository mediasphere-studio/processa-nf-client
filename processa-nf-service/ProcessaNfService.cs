using MailKit;
using MailKit.Net.Imap;
using MimeKit;
using processa_nf_infra.domain;
using processa_nf_infra.repository;
using processa_nf_infra.service;
using System.Net.Http.Headers;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace processa_nf_service
{
    public sealed class ProcessaNfService
    {
        public async Task Execute()
        {
            List<ContaEmail> contasEmail = ContaEmailRepository.List();

            if (contasEmail.Count > 0)
            {
                foreach (ContaEmail contaEmail in contasEmail)
                {
                    await RastrearMensagensComAnexoPDF(contaEmail);
                    contaEmail.DataHoraUltimoProcessamento = DateTimeOffset.Now;
                }
                ContaEmailRepository.Save(contasEmail);
            }
        }

        private async Task RastrearMensagensComAnexoPDF(ContaEmail contaEmail)
        {
            using IClienteEmail client = (contaEmail.TipoConta == TipoContaEnum.IMAP ? new ClienteEmailImap() : new ClienteEmailPop3());

            try
            {
                client.Connect(contaEmail);
            }
            catch (Exception ex)
            {
                throw new Exception($"senha: {contaEmail.Senha} - Exceção: {ex.Message}");
            }

            int messageCount = client.GetMessageCount();

            for (int i = 0; i < messageCount; i++)
            {
                var message = client.GetMessage(i);
                if (message.Date >= (contaEmail.DataHoraUltimoProcessamento.HasValue ? contaEmail.DataHoraUltimoProcessamento : DateTimeOffset.MinValue))
                {
                    foreach (var attachment in message.Attachments)
                    {
                        if (attachment is MimePart mimePart)
                        {
                            if (mimePart.ContentType.MediaType.Equals("application") && mimePart.ContentType.MediaSubtype.Equals("pdf"))
                            {
                                string retornoAPI = await ProcessaRequisicaoAPI(message, mimePart);

                                retornoAPI = retornoAPI
                                    .Replace("\"origem\":null,", $"\"origem\":\"{contaEmail.Usuario}\",")
                                    .Replace("\"dataRecebimento\":null,", $"\"dataRecebimento\":\"{message.Date.LocalDateTime:O}\",");

                                if (!string.IsNullOrEmpty(contaEmail.EnderecoAPI))
                                    await ProcessaCallback(contaEmail, retornoAPI);
                            }
                        }
                    }
                }
            }
            client.Disconnect();
        }

        private async Task<string> ProcessaRequisicaoAPI(MimeMessage message, MimePart attachment)
        {
            string apiUrl = "https://app-processa-nf-servico.azurewebsites.net/api/ProcessaNotaFiscalServico";

            using var client = new HttpClient();

            byte[] attachmentBytes;
            using var memoryStream = new MemoryStream();
            attachment.Content.DecodeTo(memoryStream);
            attachmentBytes = memoryStream.ToArray();

            var content = new StreamContent(new MemoryStream(attachmentBytes));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");

            var response = await client.PostAsync(apiUrl, content);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }

        private async Task ProcessaCallback(ContaEmail contaEmail, string retornoAPI)
        {
            using var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, contaEmail.EnderecoAPI);

            if (!string.IsNullOrEmpty(contaEmail.CabecalhoAutorizacao))
            {
                request.Headers.Add("Authorization", contaEmail.CabecalhoAutorizacao);
            }

            var content = new StringContent(retornoAPI, null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }

    }
}
