using Lesson16_DynamicStack;

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
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            case 2:
                Console.ForegroundColor = ConsoleColor.Cyan;
                break;
            case 3:
                Console.ForegroundColor = ConsoleColor.Magenta;
                break;
            case 4:
                Console.ForegroundColor = ConsoleColor.Green;
                break;
            case 5:
                Console.ForegroundColor = ConsoleColor.Gray;
                theme = -1;
                break;
        }
    }

    static void ClearScreen()
    {
        theme++;
        SetForegroundColor();
        Console.Clear();
        Console.WriteLine("\t\t______                             _        _____ _             _    \r\n\t\t|  _  \\                           (_)      /  ___| |           | |   \r\n\t\t| | | |_   _ _ __   __ _ _ __ ___  _  ___  \\ `--.| |_ __ _  ___| | __\r\n\t\t| | | | | | | '_ \\ / _` | '_ ` _ \\| |/ __|  `--. \\ __/ _` |/ __| |/ /\r\n\t\t| |/ /| |_| | | | | (_| | | | | | | | (__  /\\__/ / || (_| | (__|   < \r\n\t\t|___/  \\__, |_| |_|\\__,_|_| |_| |_|_|\\___| \\____/ \\__\\__,_|\\___|_|\\_\\\r\n\t\t        __/ |                                                        \r\n\t\t       |___/                                                         \n");
        
        Console.ResetColor();
    }

    static void ShowMenu()
    {
        SetForegroundColor(); 
        Console.Write("\t\t[1] ");
        Console.ResetColor();
        Console.WriteLine("Add book");

        SetForegroundColor();
        Console.Write("\t\t[2] ");
        Console.ResetColor(); 
        Console.WriteLine("Remove book");

        SetForegroundColor();
        Console.Write("\t\t[3] ");
        Console.ResetColor(); 
        Console.WriteLine("Remove and show all");

        SetForegroundColor();
        Console.Write("\t\t[4] ");
        Console.ResetColor();
        Console.WriteLine("Find by title");

        SetForegroundColor();
        Console.Write("\t\t[0] ");
        Console.ResetColor();
        Console.WriteLine("Exit");
    }

    static Book CreateBook()
    {
        Book b;
        string title;

        do
        {
            ClearScreen();
            Console.Write("\t\tInsert title: ");
            title = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(title));
        
        return new Book(title);
    }

    private static void Main(string[] args)
    {
        DynamicStack myStack = new DynamicStack();
        Book aux;
        int menuOption;
        string title;
        int occurrences;

        do
        {
            do
            {
                ClearScreen();
                Console.WriteLine($"\t\tCurrent quantity: {myStack.GetCounter()}\n\n");

                ShowMenu();
                Console.Write("\n\t\tOption: ( )\b\b");

                menuOption = int.Parse(Console.ReadLine());
            } while (menuOption < 0 || menuOption > 5);

            switch (menuOption)
            {
                case 1:
                    myStack.Push(CreateBook());
                    SetForegroundColor();
                    Console.WriteLine("\n\t\tBook added!");
                    Console.ResetColor();
                    break;

                case 2:
                    aux = myStack.Pop();
                    
                    SetForegroundColor();
                    if (aux != null)
                        Console.WriteLine($"\n\t\t{aux} successfully removed!");
                    else
                        Console.WriteLine("\n\t\tStack is empty!");
                    Console.ResetColor();
                    break;

                case 3:
                    ClearScreen();
                    Console.WriteLine($"\t\tCurrent quantity: {myStack.GetCounter()}\n\n");

                    do
                    {
                        aux = myStack.Pop();
                        if (aux != null)
                            Console.WriteLine($"\t\t{aux}");
                    } while (aux != null);

                    SetForegroundColor();
                    Console.WriteLine("\t\tStack is empty!");
                    Console.ResetColor();
                    break;

                case 4:
                    do
                    {
                        ClearScreen();
                        Console.WriteLine($"\t\tCurrent quantity: {myStack.GetCounter()}\n\n");

                        Console.Write("\t\tTitle to find: ");
                        title = Console.ReadLine();
                    } while (string.IsNullOrWhiteSpace(title));

                    occurrences = myStack.PopById(title);

                    SetForegroundColor();
                    if (occurrences > 0)
                        Console.WriteLine($"\n\t\t{title} successfully finded {occurrences} times!");
                    else
                        Console.WriteLine("\n\t\tThis book doesn't exist in this stack!");
                    Console.ResetColor();
                    break;

                case 0:
                    ClearScreen();
                    Console.WriteLine($"\t\tCurrent quantity: {myStack.GetCounter()}\n\n");
                    Console.WriteLine("\n\t\tExiting...");
                    break;
            }

            Console.WriteLine("\n\t\tPress any key to continue...");
            Console.ReadKey();
        } while (menuOption != 0);
    }
}