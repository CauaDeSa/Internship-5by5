int number, iterator, copy = 0;

Console.Write("Type a number: ");
number = int.Parse(Console.ReadLine());

Console.Write("Type the iterator: ");
iterator = int.Parse(Console.ReadLine());

Console.WriteLine("--------- FOR ---------\n");

for (int i = copy + 1; i < iterator + 1; i++)
{

    number++;
    Console.WriteLine($"{i.ToString("D2")}: {number.ToString("D3")}");
}

Console.WriteLine("------- DO WHILE ------\n");

do
{
    copy++;
    number++;
    Console.WriteLine($"{copy.ToString("D2")}: {number.ToString("D3")}");
} while (copy < iterator);

Console.WriteLine("-------- WHILE --------\n");
copy = 0;

while (copy < iterator)
{
    copy++;
    number++;
    Console.WriteLine($"{copy.ToString("D2")}: {number.ToString("D3")}");
}

Console.Write("Press any key to continue...");
Console.ReadKey();