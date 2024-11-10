using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;
using HASHWITHSALT;
using PasswordSS;

string choice;
string Login;
string Login_2;
string Password;
string Password2;
byte[] hashedLogin = null;
byte[] hashedPassword = null;
byte[] Salt = SaltedHash.GenerateSalt();
do
{
    Console.Clear();
    Console.WriteLine("r. Registragion");
    Console.WriteLine("a. Autentification");
    Console.WriteLine("x. Exit");
    Console.Write("Choose a command --> ");
    choice = Console.ReadLine()!;
    switch (choice)
    {
        case "r":
            while (true)
            {
                Console.Write("LOGIN --> ");
                Login = Console.ReadLine();
                if (Login != "")
                {
                    break;
                }
            }

            while (true)
            {
                Console.Write("PASSWORD --> ");
                Password = Console.ReadLine();
                if (Password != "")
                {
                    break;
                }
            }
            hashedLogin = PBKDF2.HashPassword(Encoding.UTF8.GetBytes(Login), Salt, 12000, "MD5");
            hashedPassword = PBKDF2.HashPassword(Encoding.UTF8.GetBytes(Password), Salt, 12000, "MD5");
            break;
        case "a":
            while (true)
            {
                Console.Write("LOGIN --> ");
                Login_2 = Console.ReadLine();
                if (Login_2 != "")
                {
                    break;
                }
            }
            var hashedLogin_aut = PBKDF2.HashPassword(Encoding.UTF8.GetBytes(Login_2), Salt, 12000, "MD5");

            if (hashedLogin == null || !hashedLogin.SequenceEqual(hashedLogin_aut))
            {
                Console.WriteLine("There is no such login in memory.");
                Console.ReadLine();
                break;
            }
            while (true)
            {
                Console.Write("PASSWORD --> ");
                Password2 = Console.ReadLine();
                if (Password2 != "")
                {
                    break;
                }
            }
            var hashedPassword_aut = PBKDF2.HashPassword(Encoding.UTF8.GetBytes(Password2), Salt, 12000, "MD5");
            if (hashedPassword == null || !hashedPassword.SequenceEqual(hashedPassword_aut))
            {
                Console.WriteLine("WRONG PASSWORD!!!");
                Console.ReadLine();
                break;
            }
            else
            {
                Console.WriteLine($"----># Hello {Login_2}!!!");
                Console.ReadLine();
            }
            break;
        case "x":
            Environment.Exit(0);
            break;
    }
} while (true);