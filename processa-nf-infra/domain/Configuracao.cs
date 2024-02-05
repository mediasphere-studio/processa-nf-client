using System.Data;

namespace processa_nf_infra.domain
{
    public class Configuracao
    {
        public int IntervaloRastreamento { get; set; } = 10;
        public string DiretorioTemporario { get; set; } = "";
    }
}
