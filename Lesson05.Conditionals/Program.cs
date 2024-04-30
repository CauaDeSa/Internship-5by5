float n1, n2;

Console.Write("Type number 1: ");
n1 = int.Parse(Console.ReadLine());

Console.Write("Type number 2: ");
n2 = int.Parse(Console.ReadLine());

Console.WriteLine($"Summed: {n1 + n2}");
Console.WriteLine($"Subtracted: {n1 - n2}");
Console.WriteLine($"Multiplied: {n1 * n2}");

if (n2 >= 2)
    Console.WriteLine($"Divided: {n1 / n2}");

else
{
    if (n2 == 0)
        Console.WriteLine("Cannot divide by 0!");
    else
        Console.WriteLine("Divider number is less than 0");
}

Console.Write("Press any key to continue...");
Console.ReadKey();