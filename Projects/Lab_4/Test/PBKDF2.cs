using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HASHWITHSALT
{
    public class PBKDF2
    {
        public static bool Algorithm(string algorithm)
        {
            if (algorithm == "MD5" || algorithm == "SHA1" || algorithm == "SHA256" || algorithm == "SHA384" || algorithm == "SHA512")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static byte[] HashPassword(byte[] ToBeHashed, byte[] salt, int numberOfRounds, string algorithm)
        {
            if (algorithm == "MD5")
            {
                using(var md5 = MD5.Create())
                {
                    var dataToHash = new byte[ToBeHashed.Length + salt.Length];

                    Buffer.BlockCopy(ToBeHashed, 0, dataToHash, 0, ToBeHashed.Length);
                    Buffer.BlockCopy(salt, 0, dataToHash, ToBeHashed.Length, salt.Length);

                    byte[] hash = dataToHash;
                    for (int i = 0; i < numberOfRounds; i++)
                    {
                        hash = md5.ComputeHash(hash);
                    }
                    return hash;
                }
            }

            else
            {
                HashAlgorithmName algorithmName;

                switch (algorithm)
                {
                    case "SHA1":
                        algorithmName = HashAlgorithmName.SHA1;
                        break;
                    case "SHA256":
                        algorithmName = HashAlgorithmName.SHA256;
                        break;
                    case "SHA384":
                        algorithmName = HashAlgorithmName.SHA384;
                        break;
                    case "SHA512":
                        algorithmName = HashAlgorithmName.SHA512;
                        break;
                    default:
                        algorithmName = HashAlgorithmName.SHA1;
                        break;
                }

                using (var rfc2898 = new Rfc2898DeriveBytes(ToBeHashed, salt, numberOfRounds, algorithmName))
                {
                    return rfc2898.GetBytes(20);
                }
            }
        }
    }
}
