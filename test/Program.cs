
void Comparation (string strA, string strB)
{
    switch (string.Compare(strA, strB, comparisonType: StringComparison.OrdinalIgnoreCase))
    {
        case 0:
            Console.WriteLine("igual");
            break;
        case 1:
            Console.WriteLine("a maior");
            break;
        case -1:
            Console.WriteLine("b maior");
            break;
            default:
            Console.WriteLine("sla");
            break;
            Console.ReadKey();
    }
}

do
{
    Console.Write("A: ");
    string a = Console.ReadLine();

    Console.Write("B: ");
    string b = Console.ReadLine();

    Comparation(a, b);
} while (true);