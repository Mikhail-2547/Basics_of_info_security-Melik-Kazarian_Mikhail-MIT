using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Versioning;


namespace ASYMContainers
{
    [SupportedOSPlatform("windows")]

    public class asymCipherWithContainers
    {
        const string ContainerName = "MyContainer";

        public static void AssignNewKey()
        {
            CspParameters cspParams = new CspParameters(1)
            {
                KeyContainerName = ContainerName,
                Flags = CspProviderFlags.UseMachineKeyStore,
                ProviderName = "Microsoft Strong Cryptographic Provider"
            };
            var rsa = new RSACryptoServiceProvider(cspParams)
            {
                PersistKeyInCsp = true
            };
        }
        public static byte[] EncryptData(byte[] dataToEncrypt)
        {
            byte[] cipherbytes;

            var cspParams = new CspParameters
            {
                KeyContainerName = ContainerName
            };

            using (var rsa = new RSACryptoServiceProvider(2048, cspParams))
            {
                cipherbytes = rsa.Encrypt(dataToEncrypt, false);
            }
            return cipherbytes;
        }
        public static byte[] DecryptData(byte[] dataToDecrypt)
        {
            byte[] plain;

            var cspParams = new CspParameters
            {
                KeyContainerName = ContainerName
            };

            using (var rsa = new RSACryptoServiceProvider(2048, cspParams))
            {
                plain = rsa.Decrypt(dataToDecrypt, false);
            }

            return plain;
        }
        public static void DeleteKeyInCsp()
        {
            var cspParams = new CspParameters()
            {
                KeyContainerName = ContainerName
            };
            var rsa = new RSACryptoServiceProvider(cspParams)
            {
                PersistKeyInCsp = false
            };
            
            rsa.Clear();
        }
    }

}
