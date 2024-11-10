using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SaltForEx
{
    public class Salt
    {
        public static (byte[] key, byte[] iv) GenerateKeyIv(string password, byte[] salt, int keySize, int ivSize, int iterations)
        {
            using (var rfc2898 = new Rfc2898DeriveBytes(password, salt, iterations))
            {
                byte[] key = rfc2898.GetBytes(keySize);
                byte[] iv = rfc2898.GetBytes(ivSize);
                return (key, iv);
            }
        }
    }
}
