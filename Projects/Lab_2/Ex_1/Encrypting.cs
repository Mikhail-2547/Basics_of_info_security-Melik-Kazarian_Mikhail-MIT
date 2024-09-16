using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Ex_1
{
    public class Encrypting
    {
        public static byte[] file_reading(string decFileName) {
            byte[] decData = File.ReadAllBytes(decFileName).ToArray();
            return decData;
        }
        public static void file_writing(string encFileName, byte[] encData)
        {
            File.WriteAllBytes(encFileName, encData);
        }
        public static void file_writing_str(string encFileName, string password)
        {
            byte[] data = Encoding.UTF8.GetBytes(password);
            file_writing(encFileName, data);
        }
        public static string file_reading_decrypted(string encFileName)
        {
            return Encoding.UTF8.GetString(file_reading(encFileName));
        }
    }
}
