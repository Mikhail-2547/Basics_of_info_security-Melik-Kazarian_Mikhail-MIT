using DS;
using static DS.DigitalSignatures;
using System.Reflection.Metadata;
using System.Runtime.Versioning;
using System.Text;
using System.Security.Cryptography;
using System.Xml.Linq;

class Program
{
    [SupportedOSPlatform("windows")]

    static void Main()
    {
        string choice;
        string name;
        string name2;
        string data;
        string Container_name;
        do
        {
            Console.Clear();
            Console.WriteLine("a. Assign new keys");
            Console.WriteLine("s. SignData");
            Console.WriteLine("v. VerifySignature");
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
                    AssignNewKey(name, Container_name);
                    break;
                case "s":
                    while (true)
                    {
                        Console.Write("Write the container's name --> ");
                        Container_name = Console.ReadLine()!;
                        if (Container_name != "")
                        {
                            break;
                        }
                    }
                    if (!TestContainer(Container_name))
                    {
                        Console.WriteLine("There is no Container with such name.");
                        Console.ReadLine();
                        continue;
                    }
                    while (true)
                    {
                        Console.Write("Write the name of XML-FILES to sign in --> ");
                        name = Console.ReadLine()!;
                        if (name != "")
                        {
                            break;
                        }
                    }
                    while (true)
                    {
                        Console.Write("Data to sign --> ");
                        data = Console.ReadLine()!;
                        if (data != "")
                        {
                            break;
                        }
                    }
                    File.WriteAllText(name + ".txt", data);
                    SignData(Encoding.UTF8.GetBytes(data), Container_name, name);
                    break;
                case "v":
                    while (true)
                    {
                        Console.Write("Write the name of XML-File with public key--> ");
                        name2 = Console.ReadLine()!;
                        if (name2 != "")
                        {
                            break;
                        }
                    }
                    try
                    {
                        File.ReadAllText(name2 + ".xml");
                    }
                    catch
                    {
                        Console.WriteLine("There is no public key with such name!!!");
                        Console.ReadLine();
                        continue;
                    }
                    while (true)
                    {
                        Console.Write("Write the name of XML-FILE & TXT-FILE --> ");
                        name = Console.ReadLine()!;
                        if (name != "")
                        {
                            break;
                        }
                    }
                    try
                    {
                        if (VerifySignature(name, File.ReadAllBytes(name + "_signed.xml"), name2))
                        {
                            Console.WriteLine("DIGITAL SIGNATURE IS VERIFIED");
                        }
                        else
                        {
                            Console.WriteLine("DIGITAL SIGNATURE IS NOT VERIFIED");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("There is no XML-FILES with such name!");
                        Console.ReadLine();
                        continue;
                    }
                    Console.ReadLine();
                    break;
                case "x":
                    Environment.Exit(0);
                    break;
            }
        } while (true);
    }
}