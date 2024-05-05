using Ex24_AgeInLeapYears;

internal class Program
{
    static int theme = (new Random()).Next(-1, 3);
    static bool alreadyRegistered = false;

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
        if (++theme == 4)
            theme = 0;

        Console.Clear();

        PrintBetweenColor(@"
                                      _         _                       __     __                 
                    /\               (_)       | |                      \ \   / /                 
                   /  \   __ _  ___   _ _ __   | |     ___  __ _ _ __    \ \_/ /__  __ _ _ __ ___ 
                  / /\ \ / _` |/ _ \ | | '_ \  | |    / _ \/ _` | '_ \    \   / _ \/ _` | '__/ __|
                 / ____ \ (_| |  __/ | | | | | | |___|  __/ (_| | |_) |    | |  __/ (_| | |  \__ \
                /_/    \_\__, |\___| |_|_| |_| |______\___|\__,_| .__/     |_|\___|\__,_|_|  |___/
                          __/ |                                 | |                               
                         |___/                                  |_|                               
	" + "\n");

        Console.ResetColor();
    }

    static void ShowMenu()
    {
        PrintBetweenColor("\t\t[1] ", $"Register a new person {(alreadyRegistered ? "(overwrite)" : "")}\n");
        PrintBetweenColor("\t\t[2] ", "Show person info\n");
        PrintBetweenColor("\t\t[3] ", "Calculate age in leap years\n");
        PrintBetweenColor("\t\t[0] ", "Exit\n");
    }

    static int GetValue(string message, int min, int max)
    {
        string command;
        int value;

        do
        {
            do
            {
                ClearScreen();
                ShowMenu();
                PrintBetweenColor($"\n\t\t{message}: ");
                command = Console.ReadLine();

            } while (!int.TryParse(command, out value));

        } while (value < min || (min != max && value > max));

        return value;
    }

    static string GetString(string message)
    {
        string input;

        do
        {
            ClearScreen();
            Console.Write($"\t\t{message}: ");
            input = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(input));

        return input;
    }

    static Person RegisterPerson()
    {
        string command, name;
        int value;

        name = GetString("Insert name");

        do
        {
            do
            {
                ClearScreen();
                Console.Write($"\t\tType age: ");
                command = Console.ReadLine();

            } while (!int.TryParse(command, out value));

        } while (value < 0 || value > 120);

        return new Person(name, value, GetString("Insert profession"));
    }

    static int CalculateLeapYears(int yearOfBirth)
    {
        int leapAge = 0;

        while (yearOfBirth <= DateTime.Now.Year)
        {
            if (yearOfBirth % 4 == 0 && (yearOfBirth % 100 != 0 || yearOfBirth % 400 == 0))
                leapAge++;

            yearOfBirth++;
        }
        return leapAge;
    }

    private static void Main(string[] args)
    {
        Person ?myPerson = null;
        int command;

        do
        {
            ClearScreen();
            ShowMenu();

            command = GetValue("Option", 0, 3);

            switch (command)
            {
                case 1:
                        myPerson = RegisterPerson();
                        PrintBetweenColor($"\n\t\tPerson {(alreadyRegistered ? "overwrited" : "registered")}!\n");
                        alreadyRegistered = true;
                    break;

                case 2:
                    if (myPerson != null)
                        PrintBetweenColor(myPerson.ToString());
                    else
                        PrintBetweenColor("\n\t\tRegister someone first!\n");
                    break;

                case 3:
                    if (myPerson != null)
                        PrintBetweenColor($"\n\t\tAge in leap years: {CalculateLeapYears(myPerson.GetYearOfBirth())} years old\n");
                    else
                        PrintBetweenColor("\n\t\tRegister someone first!\n");
                    break;
            }

            Console.Write("\n\t\tPress any key to continue...");
            Console.ReadKey();

        } while (command != 0);

        PrintBetweenColor("\t\t---------- Exiting ----------\n");
    }
}