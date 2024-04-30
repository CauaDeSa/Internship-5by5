float sideA, sideB, sideC;

do
{
    Console.Write("\nType 3 triangle sides!\n\n");

    do
    {
        Console.Write("Type side A: ");
        sideA = float.Parse(Console.ReadLine());
    } while (sideA <= 0);

    do
    {
        Console.Write("Type side B: ");
        sideB = float.Parse(Console.ReadLine());
    } while (sideB <= 0);

    do
    {
        Console.Write("Type side C: ");
        sideC = float.Parse(Console.ReadLine());
    } while (sideC <= 0);

    if (sideA + sideB > sideC && sideB + sideC > sideA && sideC + sideA > sideB)
    {
        Console.Write("\nIs a ");

        if (sideA == sideB && sideB == sideC)
            Console.Write("equilateral triangle!");
        else if (sideA != sideB && sideB != sideC && sideC != sideA)
            Console.WriteLine("scalene triangle!");
        else Console.WriteLine("isoceles triangle!");
    }
    else
        Console.WriteLine("These aren't triangle sizes!");

    Console.Write("\nDo you wanna test again? (y/n): ");
} while (Console.ReadLine() == "y");