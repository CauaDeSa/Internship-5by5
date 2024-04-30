double sideA, sideB;

do
{
    Console.WriteLine("\nType two sides and find the hypotenuse!");
    do
    {
        Console.Write("\nFirst side: ");
        sideA = double.Parse(Console.ReadLine());
    } while (sideA <= 0);

    do
    {
        Console.Write("Second side: ");
        sideB = double.Parse(Console.ReadLine());
    } while (sideB <= 0);

    Console.WriteLine($"\nHypotenuse: {Math.Sqrt(Math.Pow(sideA, 2) + Math.Pow(sideB, 2))}");

    Console.Write("\nDo you wanna test again? (y/n) : ");
} while (Console.ReadLine() == "y");