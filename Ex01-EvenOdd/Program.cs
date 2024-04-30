int testCase;

Console.Write("Type a test number: ");
testCase = int.Parse(Console.ReadLine());

if (testCase == 0)
    Console.WriteLine("It's null!");
else
{
    if (testCase % 2 == 0)
        Console.WriteLine("It's even!");
    else
        Console.WriteLine("It's odd!");
}

Console.Write("Press any key to continue...");
Console.ReadKey();