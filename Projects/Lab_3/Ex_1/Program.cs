using System;
using System.Security.Cryptography;
using static Hash.Hash_algorithms;



const string strForHash1 = "Hello World!";
const string strForHash2 = "Hello World!";
const string strForHash3 = "Hello world!";

string[] strForHash_list = { strForHash1, strForHash2, strForHash3 };



/*--EXAMPLE--*/

/*-- Algorithm MD5 _EXAMPLE_ --*/

/*
var md5ForStr1 = ComputeHashMd5(strForHash1);
var md5ForStr2 = ComputeHashMd5(strForHash2);
var md5ForStr3 = ComputeHashMd5(strForHash3);

Guid guid1 = new Guid(md5ForStr1);
Guid guid2 = new Guid(md5ForStr2);
Guid guid3 = new Guid(md5ForStr3);

dynamic[] md5ForStr_list = { md5ForStr1, md5ForStr2, md5ForStr3 };
Guid[] guid_list = { guid1, guid2, guid3 };


for (int i = 0; i < 3; i++)
{
    Console.WriteLine($"Str:{strForHash_list[i]}");
    Console.WriteLine($"Hash MD5:{Convert.ToBase64String(md5ForStr_list[i])}");
    Console.WriteLine($"Guid:{guid_list[i]}");
}
*/

/*-- Algorithm SHA(Secure Hash Algorithm) _EXAMPLE_ --*/

/*
var sha256ForStr1 = ComputeHashSha256(strForHash1);
var sha256ForStr2 = ComputeHashSha256(strForHash2);
var sha256ForStr3 = ComputeHashSha256(strForHash3);


dynamic[] sha256ForStr_list = { sha256ForStr1, sha256ForStr2, sha256ForStr3 };

for (int i = 0; i < 3; i++)
{
    Console.WriteLine($"Str:{strForHash_list[i]}");
    Console.WriteLine($"Hash sha256:{Convert.ToBase64String(sha256ForStr_list[i])}");
}
*/

/*-----------------------------------------------------*/

/*--EX_1--*/

/*
var md5ForStr1 = ComputeHashMd5(strForHash1);
var md5ForStr2 = ComputeHashMd5(strForHash2);
var md5ForStr3 = ComputeHashMd5(strForHash3);

dynamic[] md5ForStr_list = { md5ForStr1, md5ForStr2, md5ForStr3 };

var sha1ForStr1 = ComputeHashSha1(strForHash1);
var sha1ForStr2 = ComputeHashSha1(strForHash2);
var sha1ForStr3 = ComputeHashSha1(strForHash3);

dynamic[] sha1ForStr_list = { sha1ForStr1, sha1ForStr2, sha1ForStr3 };

var sha256ForStr1 = ComputeHashSha256(strForHash1);
var sha256ForStr2 = ComputeHashSha256(strForHash2);
var sha256ForStr3 = ComputeHashSha256(strForHash3);

dynamic[] sha256ForStr_list = { sha256ForStr1, sha256ForStr2, sha256ForStr3 };

var sha384ForStr1 = ComputeHashSha384(strForHash1);
var sha384ForStr2 = ComputeHashSha384(strForHash2);
var sha384ForStr3 = ComputeHashSha384(strForHash3);

dynamic[] sha384ForStr_list = { sha384ForStr1, sha384ForStr2, sha384ForStr3 };

var sha512ForStr1 = ComputeHashSha384(strForHash1);
var sha512ForStr2 = ComputeHashSha384(strForHash2);
var sha512ForStr3 = ComputeHashSha384(strForHash3);

dynamic[] sha512ForStr_list = { sha512ForStr1, sha512ForStr2, sha512ForStr3 };

for  (int i = 0; i < 3; i++)
{
    Console.WriteLine($"Str: {strForHash_list[i]}");
    Console.WriteLine($"Hash MD5:{Convert.ToBase64String(md5ForStr_list[i])} -- {Convert.ToBase64String(md5ForStr_list[i]).Length} symbols");
    Console.WriteLine($"Hash sha1:{Convert.ToBase64String(sha1ForStr_list[i])} -- {Convert.ToBase64String(sha1ForStr_list[i]).Length} symbols");
    Console.WriteLine($"Hash sha256:{Convert.ToBase64String(sha256ForStr_list[i])} -- {Convert.ToBase64String(sha256ForStr_list[i]).Length} symbols");
    Console.WriteLine($"Hash sha384:{Convert.ToBase64String(sha384ForStr_list[i])} -- {Convert.ToBase64String(sha384ForStr_list[i]).Length} symbols");
    Console.WriteLine($"Hash sha512:{Convert.ToBase64String(sha512ForStr_list[i])} -- {Convert.ToBase64String(sha512ForStr_list[i]).Length} symbols");
    Console.WriteLine();
    Console.WriteLine("---------------------------");
    Console.WriteLine();
}
*/

/*--Ex_2--*/

string hash = "41664ae38eebbe01f730cdb5e6f6ce4e";
string hmac_hash = "40pmQeuOAb73MM215vbOTg==";
int password_length = 8;

Console.WriteLine($"Hash: {hash}");
Console.WriteLine($"Password: {BruteForcePassword(string_to_bytes(hash), string_to_bytes(hmac_hash), password_length)}");