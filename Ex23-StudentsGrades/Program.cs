using Ex23_StudentsGrades;
using System.Xml.Linq;

internal class Program
{
    static int theme = (new Random()).Next(-1, 3);
    static int studentIdCounter = 0;

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

    static int GetValue(string message, int max)
    {
        string input;
        int id;

        do
        {
            ClearScreen();
            PrintBetweenColor($"\n\t\t{message}: ");
            input = Console.ReadLine();

        } while (!int.TryParse(input, out id));

        return id;
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

    static Student CreateStudent()
    {
        return new Student(GetString("Student name"), ++studentIdCounter);
    }

    static Grade CreateGrade(int id)
    {
        string command;
        int value;

        do
        {
            do
            {
                ClearScreen();
                PrintBetweenColor($"\n\t\tType grade: ");
                command = Console.ReadLine();

            } while (!int.TryParse(command, out value));

        } while (value < 0 || value > 10);

        return new Grade(value, id);
    }

    static Student GetStudent(StudentStack stack, int id)
    {
        Student ?student = null;

        if (!stack.IsEmpty())
        {
            while (!stack.IsEmpty())
            {
                student = stack.Pop();

                if (student.GetStudentId() == id)
                    break;  
            }
        }

        return student;
    }

    static int HasGrades(GradesQueue gradesQueue, int id)
    {
        int gradesCounter = 0;

        if (!gradesQueue.IsEmpty())
        {
            GradesQueue auxQueue = gradesQueue.GetCopy();

            while (!auxQueue.IsEmpty())
            {
                if (auxQueue.Remove().GetId() == id)
                {
                    gradesCounter++;

                    if (gradesCounter == 2)
                        break;
                }
            }
        }

        return gradesCounter;
    }

    static int HasGrades(GradesQueue gradesQueue, int id, Grade[] studentGrades)
    {
        int gradesCounter = 0;
        Grade gradeAux;

        if (!gradesQueue.IsEmpty())
        {
            while (!gradesQueue.IsEmpty())
            {
                gradeAux = gradesQueue.Remove();

                if (gradeAux.GetId() == id)
                {
                    studentGrades[gradesCounter++] = gradeAux;

                    if (gradesCounter == 2)
                        break;
                }
            }
        }

        return gradesCounter;
    }

    static bool IsValid(int idChoosed)
    {
        return idChoosed >= 1 && idChoosed <= studentIdCounter;
    }

    static StudentStack GetStudentsWithoutGrades(GradesQueue gradesQueue, StudentStack studentStack)
    {
        int gradesCounter;
        int studentsQuantity = 0; 
        
        GradesQueue gradesQueueAux;
        Student[] students = new Student[studentStack.GetSize()];
        Student studentAux;

        if (!studentStack.IsEmpty())
        {
            while (!studentStack.IsEmpty())
            {
                studentAux = studentStack.Pop();

                gradesQueueAux = gradesQueue;

                gradesCounter = 0;

                while (!gradesQueueAux.IsEmpty())
                {
                    if (studentAux.GetStudentId() == gradesQueueAux.Remove().GetId())
                        gradesCounter++;
                }

                if (gradesCounter == 0)
                    students[studentsQuantity++] = studentAux;
            }

        }

        StudentStack fittedStack = new StudentStack();

        for (int index = 0, aux = studentsQuantity; index < studentsQuantity; index++)
            fittedStack.Push(students[--aux]);

        return fittedStack;
    }

    private static void Main(string[] args)
    {
        StudentStack studentStack = new StudentStack();
        StudentStack studentAuxStack;

        GradesQueue gradesQueue = new GradesQueue();

        Grade[] studentGrades;
        int command, idChoosed;

        do
        {
            ClearScreen();
            ShowMenu();

            command = GetValue("Option", 0, 6);

            switch (command)
            {
                case 1:
                    studentStack.Push(CreateStudent());
                    PrintBetweenColor("\n\t\tStudent successfully registered!\n");
                    break;

                case 2:
                    idChoosed = GetValue("Type student id", studentIdCounter);

                    if (IsValid(idChoosed))
                    {
                        if (HasGrades(gradesQueue.GetCopy(), idChoosed) < 2)
                        {
                            gradesQueue.Insert(CreateGrade(idChoosed));
                            PrintBetweenColor("\n\t\tGrade successfully registered\n");
                        }
                        else
                            PrintBetweenColor("\n\t\tThis student already has 2 grades!\n");
                    }
                    else
                        PrintBetweenColor("\n\t\tWe don't have a student with that id!\n");

                    break;

                case 3:
                    idChoosed = GetValue("Type student id", studentIdCounter);

                    if (IsValid(idChoosed))
                    {
                         studentGrades = new Grade[2];
                        if (HasGrades(gradesQueue.GetCopy(), idChoosed, studentGrades) == 2)
                        {
                            PrintBetweenColor($"\n\t\t{GetStudent(studentStack.GetCopy(), idChoosed).GetName()}", " average: ");
                            PrintBetweenColor($"{(studentGrades[0].GetGrade() + studentGrades[1].GetGrade()) / 2}\n");
                        }
                        else
                            PrintBetweenColor("\n\t\tThis student don't have all grades registered.\n");
                    }
                    else
                        PrintBetweenColor("\n\t\tWe don't have a student with that id!\n");
                    break;

                case 4:
                    studentAuxStack = GetStudentsWithoutGrades(gradesQueue.GetCopy(), studentStack.GetCopy());

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
                    if (studentIdCounter != 0)
                    {
                        if (HasGrades(gradesQueue.GetCopy(), studentIdCounter) == 0)
                            PrintBetweenColor($"\n\t\t{studentStack.Pop()} successfully removed!\n");
                        else
                            PrintBetweenColor("\n\t\tThis student can not be removed, he has grades!\n");
                    }
                    else
                        PrintBetweenColor("\n\t\tThere are no students to remove!\n");
                    break;

                case 6:
                    Grade aux = gradesQueue.Remove();

                    if (aux != null)
                        PrintBetweenColor($"\n\t\t{aux}", $" from id: {aux.GetId()} successfully removed\n");
                    else
                        PrintBetweenColor("\n\t\tThere are no grades to remove!\n");
                    break;
            }

            Console.Write("\n\t\tPress any key to continue...");
            Console.ReadKey();

        } while (command != 0);

        PrintBetweenColor("\t\t---------- Exiting ----------\n");
    }
}