using Ex18_IntegerStackOperations;

internal class Program
{
    static int theme = (new Random()).Next(-1, 5);

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
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                break;
            case 4:
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                break;
            case 5:
                Console.ForegroundColor = ConsoleColor.Cyan;
                break;
        }
    }

    static void ClearScreen()
    {
        theme++;

        if (theme == 6)
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
            ClearScreen();
            Console.WriteLine("\t\tChoose the stack");

            SetForegroundColor();
            Console.Write("\n\t\t[1] ");
            Console.ResetColor();
            Console.WriteLine("First stack");
            
            SetForegroundColor();
            Console.Write("\t\t[2] ");
            Console.ResetColor();
            Console.WriteLine("Second stack\n");

            SetForegroundColor();
            Console.Write("\n\t\tOption: ");
            Console.ResetColor();
            command = Console.ReadLine();

        } while (!int.TryParse(command, out result) && (result < 1 || result > 2));

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

    private static void Main(string[] args)
    {
        MyIntegerStack myFirstStack, mySecondStack, myAuxiliarStack;
        MyInteger aux;
        int menuOption, value, stackChoosed;

        myFirstStack = new MyIntegerStack();
        mySecondStack = new MyIntegerStack();
        myAuxiliarStack = new MyIntegerStack();

        do
        {
            ClearScreen();
            ShowMenu();

            menuOption = GetMenuOption();

            switch (menuOption)
            {
            //Console.WriteLine("Get odd from stack");
            //Console.Write("\t\t[9] ");
            //Console.WriteLine("Get even from stack");

                case 1:
                    myFirstStack.Push(CreateMyInteger());
                    SetForegroundColor();
                    Console.WriteLine("\n\t\tInteger added!");
                    Console.ResetColor();
                    break;

                case 2:
                    aux = myFirstStack.Pop();

                    SetForegroundColor();
                    if (aux != null)
                        Console.WriteLine($"\n\t\t{aux} successfully removed!");
                    else
                        Console.WriteLine("\n\t\tQueue is empty!");
                    Console.ResetColor();
                    break;

                case 3:
                    SetForegroundColor();

                    if (myFirstStack.GetSize() > mySecondStack.GetSize())
                        Console.WriteLine($"Stack 1 is bigger!");
                    else if (myFirstStack.GetSize() == mySecondStack.GetSize())
                            Console.WriteLine($"They're equal!");
                        else 
                            Console.WriteLine("Stack 2 is bigger!");

                    Console.ResetColor();
                    break;

                case 4:
                    SetForegroundColor();
                    stackChoosed = SelectStack();

                    if (stackChoosed == 1)
                    {
                        aux = myFirstStack.GetBigger();
                        Console.WriteLine($"{aux} is the bigger number of the first stack!");
                    }
                    else
                    {
                        aux = mySecondStack.GetBigger();
                        Console.WriteLine($"{aux} is the bigger number of the second stack!");
                    }
                    Console.ResetColor();
                    break;

                case 5:
                    SetForegroundColor();
                    stackChoosed = SelectStack();

                    if (stackChoosed == 1)
                    {
                        aux = myFirstStack.GetMinor();
                        Console.WriteLine($"{aux} is the minor number of the first stack!");
                    }
                    else
                    {
                        aux = mySecondStack.GetMinor();
                        Console.WriteLine($"{aux} is the minor number of the second stack!");
                    }
                    Console.ResetColor();
                    break;
            
                case 6:
                    SetForegroundColor();
                    stackChoosed = SelectStack();

                    if (stackChoosed == 1)
                    {
                        value = myFirstStack.GetArithmeticMean();
                        Console.WriteLine((value == 0 ? "\t\tIt is empty!" : $"\t\t{value} is the arithmetic mean of first stack!"));
                    }
                    else
                    {
                        value = mySecondStack.GetArithmeticMean();
                        Console.WriteLine((value == 0 ? "\t\tIt is empty!" : $"\t\t{value} is the arithmetic mean of first stack!"));
                    }
                    Console.ResetColor();
                    break;

                case 7:
                    SetForegroundColor();
                    stackChoosed = SelectStack();

                    if (stackChoosed == 1)
                        while (!myFirstStack.IsEmpty())
                            myAuxiliarStack.Push(myFirstStack.Pop());

                    else
                        while (!mySecondStack.IsEmpty())
                            myAuxiliarStack.Push(mySecondStack.Pop());

                    Console.WriteLine("\t\tIntegers successfully transferred!");
                    Console.ResetColor();
                    break;

                case 8:
                    SetForegroundColor();
                    stackChoosed = SelectStack();

                    if (stackChoosed == 1)
                    {

                    }

                    else
                    {

                    }
                        

                    Console.WriteLine("\t\tIntegers successfully transferred!");
                    Console.ResetColor();
                    break;
            }

            Console.Write("\n\t\tPress any key to continue...");
            Console.ReadKey();

        } while (menuOption != 0);
    }
}