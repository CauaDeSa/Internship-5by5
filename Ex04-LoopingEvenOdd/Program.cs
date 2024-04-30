int start, end, aux;

Console.Write("Type the start: ");
start = int.Parse(Console.ReadLine()) + 1;

aux = start;

Console.Write("Type the start: ");
end = int.Parse(Console.ReadLine());

//while (start < end)
//{
//    if (start % 2 == 0)
//        Console.WriteLine($"{start} é par!");
//    else
//        Console.WriteLine($"{start} é ímpar!");
//    start++;
//}

Console.WriteLine("\n------ Even ------");
while (start < end)
{
    if (start % 2 == 0 && start != 0)
        Console.WriteLine($"{start} is even!");
    start++;
}

start = aux;

Console.WriteLine("\n------ ODD ------");
while (start < end)
{
    if (start % 2 != 0)
        Console.WriteLine($"{start} is odd!");
    start++;
}

Console.Write("Press any key to continue...");
Console.ReadKey();