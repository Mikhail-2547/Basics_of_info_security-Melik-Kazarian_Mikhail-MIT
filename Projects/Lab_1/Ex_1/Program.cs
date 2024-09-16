using System; //Підключення простору імен

Random random = new Random(); // Ініціювати генератор певним початковим значенням

for  (int i = 0; i < 10; i++)
{
    Console.WriteLine(random.Next(1, 101));
}