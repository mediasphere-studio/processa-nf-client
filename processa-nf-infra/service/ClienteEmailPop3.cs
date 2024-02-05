using MailKit;
using MailKit.Net.Imap;
using MailKit.Net.Pop3;
using MimeKit;
using processa_nf_infra.domain;

namespace processa_nf_infra.service
{
    public class ClienteEmailPop3: IClienteEmail
    {
        private readonly Pop3Client _emailClient;

        public ClienteEmailPop3()
        {
            this._emailClient = new Pop3Client();
        }

        public void Connect(ContaEmail contaEmail)
        {
            _emailClient.Connect(contaEmail.Servidor, Convert.ToInt32(contaEmail.Porta), contaEmail.RequerSsl);
            _emailClient.Authenticate(contaEmail.Usuario, contaEmail.Senha);
        }

        public MimeMessage GetMessage(int id)
        {
            if (!_emailClient.IsConnected || !_emailClient.IsAuthenticated)
                throw new Exception("Conta de email não aberta ou não autenticada");

            if (id < 0 || id > _emailClient.Count - 1)
                throw new ArgumentException("id da mensagem é inválido");

            return _emailClient.GetMessage(id);
        }

        public int GetMessageCount()
        {
            return _emailClient?.Count ?? 0;
        }

        public void Disconnect()
        {
            _emailClient.Disconnect(true);
        }

        public void Dispose()
        {
            _emailClient.Dispose();
        }
    }
}
