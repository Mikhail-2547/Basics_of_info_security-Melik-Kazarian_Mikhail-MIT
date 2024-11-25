using Ex_1;
using System.Text;

class Program
{
    static void Main()
    {
        string choice;
        string username;
        string password;
        string role;
        bool x = false;
        do
        {
            Console.Clear();
            Console.WriteLine("r. Registration");
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
                        username = Console.ReadLine()!;
                        if (username != "")
                        {
                            break;
                        }
                    }
                    while (true)
                    {
                        Console.Write("PASSWORD --> ");
                        password = Console.ReadLine()!;
                        if (password != "")
                        {
                            break;
                        }
                    }
                    while (true)
                    {
                        Console.Write("ROLE --> ");
                        role = Console.ReadLine()!;
                        if (role != "")
                        {
                            break;
                        }
                    }
                    var test = Protector.Register(username, password, role);
                    if (test == null)
                    {
                        Console.WriteLine("Maybe next time...");
                        Console.ReadLine();
                        break;
                    }
                    Console.WriteLine($"Congratulations!!! You, {username} are registrated!!!");
                    Console.ReadLine();
                    break;
                case "a":
                    while (true)
                    {
                        Console.Write("LOGIN --> ");
                        username = Console.ReadLine()!;
                        if (username != "")
                        {
                            break;
                        }
                    }
                    while (true)
                    {
                        Console.Write("PASSWORD --> ");
                        password = Console.ReadLine()!;
                        if (password != "")
                        {
                            break;
                        }
                    }
                    Protector.LogIn(username, password, ref x);
                    if (x == true)
                    {
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("u. *USER*");
                            Console.WriteLine("l. *List of Users*");
                            Console.WriteLine("x. *LogOut*");
                            Console.Write("Choose a command --> ");
                            choice = Console.ReadLine()!;
                            switch (choice)
                            {
                                case "u":
                                    Protector.UserData(username, password);
                                    break;
                                case "x":
                                    x = false;
                                    break;
                            }
                        } while (x);
                    }
                    else
                    {
                        Console.WriteLine("ERROR");
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


