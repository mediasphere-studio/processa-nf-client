using System.Reflection;

namespace processa_nf_infra.domain
{
    public class ContaEmail
    {
        public TipoContaEnum TipoConta { get; set; } = TipoContaEnum.IMAP;
        public string Servidor { get; set; } = "servidor";
        public string Porta { get; set; } = "porta";
        public bool RequerSsl { get; set; } = true;
        public string Usuario { get; set; } = "usuario";
        public string Senha { get; set; } = "senha";
        public string EnderecoAPI { get; set; } = "";
        public string CabecalhoAutorizacao { get; set; } = "";
        public DateTimeOffset? DataHoraUltimoProcessamento { get; set; }

        public void CopyFrom(ContaEmail outraConta)
        {
            PropertyInfo[] props = typeof(ContaEmail).GetProperties();
            foreach(PropertyInfo pi in props) 
                pi.SetValue(this, pi.GetValue(outraConta));
        }
        public ContaEmail Clone()
        {
            ContaEmail clone = new();

            PropertyInfo[] props = typeof(ContaEmail).GetProperties();
            foreach (PropertyInfo pi in props)
                pi.SetValue(clone, pi.GetValue(this));

            return clone;
        }
    }
}
