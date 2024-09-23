using Ex_1;
using System;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

const string file_name = "encfile5.dat";
const string key = "I1g+4";
const string known_word = "Mit21";


/*Console.WriteLine("Decrypted: " + Ex_1.Encrypting.decryption(Encrypting.file_reading(file_name), known_word));
*/

/*Ex_1.Encrypting.string_to_five(Ex_1.Encrypting.file_reading(file_name), known_word);
*/

Console.WriteLine(Ex_1.Encrypting.file_reading_decrypted(Ex_1.Encrypting.encrypt_procedures(Ex_1.Encrypting.file_reading(file_name), Ex_1.Encrypting.string_to_bytes(key))));




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
/*g + 4I1
    g+4I1
g + 4I1x
*/