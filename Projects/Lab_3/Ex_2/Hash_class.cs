using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ex_2
{
    public class Hash_class
    {

        public static byte[] string_to_bytes(string data_to)
        {
            byte[] data = Encoding.UTF8.GetBytes(data_to);
            return data;
        }

        public static byte[] ComputeHashMd5(byte[] dataForHash)
        {
            using (var md5 = MD5.Create())
            {
                return md5.ComputeHash(dataForHash);
            }
        }
        public static byte[] ComputeHashMd5(string dataForHash)
        {
            byte[] data = string_to_bytes(dataForHash);
            return ComputeHashMd5(data);
        }



        public static string BruteForcePassword(string data, int length)
        {
            byte[] result;
            string password;
            for (int i = 0; i < Math.Pow(10, length); i++)
            {
                password = i.ToString().PadLeft(length, '0');
                result = ComputeHashMd5(password);

                if (data == Convert.ToBase64String(result))
                {
                    return password;
                }
            }
            return "Пароль не знайдено";

        }
    }
}
