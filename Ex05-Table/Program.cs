int number;

do
{
    Console.Write("Type a number: ");
    number = int.Parse(Console.ReadLine());
} while (number < 0);

for (int i = 0; i < 11; i++)
    Console.WriteLine($"{number} X {i} = {i * number}");

Console.ReadKey();