int testCase, quantity;

do
{
    Console.Write("\nType a number: ");
    testCase = int.Parse(Console.ReadLine());
    quantity = 1;

    for (int i = 1; i < (testCase / 2) + 1; i++)
        if (testCase % i == 0)
            quantity += i;

    if (quantity == 2)
        Console.WriteLine($"{testCase} is primal!\n");
    else
        Console.WriteLine($"{testCase} isn't primal!\n");

    Console.Write("Do you wanna test another number? (y/n) : ");

} while (Console.ReadLine() == "y");