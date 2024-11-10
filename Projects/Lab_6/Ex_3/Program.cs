using ASYMXML;
using System.Runtime.Versioning;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    [SupportedOSPlatform("windows")] // ЩОБ НЕ БУЛО ЖОВТЕНЬКОГО

    static void Main()
    {
        string choice;
        string name;
        string name2;
        string data;
        string Container_name;
/*        asymCipherWithXML.AssignNewKey("Test");
*/        
        do
        {
            Console.Clear();
            Console.WriteLine("a. Assign new keys");
            Console.WriteLine("e. Encrypt data");
            Console.WriteLine("d. Decrypt from XML");
            Console.WriteLine("x. Exit");
            Console.Write("Choose a command --> ");
            choice = Console.ReadLine()!;
            switch (choice)
            {
                case "a":
                    while (true)
                    {
                        Console.Write("Write the name of XML-File --> ");
                        name = Console.ReadLine()!;
                        if (name != "")
                        {
                            break;
                        }
                    }
                    while (true)
                    {
                        Console.Write("Write the container's name --> ");
                        Container_name = Console.ReadLine()!;
                        if (Container_name != "")
                        {
                            break;
                        }
                    }
                    asymCipherWithXML.AssignNewKey(name, Container_name);
                    break;
                case "e":
                    while (true)
                    {
                        Console.Write("Write the name of XML-File with public key --> ");
                        name2 = Console.ReadLine()!;
                        if (name2 != "")
                        {
                            break;
                        }
                    }
                    while (true)
                    {
                        Console.Write("Encrypted text's path --> ");
                        name = Console.ReadLine()!;
                        if (name != "")
                        {
                            break;
                        }
                    }
                    while (true)
                    {
                        Console.Write("Data to encrypt --> ");
                        data = Console.ReadLine()!;
                        if (data != "")
                        {
                            break;
                        }
                    }
                    try
                    {
                        asymCipherWithXML.EncryptData(name2, Encoding.UTF8.GetBytes(data), name);
                    }
                    catch
                    {
                        Console.WriteLine("There is no Public Key's Path with such name.");
                        Console.ReadLine();
                    }
                    break;
                case "d":
                    while (true)
                    {
                        Console.Write("Encrypted data's path --> ");
                        name = Console.ReadLine()!;
                        if (name != "")
                        {
                            break;
                        }
                    }
                    while(true)
                    {
                        Console.Write("Write the container's name --> ");
                        Container_name = Console.ReadLine()!;
                        if (Container_name != "")
                        {
                            break;
                        }
                    }
                    try
                    {
                        asymCipherWithXML.DecryptData(name, Container_name);
                        Console.WriteLine(Encoding.UTF8.GetString(asymCipherWithXML.DecryptData(name, Container_name)));
                        Console.ReadLine();
                    }
                    catch
                    {
                        Console.WriteLine("You are -> THIEF <- or there is no container or data with such name(or both).");
                        Console.ReadLine();
                    }
                    break;
                case "x":
                    Environment.Exit(0);
                    break;
            }
        } while (true);
    }
}