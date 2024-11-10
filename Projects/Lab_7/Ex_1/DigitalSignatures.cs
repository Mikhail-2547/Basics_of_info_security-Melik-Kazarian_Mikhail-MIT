using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Versioning;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DS
{
    [SupportedOSPlatform("windows")]

    public class DigitalSignatures
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
            }
        }

        public static bool TestContainer(string ContainerName)
        {

            var cspParams = new CspParameters
            {
                KeyContainerName = ContainerName,
                Flags = CspProviderFlags.UseExistingKey | CspProviderFlags.UseMachineKeyStore
            };

            try
            {
                using (var rsa = new RSACryptoServiceProvider(cspParams))
                {
                    // Экспорт закрытого ключа для подтверждения, что контейнер существует
                    rsa.ExportParameters(true);
                    return true; // Контейнер существует
                }
            }
            catch (CryptographicException)
            {
                return false;
            }
        }

        public static void SignData(byte[] hashOfDataToSign, string ContainerName, string path)
        {
            var cspParams = new CspParameters
            {
                KeyContainerName = ContainerName,
                Flags = CspProviderFlags.UseMachineKeyStore
            };

            using (var rsa = new RSACryptoServiceProvider(2048 , cspParams))
            {
                rsa.PersistKeyInCsp = true;

                var rsaFormatter = new RSAPKCS1SignatureFormatter(rsa);

                rsaFormatter.SetHashAlgorithm("SHA512");

                byte[] hashOfData;
                using (var sha512 = SHA512.Create())
                {
                    hashOfData = sha512.ComputeHash(hashOfDataToSign);
                }
                File.WriteAllBytes(path + "_signed.xml", rsaFormatter.CreateSignature(hashOfData));
            }
        }

        public static bool VerifySignature(string name, byte[] signature, string publicKeyPath)
        {
            var hashOfDataToSign = Encoding.UTF8.GetBytes(File.ReadAllText(name + ".txt"));
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                rsa.FromXmlString(File.ReadAllText(publicKeyPath + ".xml"));

                var rsaDeformatter = new RSAPKCS1SignatureDeformatter(rsa);

                rsaDeformatter.SetHashAlgorithm("SHA512");

                byte[] hashOfData;
                using (var sha512 = SHA512.Create())
                {
                    hashOfData = sha512.ComputeHash(hashOfDataToSign);
                }
                return rsaDeformatter.VerifySignature(hashOfData, signature);
            }
        }
    }
}
