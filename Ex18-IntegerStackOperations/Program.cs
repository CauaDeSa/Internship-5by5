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
            Console.Write("\n\t\tOption: ");
            command = Console.ReadLine();

        } while (!int.TryParse(command, out result) && (result < 0 || result > 9));

        return result;
    }

    static int SelectStack()
    {
        string command;
        int result;

        do
        {
            do
            {
                ClearScreen();
                Console.WriteLine("\t\tChoose the stack");

                SetForegroundColor();
                Console.Write("\n\t\t[1] ");
                Console.ResetColor();
                Console.WriteLine("First stack");

                SetForegroundColor();
                Console.Write("\t\t[2] ");
                Console.ResetColor();
                Console.WriteLine("Second stack");

                SetForegroundColor();
                Console.Write("\n\t\tOption: ");
                Console.ResetColor();
                command = Console.ReadLine();

            } while (!int.TryParse(command, out result));
        } while (result > 2 || result < 1);

        return result;
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
        MyIntegerStack myFirstStack, mySecondStack, myAuxiliarStack;
        MyInteger aux;
        int menuOption, value, stackChoosed;

        myFirstStack = new MyIntegerStack();
        mySecondStack = new MyIntegerStack();
        myAuxiliarStack = new MyIntegerStack();

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
                    stackChoosed = SelectStack();

                    if (stackChoosed == 1)
                        myFirstStack.Push(CreateMyInteger());

                    else
                        mySecondStack.Push(CreateMyInteger());

                    SetForegroundColor();
                    Console.WriteLine($"\n\t\tValue added to {(stackChoosed == 1 ? "first stack" : "second stack")}");
                    Console.ResetColor();
                    break;

                case 2:
                    stackChoosed = SelectStack();

                    if (stackChoosed == 1)
                        aux = myFirstStack.Pop();

                    else
                        aux = mySecondStack.Pop();

                    SetForegroundColor();
                    
                    if (aux != null)
                    {
                        Console.Write($"\n\t\tPoped: ");
                        Console.ResetColor();
                        Console.WriteLine(aux);
                    }
                    else
                    {
                        Console.Write($"\n\t\t{(stackChoosed == 1 ? "First stack" : "Second stack")} ");
                        Console.ResetColor();
                        Console.WriteLine("is empty!");
                    }
                    break;

                case 3:
                    SetForegroundColor();

                    if (myFirstStack.GetSize() > mySecondStack.GetSize())
                        Console.WriteLine($"\n\t\tStack 1 is bigger!");
                    else if (myFirstStack.GetSize() == mySecondStack.GetSize())
                            Console.WriteLine($"\n\t\tThey're equal!");
                        else 
                            Console.WriteLine("\n\t\tStack 2 is bigger!");

                    Console.ResetColor();
                    break;

                case 4:
                    stackChoosed = SelectStack();

                    if (stackChoosed == 1)
                        aux = myFirstStack.GetBigger();
                    else
                        aux = mySecondStack.GetBigger();
                    
                    SetForegroundColor();
                    
                    if (aux != null)
                    {
                        Console.Write($"\n\t\t{aux}");
                        Console.ResetColor();

                        Console.WriteLine($" is the biggest number of the {((stackChoosed == 1) ? "first" : "second")} stack!");
                    }
                    else
                    {
                        Console.WriteLine("\n\t\tThis stack is empty!");
                        Console.ResetColor();
                    }

                    break;

                case 5:
                    stackChoosed = SelectStack();

                    if (stackChoosed == 1)
                        aux = myFirstStack.GetMinor();
                    else
                        aux = mySecondStack.GetMinor();

                    SetForegroundColor();

                    if (aux != null)
                    {
                        Console.Write($"\n\t\t{aux}");
                        Console.ResetColor();

                        Console.WriteLine($" is the minnor number of the {((stackChoosed == 1) ? "first" : "second")} stack!");
                    }
                    else
                    {
                        Console.WriteLine("\n\t\tThis stack is empty!");
                        Console.ResetColor();
                    }

                    break;
            
                case 6:
                    SetForegroundColor();
                    stackChoosed = SelectStack();

                    if (stackChoosed == 1)
                        value = myFirstStack.GetArithmeticMean();
                    else
                        value = mySecondStack.GetArithmeticMean();

                    SetForegroundColor();
                    Console.Write($"\n\t\t{value}");
                    Console.ResetColor();

                    Console.WriteLine($" is the arithmethic mean of the {((stackChoosed == 1) ? "first" : "second")} stack!");

                    Console.ResetColor();
                    break;

                case 7:
                    stackChoosed = SelectStack();

                    if (stackChoosed == 1)
                        while (!myFirstStack.IsEmpty())
                            myAuxiliarStack.Push(myFirstStack.Pop());

                    else
                        while (!mySecondStack.IsEmpty())
                            myAuxiliarStack.Push(mySecondStack.Pop());

                    Console.Write("\n\t\tIntegers successfully transferred from ");

                    SetForegroundColor();
                    Console.WriteLine($"{((stackChoosed == 1) ? "first stack" : "second stack")}");
                    Console.ResetColor();
                    break;

                case 8:
                    MyInteger[] odds;
                    stackChoosed = SelectStack();

                    if (stackChoosed == 1)
                        odds = myFirstStack.GetOdds();

                    else
                        odds = mySecondStack.GetOdds();

                    SetForegroundColor();
                    if (odds.Length != 0)
                    {
                        Console.WriteLine($"\n\t\t{(stackChoosed == 1 ? "First stack" : "Second stack")} odds: \n");

                        for (int index = 0; index < odds.Length; index++)
                            Console.WriteLine($"\t\t{odds[index]}");
                    }
                    else
                    {
                        Console.WriteLine("\n\t\tThis stack is empty!");
                    }

                    Console.ResetColor();
                    break;

                case 9:
                    MyInteger[] evens;

                    SetForegroundColor();
                    stackChoosed = SelectStack();

                    if (stackChoosed == 1)
                        evens = myFirstStack.GetEvens();

                    else
                        evens = mySecondStack.GetEvens();

                    SetForegroundColor();
                    if (evens.Length != 0)
                    {
                        Console.WriteLine($"\n\t\t{(stackChoosed == 1 ? "First stack" : "Second stack")} evens: \n");

                        for (int index = 0; index < evens.Length; index++)
                            Console.WriteLine($"\t\t{evens[index]}");
                    }
                    else
                    {
                        Console.WriteLine("\n\t\tThis stack is empty!");
                    }

                    Console.ResetColor();
                    break;
            }

            Console.Write("\n\t\tPress any key to continue...");
            Console.ReadKey();

        } while (menuOption != 0);
    }
}