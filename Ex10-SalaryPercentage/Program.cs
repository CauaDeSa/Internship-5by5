double salary, newSalary;

do
{
    Console.Write("\nType the actual salary and the increased salary to discover the percentage!\n\n");

    do
    {
        Console.Write("Actual: R$");
        salary = float.Parse(Console.ReadLine());
    } while (salary <= 0);

    do
    {
        Console.Write("Increased: R$");
        newSalary = float.Parse(Console.ReadLine());
    } while (newSalary <= 0);

    Console.WriteLine($"Increase percentage: {(newSalary - salary) / salary * 100}%");

    Console.Write("\nDo you wanna try again? (y/n) : ");
} while (Console.ReadLine() == "y");