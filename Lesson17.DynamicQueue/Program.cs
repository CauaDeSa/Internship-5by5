using Lesson17_DynamicQueue;
using System.Runtime.Intrinsics.X86;

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
                Console.ForegroundColor = ConsoleColor.DarkCyan;
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
        Console.WriteLine("Add Person");

        SetForegroundColor();
        Console.Write("\t\t[2] ");
        Console.ResetColor();
        Console.WriteLine("Remove Person");

        SetForegroundColor();
        Console.Write("\t\t[3] ");
        Console.ResetColor();
        Console.WriteLine("Remove and show all");

        SetForegroundColor();
        Console.Write("\t\t[4] ");
        Console.ResetColor();
        Console.WriteLine("Show all");

        SetForegroundColor();
        Console.Write("\t\t[0] ");
        Console.ResetColor();
        Console.WriteLine("Exit");
    }

    static int GetCommand()
    {
        string command;
        int result;

        do
        {
            ClearScreen();
            ShowMenu();
            Console.Write("\n\t\tOption: ");
            command = Console.ReadLine();

        } while (!int.TryParse(command, out result) && (result < 0 || result > 4));

        return result;
    }

    static Person CreatePerson()
    {
        Person b;
        string name;

        do
        {
            ClearScreen();
            Console.Write("\t\tInsert name: ");
            name = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(name));

        return new Person(name);
    }

    private static void Main(string[] args)
    {
        DynamicQueue myPersonQueue = new DynamicQueue();
        
        int command;
        Person aux;
        
        do
        {
            ClearScreen();
            ShowMenu();

            command = GetCommand();

            switch (command)
            {
                case 1:
                    myPersonQueue.Insert(CreatePerson());
                    SetForegroundColor();
                    Console.WriteLine("\n\t\tPerson added!");
                    Console.ResetColor();
                    break;

                case 2:
                    aux = myPersonQueue.Remove();

                    SetForegroundColor();
                    if (aux != null)
                        Console.WriteLine($"\n\t\t{aux} successfully removed!");
                    else
                        Console.WriteLine("\n\t\tQueue is empty!");
                    Console.ResetColor();
                    break;

                case 3:
                    Console.WriteLine();

                    do
                    {
                        aux = myPersonQueue.Remove();
                        if (aux != null)
                            Console.WriteLine($"\t\t{aux}");
                        else
                            Console.WriteLine();
                    } while (aux != null);

                    SetForegroundColor();
                    Console.WriteLine("\t\tQueue is empty!");
                    Console.ResetColor();
                    break;

                case 4:
                    myPersonQueue.ShowAll();
                    break;
            }

            Console.Write("\n\t\tPress any key to continue...");
            Console.ReadKey();

        } while (command != 0);
    }
}