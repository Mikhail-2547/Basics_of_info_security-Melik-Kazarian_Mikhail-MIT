using PasswordSS;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HASHWITHSALT
{
    public class Hash
    {
        public static void HashPasswordVoid(string passwordToHash, int NumberOfRounds, string algorithm)
        {
            var sw = new Stopwatch();

            sw.Start();

            var hashedPassword = PBKDF2.HashPassword(Encoding.UTF8.GetBytes(passwordToHash), SaltedHash.GenerateSalt(), NumberOfRounds, algorithm);
        
            sw.Stop();

            Console.WriteLine();
            Console.WriteLine($"Password to hash : {passwordToHash}");
            Console.WriteLine($"Hashed Password : {Convert.ToBase64String(hashedPassword)}");
            Console.WriteLine($"Iterations < {NumberOfRounds} > Elapsed Time : {sw.ElapsedMilliseconds} ms");

        }
    }
}
