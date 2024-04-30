int size = 6;

int[] numbers = new int[size];
int[] ordered = new int[size];

int lastOccurrence, minor, aux, higher, count;

bool repeated;

do
{
    Console.Clear();

    lastOccurrence = higher = count = 0;

    for (int i = 0; i < size; i++)
    {
        do
        {
            repeated = false;
            aux = new Random().Next(1, 61);

            for (int j = 0; j < i; j++)
            {
                if (numbers[j] == aux)
                    repeated = true;
            }
        } while (repeated);

        numbers[i] = aux;
    }

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
    }

    Console.WriteLine("---- Sena Numbers ----\n");

    for (int i = 0; i < size; i++)
        Console.Write(ordered[i] + " ");

    Console.WriteLine("\n\nType 'y' to continue");
} while (Console.ReadLine() == "y");