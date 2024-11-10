using static Ex_3.HMAC;
using static Ex_2.Generate_crypto_random_values;
using System.Text;

string note = "Weather-of-the-day-!!!";
string note_1 = "Weather-of-the-day-!!1";


byte[] key = bitting_the_data(8);
byte[] key_2 = bitting_the_data(8);



byte[] hmac_1 = ComputeHmacSha1(Encoding.UTF8.GetBytes(note), key);
byte[] hmac_1_new = ComputeHmacSha1(Encoding.UTF8.GetBytes(note), key);
byte[] hash_2_new = ComputeHmacSha1(Encoding.UTF8.GetBytes(note_1), key);

byte[] hmac_1_2 = ComputeHmacSha1(Encoding.UTF8.GetBytes(note), key_2);
byte[] hmac_1_new_2 = ComputeHmacSha1(Encoding.UTF8.GetBytes(note), key_2);
byte[] hash_2_new_2 = ComputeHmacSha1(Encoding.UTF8.GetBytes(note_1), key_2);

Console.WriteLine($"HMAC_1: {Convert.ToBase64String(hmac_1)}");
Console.WriteLine($"HMAC_2: {Convert.ToBase64String(hmac_1_new)}");
Console.WriteLine($"HMAC_3: {Convert.ToBase64String(hash_2_new)}");
Console.WriteLine("+--------------------------------+");
Console.WriteLine($"HMAC_1: {Convert.ToBase64String(hmac_1_2)}");
Console.WriteLine($"HMAC_2: {Convert.ToBase64String(hmac_1_new_2)}");
Console.WriteLine($"HMAC_3: {Convert.ToBase64String(hash_2_new_2)}");