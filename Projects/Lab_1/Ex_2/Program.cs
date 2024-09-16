using System;
using System.Security.Cryptography;


byte[] data = new byte[32];

data = Ex_2.Generate_crypto_random_values.bitting_the_data(32);

for (int i = 0; i < data.Length; i++)
{
    Console.WriteLine(data[i]);
}