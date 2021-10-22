using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Cryptology
{
    public class Hashing
    {
        public static void CreateHash(string str, out byte[] strHash)
        {
            using (var hmac = new HMACSHA256())
            {
                strHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(str));
            }
        }

        public static bool VerifyPasswordHash(string str, byte[] strHash)
        {
            using (var hmac = new HMACSHA256())
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(str));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != strHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
