﻿using Ex18_IntegerStackOperations;

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
                       _____                              _         _____ _             _    
                      |  __ \                            (_)       / ____| |           | |   
                      | |  | |_   _ _ __   __ _ _ __ ___  _  ___  | (___ | |_ __ _  ___| | __
                      | |  | | | | | '_ \ / _` | '_ ` _ \| |/ __|  \___ \| __/ _` |/ __| |/ /
                      | |__| | |_| | | | | (_| | | | | | | | (__   ____) | || (_| | (__|   < 
                      |_____/ \__, |_| |_|\__,_|_| |_| |_|_|\___| |_____/ \__\__,_|\___|_|\_\
                              __/ |                                                         
                             |___/ " + "\n");

        Console.ResetColor();
    }

    static void ShowMenu()
    {
        PrintBetweenColor("\t\t[1] ", "Add integer\n");

        PrintBetweenColor("\t\t[2] ", "Remove integer\n");

        PrintBetweenColor("\t\t[3] ", "Check if they're equal\n");

        PrintBetweenColor("\t\t[4] ", "Get bigger from stack\n");

        PrintBetweenColor("\t\t[5] ", "Get minor from stack\n");

        PrintBetweenColor("\t\t[6] ", "Get arithmetic mean from stack\n");

        PrintBetweenColor("\t\t[7] ", "Transfer integers from a stack to it's auxiliar\n");

        PrintBetweenColor("\t\t[8] ", "Get odd from stack\n");

        PrintBetweenColor("\t\t[9] ", "Get even from stack\n");

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

        } while ( result< 0 || result> 9 );

        return result;
    }

    static MyIntegerStack SelectStack(MyIntegerStack firstOption, MyIntegerStack secondOption)
    {
        string command;
        int result;

        do
        {
            do
            {
                ClearScreen();
                Console.WriteLine("\t\tChoose the stack");

                PrintBetweenColor("\n\t\t[1] ", $"{firstOption.GetType()}\n");

                PrintBetweenColor("\t\t[2] ", $"{secondOption.GetType()}\n");

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

    static void MockData(MyIntegerStack integers)
    {
        for (int i = 0; i < 10; i++)
        {
            integers.Push(new MyInteger(i));
        }
    }

    private static void Main(string[] args)
    {
        MyIntegerStack myFirstStack, mySecondStack, myAuxiliarStack, stackChoosed;
        MyInteger aux;
        int menuOption, value;

        myFirstStack = new MyIntegerStack("First stack");
        mySecondStack = new MyIntegerStack("Second stack");
        myAuxiliarStack = new MyIntegerStack("Auxiliar stack");

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
                    stackChoosed = SelectStack(myFirstStack, mySecondStack);

                    stackChoosed.Push(CreateMyInteger());

                    PrintBetweenColor($"\n\t\tValue added to {stackChoosed.GetType()}\n");
                    break;

                case 2:
                    stackChoosed = SelectStack(myFirstStack, mySecondStack);

                    aux = stackChoosed.Pop();

                    if (aux != null)
                        PrintBetweenColor($"\n\t\tPoped: ", $"{aux}\n");
                    else
                        PrintBetweenColor($"\n\t\t{stackChoosed.GetType()} ", "is empty!\n");
                    break;

                case 3:
                    if (myFirstStack.GetSize() > mySecondStack.GetSize())
                        PrintBetweenColor($"\n\t\tStack 1 is bigger!\n");
                    else if (myFirstStack.GetSize() == mySecondStack.GetSize())
                        PrintBetweenColor($"\n\t\tThey're equal!\n");
                    else
                        PrintBetweenColor("\n\t\tStack 2 is bigger!\n");
                    break;

                case 4:
                    stackChoosed = SelectStack(myFirstStack, mySecondStack);

                    aux = stackChoosed.GetBigger();

                    if (aux != null)
                        PrintBetweenColor($"\n\t\t{aux}", $" is the biggest number of the {stackChoosed.GetType()}!\n");
                    else
                        PrintBetweenColor("\n\t\tThis stack is empty!");
                    break;

                case 5:
                    stackChoosed = SelectStack(myFirstStack, mySecondStack);

                    aux = stackChoosed.GetMinor();

                    SetForegroundColor();

                    if (aux != null)
                        PrintBetweenColor($"\n\t\t{aux}", $" is the minnor number of the {stackChoosed.GetType()}!\n");
                    else
                        PrintBetweenColor("\n\t\tThis stack is empty!");
                    break;

                case 6:
                    stackChoosed = SelectStack(myFirstStack, mySecondStack);

                    value = stackChoosed.GetArithmeticMean();

                    PrintBetweenColor($"\n\t\t{value}", $" is the arithmethic mean of the {stackChoosed.GetType()}!\n");
                    break;

                case 7:
                    stackChoosed = SelectStack(myFirstStack, mySecondStack);

                    if (!stackChoosed.IsEmpty())
                    {
                        while (!stackChoosed.IsEmpty())
                            myAuxiliarStack.Push(stackChoosed.Pop());

                        Console.Write("\n\t\tIntegers successfully transferred from ");
                        PrintBetweenColor($"{stackChoosed.GetType()}\n");
                    }
                    else
                        PrintBetweenColor("\n\t\tThis stack is empty!\n");
                    break;

                case 8:
                    MyInteger[] odds;
                    stackChoosed = SelectStack(myFirstStack, mySecondStack);

                    odds = stackChoosed.GetOdds();

                    if (odds.Length != 0)
                    {
                        PrintBetweenColor($"\n\t\t{stackChoosed.GetType()} odds: \n");

                        for (int index = 0; index < odds.Length; index++)
                            PrintBetweenColor($"\t\t{odds[index]}\n");
                    }
                    else
                        PrintBetweenColor("\n\t\tThis stack is empty!\n");
                    break;

                case 9:
                    MyInteger[] evens;

                    stackChoosed = SelectStack(myFirstStack, mySecondStack);

                    evens = stackChoosed.GetEvens();

                    if (evens.Length != 0)
                    {
                        PrintBetweenColor($"\n\t\t{stackChoosed.GetType()} evens: \n");

                        for (int index = 0; index < evens.Length; index++)
                            PrintBetweenColor($"\t\t{evens[index]}\n");
                    }
                    else
                        PrintBetweenColor("\n\t\tThis stack is empty!\n");
                    break;
            }

            Console.Write("\n\t\tPress any key to continue...");
            Console.ReadKey();

        } while (menuOption != 0);
    }
}