using PasswordSS;
using System.Text;

class Program
{
    static void Main()
    {
        const string password = "V3ryC0mpl3xP455w0rd";
        byte[] salt = SaltedHash.GenerateSalt();

        Console.WriteLine($"Password: {password}");
        Console.WriteLine($"Salt = {Convert.ToBase64String(salt)}");
        Console.WriteLine();

        var hashedPassword1 =  SaltedHash.HashPasswordWithSalt(Encoding.UTF8.GetBytes(password), salt);
        Console.WriteLine($"Hashed Password = {Convert.ToBase64String(hashedPassword1)}");

        Console.ReadLine();

    }                                              
}