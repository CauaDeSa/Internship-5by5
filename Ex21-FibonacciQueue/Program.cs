using Ex21_FibonacciQueue;

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
                  ______ _ _                                _    ____                        
                 |  ____(_| |                              (_)  / __ \                       
                 | |__   _| |__   ___  _ __   __ _  ___ ___ _  | |  | |_   _  ___ _   _  ___ 
                 |  __| | | '_ \ / _ \| '_ \ / _` |/ __/ __| | | |  | | | | |/ _ | | | |/ _ \
                 | |    | | |_) | (_) | | | | (_| | (_| (__| | | |__| | |_| |  __| |_| |  __/
                 |_|    |_|_.__/ \___/|_| |_|\__,_|\___\___|_|  \___\_\\__,_|\___|\__,_|\___|
                                                                             
                                                                             " + "\n");

        Console.ResetColor();
    }

    static void ShowMenu()
    {
        PrintBetweenColor("\t\t[1] ", "Insert items\n");

        PrintBetweenColor("\t\t[2] ", "Show inserted numbers\n");

        PrintBetweenColor("\t\t[3] ", "Clear stack\n");

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

    static void FillMyFibonacciQueue(MyFibonacciQueue queue, int quantity)
    {
        int numberOne, numberTwo, aux;

        numberOne = 1;
        numberTwo = -1;

        for (int i = 0; i < quantity; i++)
        {
            aux = numberTwo;
            numberTwo = numberOne;
            numberOne += aux;
            queue.Insert(new MyFibonacci(numberOne));
        }
    }

    private static void Main(string[] args)
    {
        MyFibonacciQueue fibonacciQueue = new MyFibonacciQueue();
        MyFibonacciQueue auxQueue = new MyFibonacciQueue();
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
                    FillMyFibonacciQueue(fibonacciQueue, GetValue("Insert quantity wanted of fibonacci numbers", 1, 1));

                    PrintBetweenColor("\n\t\tQueue filled with fibonacci values!\n");
                    break;

                case 2:

                    if (!fibonacciQueue.IsEmpty())
                    {
                        Console.WriteLine();

                        while (!fibonacciQueue.IsEmpty())
                        {
                            aux = fibonacciQueue.Remove();
                            PrintBetweenColor($"\t\t{aux}\n");
                            auxQueue.Insert(aux);
                        }

                        while (!auxQueue.IsEmpty())
                            fibonacciQueue.Insert(auxQueue.Remove());
                    }
                    else
                        PrintBetweenColor("\n\t\tThe stack is empty!\n");
                    break;

                case 3:
                    if (!fibonacciQueue.IsEmpty())
                    {
                        while (!fibonacciQueue.IsEmpty())
                            fibonacciQueue.Remove();
                        PrintBetweenColor("\n\t\tQueue cleared!\n");
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