using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ValidSAT.Classes
{
    public static class Helper
    {
        // No cambies la KEY de encriptacion                    

        /// <summary>
        /// Encripta una cadena de texto
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns>Texto encriptado</returns>
        public static string Encrypt(string cadena)
        {
            string EncryptionKey = "(*&^%$%^&*()(*&^%";
            byte[] clearBytes = Encoding.Unicode.GetBytes(cadena);

            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    cadena = Convert.ToBase64String(ms.ToArray());
                }
            }

            return cadena;
        }

        /// <summary>
        /// Desencripta
        /// </summary>
        /// <param name="cadena">Texto a desecriptar</param>
        /// <returns>Texto desencriptado</returns>
        public static string Decrypt(string cadena)
        {
            string EncryptionKey = "(*&^%$%^&*()(*&^%";
            cadena = cadena.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cadena);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cadena = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cadena;
        }
    }
}
