using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ASYM
{
    public class asymCipher
    {
        private static RSAParameters _publicKey, _privateKey;

        public static void AssignNewKey()
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                _publicKey = rsa.ExportParameters(false);
                _privateKey = rsa.ExportParameters(true);
            }
        }

        public static byte[] EncryptData(byte[] dataToEncrypt)
        {
            byte[] cipherbytes;

            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.PersistKeyInCsp = false;
                rsa.ImportParameters(_publicKey);

                cipherbytes = rsa.Encrypt(dataToEncrypt, true);
            }

            return cipherbytes;
        }
        public static byte[] DecryptData(byte[] dataToDecrypt)
        {
            byte[] plain;

            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.PersistKeyInCsp = false;

                rsa.ImportParameters(_privateKey);
                plain = rsa.Decrypt(dataToDecrypt, true);
            }

            return plain;
        }
    }
}
