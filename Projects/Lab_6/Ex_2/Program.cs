using ASYMContainers;
using System.Runtime.Versioning;
using System.Security.Cryptography;
using System.Text;
class Program
{
    [SupportedOSPlatform("windows")] // ЩОБ НЕ БУЛО ЖОВТЕНЬКОГО

    static void Main()
    {
        const string original = "Text to encrypt";

        asymCipherWithContainers.AssignNewKey();

        CspParameters cspParams = new CspParameters
        {
            KeyContainerName = "MyContainer"
        };

        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cspParams))
        {
            RSAParameters rsaParams = rsa.ExportParameters(true);
            RSAParameters rsaParams1 = rsa.ExportParameters(false);

        }

        var encrypted = asymCipherWithContainers.EncryptData(Encoding.UTF8.GetBytes(original));
        var decrypted = asymCipherWithContainers.DecryptData(encrypted);

        Console.WriteLine("RSA Encryption Demonstration in .NET");
        Console.WriteLine("------------------------------------");
        Console.WriteLine();
        Console.WriteLine("In Container Key");
        Console.WriteLine();
        Console.WriteLine($"    Original Text = {original}");
        Console.WriteLine($"    Encrypted Text = {Convert.ToBase64String(encrypted)}");
        Console.WriteLine($"    Decrypted Text = {Encoding.UTF8.GetString(decrypted)}");
    }
}