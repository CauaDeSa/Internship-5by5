int size = 20;

int[] numbers = new int[size];
int[] ordered = new int[size];
//int[] reversedVector = new int[size];

int lastOccurrence, minor, aux, higher, count;

do
{
    lastOccurrence = higher = count = 0;

    Console.WriteLine("\nChallenger vector");

    for (int i = 0; i < size; i++)
    {
        numbers[i] = new Random().Next(0, 100);
        Console.Write($"{numbers[i]} ");
    }

    Console.WriteLine("\n\nOrdering...");

    minor = numbers[0];
    for (int i = 0; i < size; i++)
    {
        if (numbers[i] < minor)
        {
            minor = numbers[i];
            lastOccurrence = i;
        }
    }

    ordered[count++] = minor;
    Console.WriteLine($"\n{ordered[count - 1]}");

    for (int i = 0; i < size; i++)
    {
        if (numbers[i] > numbers[higher])
            higher = i;
    }

    while (count < size)
    {
        minor = higher;
        aux = count - 1;

        for (int i = 0; i < size; i++)
        {
            if (numbers[i] < numbers[minor] && numbers[i] >= ordered[aux])
                if (numbers[i] == ordered[aux])
                {
                    if (i > lastOccurrence)
                        minor = i;
                }
                else
                    minor = i;
        }

        lastOccurrence = minor;
        ordered[count++] = numbers[minor];
        Console.WriteLine($"{ordered[count - 1]}");
    }

    /*for (int index = 0; index < size; index++)
    {
        minor = higher;
        aux = count - 1;

        for (int i = 0; i < size; i++)
        {
            if (numbers[i] < numbers[minor] && numbers[i] >= ordered[aux])
                if (numbers[i] == ordered[aux])
                {
                    if (i > lastOccurrence)
                        minor = i;
                }
                else
                    minor = i;
        }

        lastOccurrence = minor;

        if (ordered[count - 1] != numbers[minor])
        {
            ordered[count++] = numbers[minor];
            Console.WriteLine($"{ordered[count - 1]}");
        }
    }

    aux = count;*/

    Console.WriteLine("\nResult\n");

    for (int i = 0; i < size; i++)
        Console.Write(ordered[i] + " ");

    /*    for (int i = 0; i < count; i++)
            reversedvector[i] = ordered[--aux];

        console.writeline("\n\nreverted\n");

        for (int i = 0; i < count; i++)
            console.write(reversedvector[i] + " ");*/

    Console.WriteLine("\n\nType 'y' to continue");
} while (Console.ReadLine() == "y");