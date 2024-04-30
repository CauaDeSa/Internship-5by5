int size = 10;
int minorPosition, aux;

int[] numbers = new int[size];
int[] orderedNumbers = new int[size];

for (int i = 0; i < size; i++)
{
    Console.Write($"Type the {i + 1}° number ");
    numbers[i] = int.Parse(Console.ReadLine());
}

Console.WriteLine("\nCopying");

for (int i = 0; i < size; i++)
{
    orderedNumbers[i] = numbers[i]; ;
}

Console.WriteLine("\nOrdering");

for (int i = 0; i < size; i++)
{
    minorPosition = i;

    for (int j = i + 1; j < size; j++)
    {
        if (orderedNumbers[j] < orderedNumbers[minorPosition])
            minorPosition = j;
    }

    aux = orderedNumbers[i];
    orderedNumbers[i] = orderedNumbers[minorPosition];
    orderedNumbers[minorPosition] = aux;
}

Console.WriteLine("\n\nOrdered values");

for (int i = 0; i < size; i++)
{
    Console.Write($"{orderedNumbers[i]} ");
}

Console.WriteLine("\n\nOriginal values");

for (int i = 0; i < size; i++)
{
    Console.Write($"{numbers[i]} ");
}
Console.Write("\n\nPress any key to continue...");
Console.ReadKey();