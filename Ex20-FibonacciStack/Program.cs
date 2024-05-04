using Ex20_FibonacciStack;

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
        Console.WriteLine(@"
                 ______ _ _                                _    _____ _             _    
                |  ____(_| |                              (_)  / ____| |           | |   
                | |__   _| |__   ___  _ __   __ _  ___ ___ _  | (___ | |_ __ _  ___| | __
                |  __| | | '_ \ / _ \| '_ \ / _` |/ __/ __| |  \___ \| __/ _` |/ __| |/ /
                | |    | | |_) | (_) | | | | (_| | (_| (__| |  ____) | || (_| | (__|   < 
                |_|    |_|_.__/ \___/|_| |_|\__,_|\___\___|_| |_____/ \__\__,_|\___|_|\_\
                                                                          
                                                                          " + "\n");

        Console.ResetColor();
    }

    static void ShowMenu()
    {
        PrintBetweenColor("\t\t[1] ", "Push items\n");

        PrintBetweenColor("\t\t[2] ", "Show pushed numbers\n");

        PrintBetweenColor("\t\t[3] ", "Pop all stack\n");

        PrintBetweenColor("\t\t[0] ", "Exit\n");
    }

    static int GetValue(string message, int min, int max)
    {
        string command;
        int result;

        do
        {
            do
            {
                ClearScreen();
                ShowMenu();
                PrintBetweenColor($"\n\t\t{message}: ");
                command = Console.ReadLine();

            } while (!int.TryParse(command, out result));

        } while (result < min || (min != max && result > max));

        return result;
    }

    static void FillMyFibonacciStack(MyFibonacciStack stack, int quantity)
    {
        int numberOne, numberTwo, aux;

        numberOne = 1;
        numberTwo = -1;
        aux = 1;

        for (int i = 0; i < quantity; i++)
        {
            aux = numberTwo;
            numberTwo = numberOne;
            numberOne += aux;
            stack.Push(new MyFibonacci(numberOne));
        }
    }

    private static void Main(string[] args)
    {
        MyFibonacciStack myFibonacciStack = new MyFibonacciStack();
        MyFibonacciStack auxStack = new MyFibonacciStack();
        int command;
        MyFibonacci aux;

        do
        {
            ClearScreen();
            ShowMenu();

            command = GetValue("Option", 0, 3);

            switch (command)
            {
                case 1:
                    FillMyFibonacciStack(myFibonacciStack, GetValue("Insert quantity wanted of fibonacci numbers", 1, 1));

                    PrintBetweenColor("\n\t\tStack filled with fibonacci values!\n");
                    break;

                case 2:

                    if (!myFibonacciStack.IsEmpty())
                    {
                        Console.WriteLine();

                        while (!myFibonacciStack.IsEmpty())
                        {
                            aux = myFibonacciStack.Pop();
                            PrintBetweenColor($"\t\t{aux}\n");
                            auxStack.Push(aux);
                        }

                        while (!auxStack.IsEmpty())
                            myFibonacciStack.Push(auxStack.Pop());
                    }
                    else
                        PrintBetweenColor("\n\t\tThe stack is empty!\n");
                    break;

                case 3:
                    if (!myFibonacciStack.IsEmpty())
                    {
                        while (!myFibonacciStack.IsEmpty())
                            myFibonacciStack.Pop();
                        PrintBetweenColor("\n\t\tStack cleared!\n");
                    }
                    else
                        PrintBetweenColor("\n\t\tThe stack is already empty!\n");
                    break;

                case 0:
                    PrintBetweenColor("\n\t\tExiting...\n");
                    break;
            }

            Console.Write("\n\t\tPress any key to continue...");
            Console.ReadKey();

        } while (command != 0);
    }
}