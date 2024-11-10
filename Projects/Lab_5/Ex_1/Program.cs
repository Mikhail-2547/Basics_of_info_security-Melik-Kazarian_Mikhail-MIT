using AES;
using DES;
using Ex_2;
using System.Text;
using TripleDES;

var desCipher = new DesCipher();
var tripleDesCipher = new TripleDesCipher();
var aesCipher = new AesCipher();

const string original = "Test to encrypt";

//DES

var keyDes = Generate_crypto_random_values.bitting_the_data(8);
var ivDes = Generate_crypto_random_values.bitting_the_data(8);

var encryptedDes = desCipher.Encrypt(Encoding.UTF8.GetBytes(original), keyDes, ivDes);
var decryptedDes = desCipher.Decrypt(encryptedDes, keyDes, ivDes);
var decryptedDesMessage = Encoding.UTF8.GetString(decryptedDes);

//TRIPLE-DES

var keyTripleDes = Generate_crypto_random_values.bitting_the_data(16);
var ivTripleDes = Generate_crypto_random_values.bitting_the_data(8);

var encryptedTripleDes = tripleDesCipher.Encrypt(Encoding.UTF8.GetBytes(original), keyTripleDes, ivTripleDes);
var decryptedTripleDes = tripleDesCipher.Decrypt(encryptedTripleDes, keyTripleDes, ivTripleDes);
var decryptedTripleDesMessage = Encoding.UTF8.GetString(decryptedTripleDes);

//AES

var keyAes = Generate_crypto_random_values.bitting_the_data(32);
var ivAes = Generate_crypto_random_values.bitting_the_data(16);

var encryptedAes = aesCipher.Encrypt(Encoding.UTF8.GetBytes(original), keyAes, ivAes);
var decryptedAes = aesCipher.Decrypt(encryptedAes, keyAes, ivAes);
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