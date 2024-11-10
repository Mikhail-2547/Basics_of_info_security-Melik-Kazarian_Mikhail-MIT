using static Ex_2.Hash_class;

string hash = "41664ae3-8eeb-be01-f730-cdb5e6f6ce4e";
int password_length = 8;

string password = BruteForcePassword(hash, password_length);


Console.WriteLine($"Hashed Password: {hash}");
Console.WriteLine($"Password: {password}");
