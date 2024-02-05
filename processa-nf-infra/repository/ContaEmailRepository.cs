using Microsoft.Win32;
using processa_nf_infra.domain;
using processa_nf_infra.utilities;

namespace processa_nf_infra.repository
{
    public class ContaEmailRepository
    {
        const string CHAVE_EMAILS_REGISTRADOS = Constantes.CHAVE_REGISTRO_RAIZ + @"\EmaisRegistrados";

        public static List<ContaEmail> List()
        {
            List<ContaEmail> emails = new();

            RegistryKey? chaveEmailsRegistrados = Registry.LocalMachine.OpenSubKey(CHAVE_EMAILS_REGISTRADOS);

            if (chaveEmailsRegistrados != null)
            {
                string[] emailsRegistrados = chaveEmailsRegistrados.GetSubKeyNames();

                if (emailsRegistrados.Length > 0)
                {
                    foreach(string emailRegistrado in emailsRegistrados) 
                    {
                        RegistryKey? chaveEmailRegistrado = chaveEmailsRegistrados.OpenSubKey(emailRegistrado);

                        if (chaveEmailRegistrado != null) 
                        {
                            ContaEmail contaEmail = new();

                            contaEmail.TipoConta = ObtemValor(chaveEmailRegistrado, "TipoConta") == TipoContaEnum.POP3.ToString() ? TipoContaEnum.POP3 : TipoContaEnum.IMAP;
                            contaEmail.Servidor = ObtemValor(chaveEmailRegistrado, "Servidor");
                            contaEmail.Porta = ObtemValor(chaveEmailRegistrado, "Porta");
                            contaEmail.RequerSsl = ObtemValor(chaveEmailRegistrado, "RequerSsl") == "N" ? false : true;
                            contaEmail.Usuario = ObtemValor(chaveEmailRegistrado, "Usuario");
                            contaEmail.Senha = Utilitarios.Descriptografar(ObtemValor(chaveEmailRegistrado, "Senha"));

                            //contaEmail.Senha = ObtemValor(chaveEmailRegistrado, "Senha");

                            contaEmail.EnderecoAPI = ObtemValor(chaveEmailRegistrado, "EnderecoAPI");
                            contaEmail.CabecalhoAutorizacao = ObtemValor(chaveEmailRegistrado, "CabecalhoAutorizacao");

                            if (DateTime.TryParse(chaveEmailRegistrado.GetValue("DataHoraUltimoProcessamento")?.ToString() ?? "", out DateTime dataHoraUltimoProcessamento))
                                contaEmail.DataHoraUltimoProcessamento = dataHoraUltimoProcessamento;

                            emails.Add(contaEmail);
                        }
                    }
                }
            }

            return emails;
        }

        public static void Save(List<ContaEmail> contasEmail)
        {
            RegistryKey? chaveEmailsRegistrados = Registry.LocalMachine.OpenSubKey(CHAVE_EMAILS_REGISTRADOS);

            if (chaveEmailsRegistrados != null)
            {
                Registry.LocalMachine.DeleteSubKeyTree(CHAVE_EMAILS_REGISTRADOS);
            }

            chaveEmailsRegistrados = Registry.LocalMachine.CreateSubKey(CHAVE_EMAILS_REGISTRADOS);

            int contador = 1;
            foreach(ContaEmail contaEmail in contasEmail)
            {
                RegistryKey chaveEmailRegistrado = chaveEmailsRegistrados.CreateSubKey($"email{contador}");
                chaveEmailRegistrado.SetValue("TipoConta", contaEmail.TipoConta.ToString());
                chaveEmailRegistrado.SetValue("Servidor", contaEmail.Servidor);
                chaveEmailRegistrado.SetValue("Porta", contaEmail.Porta);
                chaveEmailRegistrado.SetValue("RequerSsl", contaEmail.RequerSsl ? "S" : "N");
                chaveEmailRegistrado.SetValue("Usuario", contaEmail.Usuario);
                chaveEmailRegistrado.SetValue("Senha", Utilitarios.Criptografar(contaEmail.Senha));

                //chaveEmailRegistrado.SetValue("Senha", contaEmail.Senha);

                chaveEmailRegistrado.SetValue("EnderecoAPI", contaEmail.EnderecoAPI);
                chaveEmailRegistrado.SetValue("CabecalhoAutorizacao", contaEmail.CabecalhoAutorizacao);

                if (contaEmail.DataHoraUltimoProcessamento.HasValue)
                    chaveEmailRegistrado.SetValue("DataHoraUltimoProcessamento", contaEmail.DataHoraUltimoProcessamento.Value.ToString("dd/MM/yyyy HH:mm:ss"));

                contador++;
            }
        }

        private static string ObtemValor(RegistryKey chave, string valor)
        {
            object? valorObtido = chave.GetValue(valor);
            return valorObtido?.ToString() ?? "";
        }
    }
}
