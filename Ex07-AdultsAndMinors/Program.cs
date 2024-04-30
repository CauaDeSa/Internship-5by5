int age, adults, minors;

do
{
    adults = minors = 0;
    Console.Write("\nInsert 10 ages\n\n");

    for (int i = 1; i < 11; i++)
    {
        do
        {
            Console.Write($"[{i}]Type a valid age: ");
            age = int.Parse(Console.ReadLine());
        } while (age < 0 || age > 120);

        if (age >= 18)
            adults++;
        else
            minors++;
    }

    Console.WriteLine($"Adults: {adults}");
    Console.WriteLine($"minors: {minors}");

    Console.Write("Do you wanna test again? (y/n): ");

} while (Console.ReadLine() == "y");