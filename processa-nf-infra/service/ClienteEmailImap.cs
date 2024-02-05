using MailKit;
using MailKit.Net.Imap;
using MimeKit;
using processa_nf_infra.domain;

namespace processa_nf_infra.service
{
    public class ClienteEmailImap : IClienteEmail
    {
        private readonly ImapClient _emailClient;
        private IMailFolder? _inbox;

        public ClienteEmailImap()
        {
            _emailClient = new ImapClient();
        }

        public void Connect(ContaEmail contaEmail)
        {
            _emailClient.Connect(contaEmail.Servidor, Convert.ToInt32(contaEmail.Porta), contaEmail.RequerSsl);
            _emailClient.Authenticate(contaEmail.Usuario, contaEmail.Senha);

            _inbox = _emailClient.Inbox;
            _inbox.Open(FolderAccess.ReadOnly);
        }

        public MimeMessage GetMessage(int id)
        {
            if (!_emailClient.IsConnected || !_emailClient.IsAuthenticated)
                throw new Exception("Conta de email não aberta ou não autenticada");

            if (_inbox == null)
                throw new Exception("Pasta inbox não aberta");

            if (id < 0 || id > _inbox.Count - 1)
                throw new ArgumentException("id da mensagem é inválido");

            return _inbox.GetMessage(id);
        }

        public int GetMessageCount()
        {
            return _inbox?.Count ?? 0;
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
