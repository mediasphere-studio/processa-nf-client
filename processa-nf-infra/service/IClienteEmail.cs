using MimeKit;
using processa_nf_infra.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace processa_nf_infra.service
{
    public interface IClienteEmail : IDisposable
    {
        public void Connect(ContaEmail contaEmail);
        public void Disconnect();
        public int GetMessageCount();
        public MimeMessage GetMessage(int id);
    }
}
