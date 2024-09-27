using System.Security.Cryptography;
using System.Text;

namespace Projeto.Mundial.Domain.Extensions
{
    public static class Criptografia
    {
        public static string Criptografar(this string texto)
        {
            string chave = "minhachave123456";

            byte[] chaveBytes = Encoding.UTF8.GetBytes(chave);
            byte[] iv = new byte[16]; // Vetor de inicialização com 16 bytes (padrão para AES)

            using (Aes aes = Aes.Create())
            {
                aes.Key = chaveBytes;
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(texto);
                        }

                        byte[] encrypted = ms.ToArray();
                        return Convert.ToBase64String(encrypted);
                    }
                }
            }
        }

        public static string Descriptografar(this string textoCriptografado)
        {
            string chave = "minhachave123456";

            byte[] chaveBytes = Encoding.UTF8.GetBytes(chave);
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(textoCriptografado);

            using (Aes aes = Aes.Create())
            {
                aes.Key = chaveBytes;
                aes.IV = iv;

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream(buffer))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
