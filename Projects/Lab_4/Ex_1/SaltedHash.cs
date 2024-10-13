using Ex_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Ex_2.Generate_crypto_random_values;

namespace PasswordSS
{

    public class SaltedHash
    {

        public static byte[] GenerateSalt()
        {
            const int saltLength = 32;

            var salt = bitting_the_data(saltLength);
            return salt;
        }

        public static byte[] Combine(byte[] first, byte[] second)
        {
            var ret = new byte[first.Length + second.Length];

            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);

            return ret;
        }

        public static byte[] HashPasswordWithSalt(byte[] ToBeHashed ,byte[] salt)
        {
            using (var sha256 =  SHA256.Create())
            {
                return sha256.ComputeHash(Combine(ToBeHashed, salt));
            }
        }

    }
}
