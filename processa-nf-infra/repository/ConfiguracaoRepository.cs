using Microsoft.Win32;
using processa_nf_infra.domain;

namespace processa_nf_infra.repository
{
    public class ConfiguracaoRepository
    {
        const string CHAVE_CONFIGURACOES = Constantes.CHAVE_REGISTRO_RAIZ + @"\Configuracoes";

        public static Configuracao Get()
        {
            RegistryKey chaveConfiguracoes = Registry.LocalMachine.OpenSubKey(CHAVE_CONFIGURACOES) ?? Registry.LocalMachine.CreateSubKey(CHAVE_CONFIGURACOES);

            Configuracao config = new();

            if (int.TryParse(chaveConfiguracoes.GetValue("IntervaloRastreamento")?.ToString() ?? "10", out int intervalorRastreamento))
                config.IntervaloRastreamento = intervalorRastreamento;
            else
                config.IntervaloRastreamento = 10;

            config.DiretorioTemporario = chaveConfiguracoes.GetValue("DiretorioTemporario")?.ToString() ?? "";

            return config;
        }

        public static void Save(Configuracao config)
        {
            RegistryKey chaveConfiguracoes = Registry.LocalMachine.OpenSubKey(CHAVE_CONFIGURACOES, true) ?? Registry.LocalMachine.CreateSubKey(CHAVE_CONFIGURACOES);
            chaveConfiguracoes.SetValue("IntervaloRastreamento", config.IntervaloRastreamento);
            chaveConfiguracoes.SetValue("DiretorioTemporario", config.DiretorioTemporario);
        }
    }
}
