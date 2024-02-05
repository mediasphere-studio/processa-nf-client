using System.Security.Cryptography;
using System.Text;

namespace processa_nf_infra.utilities
{
    public static class Utilitarios
    {
        private const string ENTROPIA = "@embaralharasenha#"; 

        public static string Criptografar(string entrada)
        {
            byte[] bytesEntropia = Encoding.UTF8.GetBytes(ENTROPIA);
            byte[] bytesEntrada = Encoding.UTF8.GetBytes(entrada);
            byte[] bytesCriptografados = new byte[bytesEntrada.Length];

            for (int i = 0; i < bytesEntrada.Length; i++)
            {
                bytesCriptografados[i] = (byte)(bytesEntrada[i] ^ bytesEntropia[i % bytesEntropia.Length]);
            }

            return Convert.ToBase64String(bytesCriptografados);
        }

        public static string Descriptografar(string entrada)
        {
            byte[] bytesEntropia = Encoding.UTF8.GetBytes(ENTROPIA);
            byte[] bytesCriptografados = Convert.FromBase64String(entrada);
            byte[] bytesSaida = new byte[bytesCriptografados.Length];

            for (int i = 0; i < bytesCriptografados.Length; i++)
            {
                bytesSaida[i] = (byte)(bytesCriptografados[i] ^ bytesEntropia[i % bytesEntropia.Length]);
            }

            return Encoding.UTF8.GetString(bytesSaida);
        }
    }
}
