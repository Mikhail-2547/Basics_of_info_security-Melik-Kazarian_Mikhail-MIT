using AES;
using DES;
using TripleDES;
using SaltForEx;
using System.Text;

string password = "Hello_World!!!";

byte[] salt = Ex_2.Generate_crypto_random_values.bitting_the_data(256);

int iterations = 12 * 10000;

var desCipher = new DesCipher();
var tripleDesCipher = new TripleDesCipher();
var aesCipher = new AesCipher();


var (keyAES, ivAES) = Salt.GenerateKeyIv(password, salt, 32, 16, iterations);
var (keyDES, ivDES) = Salt.GenerateKeyIv(password, salt, 8, 8, iterations);
var (keyTripleDES, ivTripleDES) = Salt.GenerateKeyIv(password, salt, 16, 8, iterations);


const string original = "Text to encrypt";


var encryptedDes = desCipher.Encrypt(Encoding.UTF8.GetBytes(original), keyDES, ivDES);
var decryptedDes = desCipher.Decrypt(encryptedDes, keyDES, ivDES);
var decryptedDesMessage = Encoding.UTF8.GetString(decryptedDes);


var encryptedTripleDes = tripleDesCipher.Encrypt(Encoding.UTF8.GetBytes(original), keyTripleDES, ivTripleDES);
var decryptedTripleDes = tripleDesCipher.Decrypt(encryptedTripleDes, keyTripleDES, ivTripleDES);
var decryptedTripleDesMessage = Encoding.UTF8.GetString(decryptedTripleDes);

var encryptedAes = aesCipher.Encrypt(Encoding.UTF8.GetBytes(original), keyAES, ivAES);
var decryptedAes = aesCipher.Decrypt(encryptedAes, keyAES, ivAES);
var decryptedAesMessage = Encoding.UTF8.GetString(decryptedAes);

Console.WriteLine($"Original Text = {original}");

Console.WriteLine();
Console.WriteLine("-----------------------------");
Console.WriteLine("DES Encryption in .NET");
Console.WriteLine("-----------------------------");
Console.WriteLine();

Console.WriteLine($"Encrypted Text = {Convert.ToBase64String(encryptedDes)}");
Console.WriteLine($"Decrypted Text = {decryptedDesMessage}");

Console.WriteLine();
Console.WriteLine("-----------------------------");
Console.WriteLine("Triple-DES Encryption in .NET");
Console.WriteLine("-----------------------------");
Console.WriteLine();

Console.WriteLine($"Encrypted Text = {Convert.ToBase64String(encryptedTripleDes)}");
Console.WriteLine($"Decrypted Text = {decryptedTripleDesMessage}");

Console.WriteLine();
Console.WriteLine("-----------------------------");
Console.WriteLine("AES Encryption in .NET");
Console.WriteLine("-----------------------------");
Console.WriteLine();

Console.WriteLine($"Encrypted Text = {Convert.ToBase64String(encryptedAes)}");
Console.WriteLine($"Decrypted Text = {decryptedAesMessage}");

Console.ReadLine();