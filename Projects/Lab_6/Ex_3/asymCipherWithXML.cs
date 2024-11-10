using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Runtime.Versioning;

namespace ASYMXML
{
    [SupportedOSPlatform("windows")]

    public class asymCipherWithXML
    {
        public static void AssignNewKey(string publicKeyPath, string ContainerName = "default")
        {

            CspParameters cspParams = new CspParameters(1)
            {
                KeyContainerName = ContainerName,
                Flags = CspProviderFlags.UseMachineKeyStore,
                ProviderName = "Microsoft Strong Cryptographic Provider"
            };

            using (var rsa = new RSACryptoServiceProvider(2048, cspParams))
            {
                rsa.PersistKeyInCsp = true;
                File.WriteAllText(publicKeyPath + ".xml", rsa.ToXmlString(false));

                RSAParameters rsaParams = rsa.ExportParameters(true);
                RSAParameters rsaParams1 = rsa.ExportParameters(false);
            }
        }

        public static void EncryptData(string publicKeyPath, byte[] dataToEncrypt, string cipherTextPath)
        {
            byte[] cipherbytes;

            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                rsa.FromXmlString(File.ReadAllText(publicKeyPath + ".xml"));

                cipherbytes = rsa.Encrypt(dataToEncrypt, true);
            }
            File.WriteAllBytes(cipherTextPath, cipherbytes);
        }

        public static byte[] DecryptData(string cipherTextPath, string ContainerName = "default")
        {
            byte[] cipherbytes = File.ReadAllBytes(cipherTextPath);
            byte[] plain;

            var cspParams = new CspParameters
            {
                KeyContainerName = ContainerName,
                Flags = CspProviderFlags.UseMachineKeyStore
            };

            using (var rsa = new RSACryptoServiceProvider(2048, cspParams))
            {
                rsa.PersistKeyInCsp = true;
                plain = rsa.Decrypt(cipherbytes, true);
            }
            return plain;
        }

    }
}
