using Ex_1;
using System;
using System.Xml.Linq;

const string file_name = "encfile5.dat";
const string known_word = "Mit21";


Console.WriteLine("Decrypted: " + Ex_1.Encrypting.decryption(Encrypting.file_reading(file_name), known_word));


/*string message = "145965561", key = "2asdaasda";
*/
/*byte[] message_bytes = Ex_1.Encrypting.string_to_bytes(message);
byte[] key_bytes = Ex_1.Encrypting.string_to_bytes(key);

Ex_1.Encrypting.file_writing(file_name, Ex_1.Encrypting.encrypt_procedures(message_bytes, key_bytes));

byte[] decdata = Ex_1.Encrypting.file_reading(file_name);
byte[] encdata = Ex_1.Encrypting.encrypt_procedures(decdata, key_bytes);


Console.WriteLine("Message: "+ message);

Console.WriteLine("Decrypted: "+ Ex_1.Encrypting.file_reading_decrypted(decdata));
Console.WriteLine("Encrypted: "+ Ex_1.Encrypting.file_reading_decrypted(encdata));*/
