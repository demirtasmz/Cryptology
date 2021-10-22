using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace Cryptology
{
    public class RSAEncryption
    {
        private static RSACryptoServiceProvider csp = new RSACryptoServiceProvider(2048);
        private static RSAParameters _privateKey;
        private static RSAParameters _publicKey;
        public RSAEncryption()
        {
            _publicKey = csp.ExportParameters(false);
            _privateKey = csp.ExportParameters(true);
        }
        public static void EncryptRsaManaged(string raw)
        {
            try
            {
                string encrypted = Encrypt(raw);
                Console.WriteLine("Encrypted data:" + encrypted);
                string decrypted = Decrypt(encrypted);
                Console.WriteLine("Decrypted data:" + decrypted);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            Console.ReadKey();
        }
        string GetPublicKey()
        {
            var sw = new StringWriter();
            var xs = new XmlSerializer(typeof(RSAParameters));
            xs.Serialize(sw, _publicKey);
            return sw.ToString();
        }
        static string Encrypt(string plainText)
        {
            csp = new RSACryptoServiceProvider();
            csp.ImportParameters(_publicKey);
            var data = Encoding.UTF8.GetBytes(plainText);
            var cypher = csp.Encrypt(data, false);
            return Convert.ToBase64String(cypher);
        }
        static string Decrypt(string cypherText)
        {
            var dataBytes = Convert.FromBase64String(cypherText);
            csp.ImportParameters(_privateKey);
            var plaintText = csp.Decrypt(dataBytes, false);
            return Encoding.UTF8.GetString(plaintText);
        }
    }
}
