float n1, n2, n3, n4;
char operation;

Console.Write("Type number 1: ");
n1 = int.Parse(Console.ReadLine());

do
{
    Console.Write("Type number 2 (cant be 0): ");
    n2 = int.Parse(Console.ReadLine());
} while (n2 == 0);

do
{
    Console.Write("Type number 3 (cant be 0): ");
    n3 = int.Parse(Console.ReadLine());
} while (n3 == 0);

do
{
    Console.Write("Type number 4 (cant be 0): ");
    n4 = int.Parse(Console.ReadLine());
} while (n4 == 0);

do
{
    Console.Write("Type operation ('x' or '/' or '+' or '-'):  ");
    operation = char.Parse(Console.ReadLine());

    switch (operation)
    {
        case '+':
            Console.WriteLine($"Summed: {n1 + n2 + n3 + n4}");
            break;

        case '-':
            Console.WriteLine($"Subtracted: {n1 - n2 - n3 - n4}");
            break;

        case 'x':
            Console.WriteLine($"Multiplied: {n1 * n2 * n3 * n4}");
            break;

        case '/':
            Console.WriteLine($"Divided: {n1 / n2 / n3 / n4}");
            break;

        default:
            Console.WriteLine("Invalid operation!");
            break;
    }
} while (operation != '+' && operation != '-' && operation != 'x' && operation != '/');

Console.ReadKey();