using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Ex_1;


namespace Ex_3
{
    public class HMAC
    {

        public static byte[] ComputeHmacMd5(byte[] dataForHash, byte[] key)
        {
            using (var hmac = new HMACMD5(key))
            {
                return hmac.ComputeHash(dataForHash);
            }
        }
        public static byte[] ComputeHmacSha1(byte[] dataForHash, byte[] key)
        {
            using (var hmac = new HMACSHA1(key))
            {
                return hmac.ComputeHash(dataForHash);
            }
        }
        public static byte[] ComputeHmacSha256(byte[] dataForHash, byte[] key)
        {
            using (var hmac = new HMACSHA256(key))
            {
                return hmac.ComputeHash(dataForHash);
            }
        }
        public static byte[] ComputeHmacSha384(byte[] dataForHash, byte[] key)
        {
            using (var hmac = new HMACSHA384(key))
            {
                return hmac.ComputeHash(dataForHash);
            }
        }
        public static byte[] ComputeHmacSha512(byte[] dataForHash, byte[] key)
        {
            using (var hmac = new HMACSHA512(key))
            {
                return hmac.ComputeHash(dataForHash);
            }
        }
    }
}
