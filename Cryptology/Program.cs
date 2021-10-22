using System;

namespace Cryptology
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            RSAEncryption rsa = new RSAEncryption();
            Console.WriteLine("Enter the message you want to be encrypted");
            string plainText = Console.ReadLine();
            AESEncryption.EncryptAesManaged(plainText);
            RSAEncryption.EncryptRsaManaged(plainText);
        }
    }
}
