using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Ex_1
{
    public class Protector
    {
        private static byte[] saltForAdmin = PasswordSS.SaltedHash.GenerateSalt();
        private static User admin = new User() { Id = 0, Login = "admin", Roles = new[] { "Admin" }, Salt = saltForAdmin, PasswordHash = Encoding.UTF8.GetString(passwordHash(Encoding.UTF8.GetBytes("admin"), saltForAdmin, 100_000, HashAlgorithmName.SHA512)) };
        private static Dictionary<string, User> _users = new Dictionary<string, User>() { {"admin", admin } };
        private static int id = 1;

        public static byte[] passwordHash(byte[] data, byte[] salt, int numOfIterations, HashAlgorithmName algorithm) {
            using (var rfc2898 = new Rfc2898DeriveBytes(data, salt, numOfIterations, algorithm))
            {
                return rfc2898.GetBytes(20);
            }

        }
        public static User Register(string userName, string password, string roles)
        {
            if (_users.Keys.Contains(userName))
            {
                return null;
            }
            if (roles == "Admin")
            {
                Console.WriteLine("You can not become an Admin!!!");
                Console.ReadLine();
                return null;
            }

            byte[] salt = PasswordSS.SaltedHash.GenerateSalt();
            User user = new User();

            user.Salt = salt;

            user.PasswordHash = Encoding.UTF8.GetString(passwordHash(Encoding.UTF8.GetBytes(password), salt, 100_000, HashAlgorithmName.SHA512));

            user.Id = id++;
            user.Login = userName;
            user.Roles[0] = roles;
            _users.Add(userName, user);
            return user;
        }
        public static bool CheckPassword (string username, string password)
        {
            if (!_users.Keys.Contains(username))
            {
                return false;
            }
            using (var rfc2898 = new Rfc2898DeriveBytes(Encoding.UTF8.GetBytes(password), _users[username].Salt, 100_000, HashAlgorithmName.SHA512))
            {
                if(_users[username].PasswordHash == Encoding.UTF8.GetString(rfc2898.GetBytes(20)))
                {
                    return true;
                }
                return false;
            }
        }
        public static void UserData(string username, string password)
        {
            Console.WriteLine();
            if (!_users[username].Roles.Contains("Admin"))
            {
                Console.WriteLine($"Id: {_users[username].Id}\nName: {username}\nPassword: *******\nRole: {_users[username].Roles[0]}");
                Console.ReadLine();
                return;
            }
            Console.WriteLine($"Id: {_users[username].Id}\nName: {username}\nPassword: {password}\nHash of Password: {_users[username].PasswordHash}\nRole: {_users[username].Roles[0]}");
            Console.ReadLine();
        }

        public static void LogIn(string username, string password, ref bool check)
        {
            if (CheckPassword (username, password))
            {
                Console.WriteLine();
                Console.WriteLine("Autentificated.");
                Thread.Sleep(500);
                var identify = new GenericIdentity(username, "OIBAuth");
                var principal = new GenericPrincipal(identify, _users[username].Roles);

                
                
                System.Threading.Thread.CurrentPrincipal = principal;
                Console.WriteLine("Autorized...");
                UserData(username, password);
                check = true;
                return;
            }
            check = false;
        }

        public static void OnlyForAdminsFeature()
        {
            if(Thread.CurrentPrincipal == null)
            {
                throw new SecurityException("Thread.CurrentPrincipal cannot be null.");
            }
            if(!Thread.CurrentPrincipal.IsInRole("Admin"))
            {
                throw new SecurityException("User must be a member of Admins to access this feature.");
            }
            Console.WriteLine("You have access to this secure feature");
        }
        public static void DisplayUserList()
        {
            try
            {
                OnlyForAdminsFeature();
                Console.WriteLine("ID\tName\t\tRole");
                Console.WriteLine(new string('-', 45));
                foreach (var user in _users)
                {
                    Console.WriteLine($"{user.Value.Id}\t{user.Value.Login,-15}{user.Value.Roles[0],-15}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ID\tName\t\tRole");
                Console.WriteLine(new string('-', 45));
                int counter = 0;
                foreach (var user in _users)
                {
                    if (counter == 0)
                    {
                        counter++;
                        continue;
                    }
                    Console.WriteLine($"{user.Value.Id}\t{user.Value.Login,-15}{user.Value.Roles[0],-15}");
                }
            }
        }

    }
}
