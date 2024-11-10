using ASYM;
using System.Security.Cryptography;
using System.Text;

const string original = "Text to encrypt";

asymCipher.AssignNewKey();

var encrypted = asymCipher.EncryptData(Encoding.UTF8.GetBytes(original));
var decrypted = asymCipher.DecryptData(encrypted);

Console.WriteLine("RSA Encryption Demonstration in .NET");
Console.WriteLine("------------------------------------");
Console.WriteLine();
Console.WriteLine("In Memory Key");
Console.WriteLine();
Console.WriteLine($"    Original Text = {original}");
Console.WriteLine($"    Encrypted Text = {Convert.ToBase64String(encrypted)}");
Console.WriteLine($"    Decrypted Text = {Encoding.UTF8.GetString(decrypted)}");
