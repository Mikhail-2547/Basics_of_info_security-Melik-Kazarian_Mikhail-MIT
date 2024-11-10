using HASHWITHSALT;


const string passwordToHash = "VeryComplexPassword";
string algorithm;
while (true)
{
    Console.WriteLine("MD5 || SHA1 || SHA256 || SHA384 || SHA512");
    Console.Write("Algorithm -->");
    algorithm = Console.ReadLine();

    if (PBKDF2.Algorithm(algorithm) != true)
    {
        Console.WriteLine("Try again!!!");
    }
    else
    {
        break;
    }
}

// Варіант 12
Hash.HashPasswordVoid(passwordToHash, 120000, algorithm);
Hash.HashPasswordVoid(passwordToHash, 170000, algorithm);
Hash.HashPasswordVoid(passwordToHash, 220000, algorithm);
Hash.HashPasswordVoid(passwordToHash, 270000, algorithm);
Hash.HashPasswordVoid(passwordToHash, 320000, algorithm);
Hash.HashPasswordVoid(passwordToHash, 370000, algorithm);
Hash.HashPasswordVoid(passwordToHash, 420000, algorithm);
Hash.HashPasswordVoid(passwordToHash, 470000, algorithm);
Hash.HashPasswordVoid(passwordToHash, 520000, algorithm);
Hash.HashPasswordVoid(passwordToHash, 570000, algorithm);