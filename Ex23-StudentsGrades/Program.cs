using Ex23_StudentsGrades;

internal class Program
{
    static int theme = (new Random()).Next(-1, 3);
    static int studentIdCounter = 1;

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
                   _____ _             _            _          _____               _           
                  / ____| |           | |          | |        / ____|             | |          
                 | (___ | |_ _   _  __| | ___ _ __ | |_ ___  | |  __ _ __ __ _  __| | ___  ___ 
                  \___ \| __| | | |/ _` |/ _ \ '_ \| __/ __| | | |_ | '__/ _` |/ _` |/ _ \/ __|
                  ____) | |_| |_| | (_| |  __/ | | | |_\__ \ | |__| | | | (_| | (_| |  __/\__ \
                 |_____/ \__|\__,_|\__,_|\___|_| |_|\__|___/  \_____|_|  \__,_|\__,_|\___||___/

		" + "\n");

        Console.ResetColor();
    }

    static void ShowMenu()
    {       
        PrintBetweenColor("\t\t[1] ", "Register student\n");
        PrintBetweenColor("\t\t[2] ", "Register grade\n");
        PrintBetweenColor("\t\t[3] ", "Calculate average\n");
        PrintBetweenColor("\t\t[4] ", "Show students without grades\n");
        PrintBetweenColor("\t\t[5] ", "Remove student\n");
        PrintBetweenColor("\t\t[6] ", "Remove grade\n");
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

    static Student CreateStudent()
    {
        Student b;
        string name;

        do
        {
            ClearScreen();
            Console.Write("\t\tStudent name: ");
            name = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(name));

        return new Student(name, studentIdCounter++);
    }

    private static void Main(string[] args)
    {
        StudentStack studentStack = new StudentStack();
        StudentStack studentAuxStack;

        Student studentAux;

        GradesQueue gradesQueue = new GradesQueue();
        GradesQueue gradesAuxQueue;

        Grade[] studentGrades = new Grade[2];
        int command, idChoosed;

        do
        {
            ClearScreen();
            ShowMenu();

            command = GetValue("Option", 0, 6);

            switch (command)
            {
            //PrintBetweenColor("\t\t[5] ", "Remove student\n");
            //PrintBetweenColor("\t\t[6] ", "Remove grade\n");
            //PrintBetweenColor("\t\t[0] ", "Exit\n");
                case 1:
                    studentStack.Push(CreateStudent());
                    PrintBetweenColor("\n\t\tStudent successfully registered!\n");
                    break;

                case 2:
                    idChoosed = GetValue("Type student id", 1, 1);

                    if (IsValid(idChoosed))
                    {
                        if (!HasAllGrades(gradesQueue, idChoosed))
                        {
                            gradesQueue.Insert(CreateGrade());
                            PrintBetweenColor("\n\t\tGrade successfully registered\n");
                        }
                        else
                            PrintBetweenColor("\n\t\tThis student already has 2 grades!\n");
                    }
                    else
                        PrintBetweenColor("\n\t\tThis id isn't valid!\n");

                    break;

                case 3:
                    idChoosed = GetValue("Type student id", 1, 1);

                    if (HasAllGrades(gradesQueue, idChoosed, studentGrades))
                    {
                        PrintBetweenColor($"\n\t\t{GetStudent(idChoosed).GetName}", " average: ");
                        PrintBetweenColor($"{(studentGrades[0].GetGrade() + studentGrades[1].GetGrade()) / 2}\n");
                    }
                    else
                        PrintBetweenColor("\n\t\tThis student don't have all grades registered.\n");
                    break;

                case 4:
                    studentAuxStack = GetStudentsWithoutGrades(gradesQueue);

                    if (studentAuxStack.IsEmpty())
                        PrintBetweenColor("\n\t\tThere are no students whitout grades!\n");
                    else
                    {
                        while (!studentAuxStack.IsEmpty())
                            PrintBetweenColor($"\n\t\t{studentAuxStack.Pop()}");
                        Console.WriteLine();
                    }
                    break;

                case 5:

                    break;

                case 6:

                    break;
            }

            Console.Write("\n\t\tPress any key to continue...");
            Console.ReadKey();

        } while (command != 0);

        PrintBetweenColor("\t\t---------- Exiting ----------\n");
    }
}