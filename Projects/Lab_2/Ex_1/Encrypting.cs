using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Ex_1
{
    public class Encrypting
    {
        public static byte[] encrypt_procedures(byte[] message, byte[] key)
        {
            byte[] data = new byte[message.Length];
            for (int i = 0; i < message.Length; i++)
            {
               data[i] = (byte)(message[i] ^ key[i%5]);
            }
            return data;
        }

        public static byte[] file_reading(string decFileName) {
            byte[] decData = File.ReadAllBytes(decFileName).ToArray();
            return decData;
        }
        public static void file_writing(string encFileName, byte[] encData)
        {
            File.WriteAllBytes(encFileName, encData);
        }
        public static byte[] string_to_bytes(string data_to)
        {
            byte[] data = Encoding.UTF8.GetBytes(data_to);
            return data;
        }
        public static string file_reading_decrypted(byte[] data)
        {
            return Encoding.UTF8.GetString(data);
        }
        public static string decryption(byte[] data, string word)
        {
            Console.WriteLine(file_reading_decrypted(data));
            byte[] result;
            for (int i = 0; i < 5; i++)
            {
                result = encrypt_procedures(data, string_to_bytes(word));
                string originalString = file_reading_decrypted(result);

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("iteration" + i);
                Console.WriteLine("iteration" + i);
                Console.WriteLine("iteration" + i);
                Console.WriteLine("iteration" + i);
                Console.WriteLine("iteration" + i);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();


                for (int j = 0; j < originalString.Length; j += 5)
                {
                    if (j > originalString.Length - 5)
                    {
                        break;
                    }
                    Console.WriteLine();
                    Console.WriteLine(file_reading_decrypted(encrypt_procedures(data, string_to_bytes(originalString[j..(j + 5)]))));
                    if (
                        !file_reading_decrypted(encrypt_procedures(data, string_to_bytes(originalString[j..(j + 5)]))).Contains(word))
                    {
                        return file_reading_decrypted(encrypt_procedures(data, string_to_bytes(originalString[j..(j + 5)])));
                    }
                }


                word = word[..(4 - i)] + word[(4 - i)..];
            }
            return "loser";
        }



    }



}
