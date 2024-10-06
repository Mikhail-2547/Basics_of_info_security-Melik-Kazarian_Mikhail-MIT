using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hash
{
    public class Hash_algorithms
    {

        public static byte[] string_to_bytes(string data_to)
        {
            byte[] data = Encoding.UTF8.GetBytes(data_to);
            return data;
        }

        /*--Algorithms MD5 (16bytes)--*/

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

        /*--Algorithm SHA(Secure Hash Algorithm)--*/

        /*--ComputeHashSha1 (20bytes)--*/

        public static byte[] ComputeHashSha1(byte[] dataForHash)
        {
            using (var sha1 = SHA1.Create())
            {
                return sha1.ComputeHash(dataForHash);
            }
        }
        public static byte[] ComputeHashSha1(string dataForHash)
        {
            byte[] data = string_to_bytes(dataForHash);
            return ComputeHashSha1(data);
        }
        /*--ComputeHashSha256 (32bytes)--*/

        public static byte[] ComputeHashSha256(byte[] dataForHash)
        {
            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(dataForHash);
            }
        }
        public static byte[] ComputeHashSha256(string dataForHash)
        {
            byte[] data = string_to_bytes(dataForHash);
            return ComputeHashSha256(data);
        }

        /*--ComputeHashSha384 (48bytes)--*/

        public static byte[] ComputeHashSha384(byte[] dataForHash)
        {
            using (var sha384 = SHA384.Create())
            {
                return sha384.ComputeHash(dataForHash);
            }
        }
        public static byte[] ComputeHashSha384(string dataForHash)
        {
            byte[] data = string_to_bytes(dataForHash);
            return ComputeHashSha384(data);
        }

        /*--ComputeHashSha512 (64bytes)--*/

        public static byte[] ComputeHashSha512(byte[] dataForHash)
        {
            using (var sha512 = SHA512.Create())
            {
                return sha512.ComputeHash(dataForHash);
            }
        }
        public static byte[] ComputeHashSha512(string dataForHash)
        {
            byte[] data = string_to_bytes(dataForHash);
            return ComputeHashSha512(data);
        }

        /*--Algorithm HMAC(Hash Message Authentication Code)--*/

        public static byte[] ComputeHmacMd5(byte[] dataForHash, byte[] key)
        {
            using (var hmac = new HMACMD5())
            {
                return hmac.ComputeHash(dataForHash);
            }
        }
        public static byte[] ComputeHmacSha1(byte[] dataForHash, byte[] key)
        {
            using (var hmac = new HMACSHA1())
            {
                return hmac.ComputeHash(dataForHash);
            }
        }
        public static byte[] ComputeHmacSha256(byte[] dataForHash, byte[] key)
        {
            using (var hmac = new HMACSHA256())
            {
                return hmac.ComputeHash(dataForHash);
            }
        }
        public static byte[] ComputeHmacSha384(byte[] dataForHash, byte[] key)
        {
            using (var hmac = new HMACSHA384())
            {
                return hmac.ComputeHash(dataForHash);
            }
        }
        public static byte[] ComputeHmacSha512(byte[] dataForHash, byte[] key)
        {
            using (var hmac = new HMACSHA512())
            {
                return hmac.ComputeHash(dataForHash);
            }
        }

        /*----------*/

        public static string BruteForcePassword(byte[] data, byte[] hmac_hash, int length)
        {
            byte[] result;
            string password;
            for (int i = 0; i < Math.Pow(10, length); i++)
            {
                password = i.ToString().PadLeft(length, '0');
                result = ComputeHmacMd5(hmac_hash, string_to_bytes(password));

                if (data == result)
                {
                    return password;
                }
            }
            return "Пароль не знайдено";

        }
    }
}
