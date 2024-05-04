using Ex18_IntegerStackOperations;

internal class Program
{
    static int theme = (new Random()).Next(-1, 4);

    static void SetForegroundColor()
    {
        switch (theme)
        {
            case 0:
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            case 1:
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                break;
            case 2:
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            case 3:
                Console.ForegroundColor = ConsoleColor.Magenta;
                break;
            case 4:
                Console.ForegroundColor = ConsoleColor.Cyan;
                break;
        }
    }

    static void PrintBetweenColor(string message)
    {
        SetForegroundColor();
        Console.Write(message);
        Console.ResetColor();
    }

    static void PrintBetweenColor(string toColor, string message)
    {
        PrintBetweenColor(toColor);
        Console.Write(message);
    }

    static void ClearScreen()
    {
        theme++;

        if (theme == 5)
            theme = 0;

        SetForegroundColor();
        Console.Clear();
        Console.WriteLine("\t\t  _____                              _         ____                        \r\n\t\t |  __ \\                            (_)       / __ \\                       \r\n\t\t | |  | |_   _ _ __   __ _ _ __ ___  _  ___  | |  | |_   _  ___ _   _  ___ \r\n\t\t | |  | | | | | '_ \\ / _` | '_ ` _ \\| |/ __| | |  | | | | |/ _ \\ | | |/ _ \\\r\n\t\t | |__| | |_| | | | | (_| | | | | | | | (__  | |__| | |_| |  __/ |_| |  __/\r\n\t\t |_____/ \\__, |_| |_|\\__,_|_| |_| |_|_|\\___|  \\___\\_\\\\__,_|\\___|\\__,_|\\___|\r\n\t\t          __/ |                                                            \r\n\t\t         |___/                                                             \n");

        Console.ResetColor();
    }

    static void ShowMenu()
    {
        SetForegroundColor();
        Console.Write("\t\t[1] ");
        Console.ResetColor();
        Console.WriteLine("Add integer");

        SetForegroundColor();
        Console.Write("\t\t[2] ");
        Console.ResetColor();
        Console.WriteLine("Remove integer");

        SetForegroundColor();
        Console.Write("\t\t[3] ");
        Console.ResetColor();
        Console.WriteLine("Check if they're equal");

        SetForegroundColor();
        Console.Write("\t\t[4] ");
        Console.ResetColor();
        Console.WriteLine("Get bigger from stack");

        SetForegroundColor();
        Console.Write("\t\t[5] ");
        Console.ResetColor();
        Console.WriteLine("Get minor from stack");

        SetForegroundColor();
        Console.Write("\t\t[6] ");
        Console.ResetColor();
        Console.WriteLine("Get arithmetic mean from stack");

        SetForegroundColor();
        Console.Write("\t\t[7] ");
        Console.ResetColor();
        Console.WriteLine("Transfer integers from a stack to it's auxiliar");

        SetForegroundColor();
        Console.Write("\t\t[8] ");
        Console.ResetColor();
        Console.WriteLine("Get odd from stack");

        SetForegroundColor();
        Console.Write("\t\t[9] ");
        Console.ResetColor();
        Console.WriteLine("Get even from stack");

        SetForegroundColor();
        Console.Write("\t\t[0] ");
        Console.ResetColor();
        Console.WriteLine("Exit");
    }

    static int GetMenuOption()
    {
        string command;
        int result;

        do
        {
            ClearScreen();
            ShowMenu();
            PrintBetweenColor("\n\t\tOption: ");
            command = Console.ReadLine();

        } while (!int.TryParse(command, out result) && (result < 0 || result > 9));

        return result;
    }

    static MyIntegerStack SelectStack(MyIntegerStack firstOption, MyIntegerStack secondOption)
    {
        string command;
        int result;

        do
        {
            do
            {
                ClearScreen();
                Console.WriteLine("\t\tChoose the stack");

                PrintBetweenColor("\n\t\t[1] ");
                Console.WriteLine(firstOption.GetType());

                PrintBetweenColor("\t\t[2] ");
                Console.WriteLine(secondOption.GetType());

                PrintBetweenColor("\n\t\tOption: ");
                command = Console.ReadLine();

            } while (!int.TryParse(command, out result));
        } while (result > 2 || result < 1);

        return result == 1 ? firstOption : secondOption;
    }

    static MyInteger CreateMyInteger()
    {
        string input;
        int value;

        do
        {
            ClearScreen();
            Console.Write("\t\tInsert integer value: ");
            input = Console.ReadLine();
        } while (!int.TryParse(input, out value));

        return new MyInteger(value);
    }

    static void MockData(MyIntegerStack integers)
    {
        for (int i = 0; i < 10; i++)
        {
            integers.Push(new MyInteger(i));
        }
    }

    private static void Main(string[] args)
    {
        MyIntegerStack myFirstStack, mySecondStack, myAuxiliarStack, stackChoosed;
        MyInteger aux;
        int menuOption, value;

        myFirstStack = new MyIntegerStack("First stack");
        mySecondStack = new MyIntegerStack("Second stack");
        myAuxiliarStack = new MyIntegerStack("Auxiliar stack");

        MockData(myFirstStack);
        MockData(mySecondStack);

        do
        {
            ClearScreen();
            ShowMenu();


            menuOption = GetMenuOption();

            switch (menuOption)
            {
                case 1:
                    stackChoosed = SelectStack(myFirstStack, mySecondStack);

                    stackChoosed.Push(CreateMyInteger());

                    PrintBetweenColor($"\n\t\tValue added to {stackChoosed.GetType()}\n");
                    break;

                case 2:
                    stackChoosed = SelectStack(myFirstStack, mySecondStack);

                    aux = stackChoosed.Pop();

                    if (aux != null)
                        PrintBetweenColor($"\n\t\tPoped: ", $"{aux}\n");
                    else
                        PrintBetweenColor($"\n\t\t{stackChoosed.GetType()} ", "is empty!\n");
                    break;

                case 3:
                    if (myFirstStack.GetSize() > mySecondStack.GetSize())
                        PrintBetweenColor($"\n\t\tStack 1 is bigger!\n");
                    else if (myFirstStack.GetSize() == mySecondStack.GetSize())
                        PrintBetweenColor($"\n\t\tThey're equal!\n");
                    else
                        PrintBetweenColor("\n\t\tStack 2 is bigger!\n");
                    break;

                case 4:
                    stackChoosed = SelectStack(myFirstStack, mySecondStack);

                    aux = stackChoosed.GetBigger();

                    if (aux != null)
                        PrintBetweenColor($"\n\t\t{aux}", $" is the biggest number of the {stackChoosed.GetType()}!\n");
                    else
                        PrintBetweenColor("\n\t\tThis stack is empty!");
                    break;

                case 5:
                    stackChoosed = SelectStack(myFirstStack, mySecondStack);

                    aux = stackChoosed.GetMinor();

                    SetForegroundColor();

                    if (aux != null)
                        PrintBetweenColor($"\n\t\t{aux}", $" is the minnor number of the {stackChoosed.GetType()}!\n");
                    else
                        PrintBetweenColor("\n\t\tThis stack is empty!");
                    break;

                case 6:
                    stackChoosed = SelectStack(myFirstStack, mySecondStack);

                    value = stackChoosed.GetArithmeticMean();

                    PrintBetweenColor($"\n\t\t{value}", $" is the arithmethic mean of the {stackChoosed.GetType()}!\n");
                    break;

                case 7:
                    stackChoosed = SelectStack(myFirstStack, mySecondStack);

                    if (!stackChoosed.IsEmpty())
                    {
                        while (!stackChoosed.IsEmpty())
                            myAuxiliarStack.Push(stackChoosed.Pop());

                        Console.Write("\n\t\tIntegers successfully transferred from ");
                        PrintBetweenColor($"{stackChoosed.GetType()}\n");
                    }
                    else
                        PrintBetweenColor("\n\t\tThis stack is empty!\n");
                    break;

                case 8:
                    MyInteger[] odds;
                    stackChoosed = SelectStack(myFirstStack, mySecondStack);

                    odds = stackChoosed.GetOdds();

                    if (odds.Length != 0)
                    {
                        PrintBetweenColor($"\n\t\t{stackChoosed.GetType()} odds: \n");

                        for (int index = 0; index < odds.Length; index++)
                            PrintBetweenColor($"\t\t{odds[index]}\n");
                    }
                    else
                        PrintBetweenColor("\n\t\tThis stack is empty!\n");
                    break;

                case 9:
                    MyInteger[] evens;

                    stackChoosed = SelectStack(myFirstStack, mySecondStack);

                    evens = stackChoosed.GetEvens();

                    if (evens.Length != 0)
                    {
                        PrintBetweenColor($"\n\t\t{stackChoosed.GetType()} evens: \n");

                        for (int index = 0; index < evens.Length; index++)
                            PrintBetweenColor($"\t\t{evens[index]}\n");
                    }
                    else
                        PrintBetweenColor("\n\t\tThis stack is empty!\n");
                    break;
            }

            Console.Write("\n\t\tPress any key to continue...");
            Console.ReadKey();

        } while (menuOption != 0);
    }
}