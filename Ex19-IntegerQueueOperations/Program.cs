using Ex19_IntegerQueueOperations;

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
                      _____                              _         ____                        
                     |  __ \                            (_)       / __ \                       
                     | |  | |_   _ _ __   __ _ _ __ ___  _  ___  | |  | |_   _  ___ _   _  ___ 
                     | |  | | | | | '_ \ / _` | '_ ` _ \| |/ __| | |  | | | | |/ _ | | | |/ _ \
                     | |__| | |_| | | | | (_| | | | | | | | (__  | |__| | |_| |  __| |_| |  __/
                     |_____/ \__, |_| |_|\__,_|_| |_| |_|_|\___|  \___\_\\__,_|\___|\__,_|\___|
                             __/ /                                                            
                            |___/ 
                                                                                                " + "\n");

        Console.ResetColor();
    }

    static void ShowMenu()
    {
        PrintBetweenColor("\t\t[1] ", "Add integer\n");

        PrintBetweenColor("\t\t[2] ", "Remove integer\n");

        PrintBetweenColor("\t\t[3] ", "Check if they're equal\n");

        PrintBetweenColor("\t\t[4] ", "Get bigger from queue\n");

        PrintBetweenColor("\t\t[5] ", "Get minor from queue\n");

        PrintBetweenColor("\t\t[6] ", "Get arithmetic mean from queue\n");

        PrintBetweenColor("\t\t[7] ", "Transfer integers from a queue to it's auxiliar\n");

        PrintBetweenColor("\t\t[8] ", "Get odd from queue\n");

        PrintBetweenColor("\t\t[9] ", "Get even from queue\n");

        PrintBetweenColor("\t\t[0] ", "Exit\n");
    }

    static int GetMenuOption()
    {
        string command;
        int result;

        do
        {
            do
            {
                ClearScreen();
                ShowMenu();
                PrintBetweenColor("\n\t\tOption: ");
                command = Console.ReadLine();

            } while (!int.TryParse(command, out result));

        } while (result < 0 || result > 9);

        return result;
    }

    static MyIntegerQueue SelectQueue(MyIntegerQueue firstOption, MyIntegerQueue secondOption)
    {
        string command;
        int result;

        do
        {
            do
            {
                ClearScreen();
                Console.WriteLine("\t\tChoose the queue");

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

    static void MockData(MyIntegerQueue integers)
    {
        for (int i = 0; i < 10; i++)
            integers.Insert(new MyInteger(i));
    }

    private static void Main(string[] args)
    {
        MyIntegerQueue myFirstQueue, mySecondQueue, myAuxiliarQueue, queueChoosed;
        MyInteger aux;
        int menuOption, value;

        myFirstQueue = new MyIntegerQueue("First queue");
        mySecondQueue = new MyIntegerQueue("Second queue");
        myAuxiliarQueue = new MyIntegerQueue("Auxiliar queue");

        MockData(myFirstQueue);
        MockData(mySecondQueue);

        do
        {
            ClearScreen();
            ShowMenu();


            menuOption = GetMenuOption();

            switch (menuOption)
            {
                case 1:
                    queueChoosed = SelectQueue(myFirstQueue, mySecondQueue);

                    queueChoosed.Insert(CreateMyInteger());

                    PrintBetweenColor($"\n\t\tValue queued to {queueChoosed.GetType()}\n");
                    break;

                case 2:
                    queueChoosed = SelectQueue(myFirstQueue, mySecondQueue);

                    aux = queueChoosed.Remove();

                    if (aux != null)
                        PrintBetweenColor($"\n\t\tRemoved: ", $"{aux}\n");
                    else
                        PrintBetweenColor($"\n\t\t{queueChoosed.GetType()} ", "is empty!\n");
                    break;

                case 3:
                    if (myFirstQueue.GetSize() > mySecondQueue.GetSize())
                        PrintBetweenColor($"\n\t\tQueue 1 is bigger!\n");
                    else if (myFirstQueue.GetSize() == mySecondQueue.GetSize())
                        PrintBetweenColor($"\n\t\tThey're equal!\n");
                    else
                        PrintBetweenColor("\n\t\tQueue 2 is bigger!\n");
                    break;

                case 4:
                    queueChoosed = SelectQueue(myFirstQueue, mySecondQueue);

                    aux = queueChoosed.GetBigger();

                    if (aux != null)
                        PrintBetweenColor($"\n\t\t{aux}", $" is the biggest number of the {queueChoosed.GetType()}!\n");
                    else
                        PrintBetweenColor("\n\t\tThis queue is empty!");
                    break;

                case 5:
                    queueChoosed = SelectQueue(myFirstQueue, mySecondQueue);

                    aux = queueChoosed.GetMinor();

                    SetForegroundColor();

                    if (aux != null)
                        PrintBetweenColor($"\n\t\t{aux}", $" is the minnor number of the {queueChoosed.GetType()}!\n");
                    else
                        PrintBetweenColor("\n\t\tThis queue is empty!");
                    break;

                case 6:
                    queueChoosed = SelectQueue(myFirstQueue, mySecondQueue);

                    value = queueChoosed.GetArithmeticMean();

                    PrintBetweenColor($"\n\t\t{value}", $" is the arithmethic mean of the {queueChoosed.GetType()}!\n");
                    break;

                case 7:
                    queueChoosed = SelectQueue(myFirstQueue, mySecondQueue);

                    if (!queueChoosed.IsEmpty())
                    {
                        while (!queueChoosed.IsEmpty())
                            myAuxiliarQueue.Insert(queueChoosed.Remove());

                        Console.Write("\n\t\tIntegers successfully transferred from ");
                        PrintBetweenColor($"{queueChoosed.GetType()}\n");
                    }
                    else
                        PrintBetweenColor("\n\t\tThis queue is empty!\n");
                    break;

                case 8:
                    MyInteger[] odds;
                    queueChoosed = SelectQueue(myFirstQueue, mySecondQueue);

                    odds = queueChoosed.GetOdds();

                    if (odds.Length != 0)
                    {
                        PrintBetweenColor($"\n\t\t{queueChoosed.GetType()} odds: \n");

                        for (int index = 0; index < odds.Length; index++)
                            PrintBetweenColor($"\t\t{odds[index]}\n");
                    }
                    else
                        PrintBetweenColor("\n\t\tThis queue is empty!\n");
                    break;

                case 9:
                    MyInteger[] evens;

                    queueChoosed = SelectQueue(myFirstQueue, mySecondQueue);

                    evens = queueChoosed.GetEvens();

                    if (evens.Length != 0)
                    {
                        PrintBetweenColor($"\n\t\t{queueChoosed.GetType()} evens: \n");

                        for (int index = 0; index < evens.Length; index++)
                            PrintBetweenColor($"\t\t{evens[index]}\n");
                    }
                    else
                        PrintBetweenColor("\n\t\tThis queue is empty!\n");
                    break;
            }

            Console.Write("\n\t\tPress any key to continue...");
            Console.ReadKey();

        } while (menuOption != 0);
    }
}