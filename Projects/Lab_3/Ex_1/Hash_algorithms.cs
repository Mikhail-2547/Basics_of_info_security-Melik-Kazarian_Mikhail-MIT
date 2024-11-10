using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ex_1
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
    }
}

