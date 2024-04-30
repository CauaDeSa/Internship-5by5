int age;

Console.Write("Type your age: ");
age = int.Parse(Console.ReadLine());

if (age < 0)
    Console.WriteLine("Invalid age!");
else
{
    if (age > 17)
        Console.WriteLine("You are of legal age!");
    else
        Console.WriteLine("You are underage!");
}

Console.Write("Press any key to continue...");
Console.ReadKey();