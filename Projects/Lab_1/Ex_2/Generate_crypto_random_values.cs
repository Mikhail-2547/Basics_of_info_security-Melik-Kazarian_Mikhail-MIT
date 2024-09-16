using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ex_2
{
    public class Generate_crypto_random_values
    {
        public static byte[] bitting_the_data(int lenght)
        {
            var rnd = RandomNumberGenerator.Create();
            byte[] data = new byte[lenght];


            rnd.GetBytes(data);
            return data;
        }
    }
}
