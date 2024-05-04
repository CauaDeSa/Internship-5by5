using Ex22_StackQueueReport;
using System;

internal class Program
{
    static int theme = (new Random()).Next(-1, 3);

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
           _____ _             _       ____                          _____                       _   
          / ____| |           | |     / __ \                        |  __ \                     | |  
         | (___ | |_ __ _  ___| | __ | |  | |_   _  ___ _   _  ___  | |__) |___ _ __   ___  _ __| |_ 
          \___ \| __/ _` |/ __| |/ / | |  | | | | |/ _ \ | | |/ _ \ |  _  // _ \ '_ \ / _ \| '__| __|
          ____) | || (_| | (__|   <  | |__| | |_| |  __/ |_| |  __/ | | \ \  __/ |_) | (_) | |  | |_ 
         |_____/ \__\__,_|\___|_|\_\  \___\_\\__,_|\___|\__,_|\___| |_|  \_\___| .__/ \___/|_|   \__|
                                                                               | |                   
                                                                               |_|                    
		" + "\n");
    }

    static void ShowMenu()
    {
        PrintBetweenColor("\t\t[1] ", "Fill stack\n");

        PrintBetweenColor("\t\t[2] ", "Fill queue\n");

        PrintBetweenColor("\t\t[3] ", "Show intersection\n");

        PrintBetweenColor("\t\t[4] ", "Show stack\n");

        PrintBetweenColor("\t\t[5] ", "Show queue\n");

        PrintBetweenColor("\t\t[6] ", "Clear stack\n");

        PrintBetweenColor("\t\t[7] ", "Clear queue\n");

        PrintBetweenColor("\t\t[0] ", "Exit\n");
    }

    static int GetCommand()
    {
        string command;
        int result;

        do
        {
            do
            {
                ClearScreen();
                ShowMenu();
                PrintBetweenColor($"\n\t\tOption: ");
                command = Console.ReadLine();

            } while (!int.TryParse(command, out result));

        } while (result < 0 || result > 7);

        return result;
    }

    static bool IsAlreadyAt(MyIntegerQueue queue, int number)
    {
        MyIntegerQueue auxQueue = queue.GetCopy();
        bool isRepeated = false;

        while (!auxQueue.IsEmpty())
            if (auxQueue.Remove().GetValue() == number)
                isRepeated = true;

        return isRepeated;
    }

    static bool IsAlreadyAt(MyIntegerStack stack, int number)
    {
        MyIntegerStack auxStack = stack.GetCopy();
        bool isRepeated = false;

        while (!auxStack.IsEmpty())
            if (auxStack.Pop().GetValue() == number)
                isRepeated = true;

        return isRepeated;
    }

    static void FillMyQueue(MyIntegerQueue queue)
    {
        Random random = new Random();
        int number;

        while (queue.GetSize() < 10)
        {
            do
            {
                 number = random.Next(0, 210);

            } while (IsAlreadyAt(queue, number));

            queue.Insert(new MyInteger(number));
        }
    }

    static void FillMyStack(MyIntegerStack stack)
    {
        Random random = new Random();
        int number;

        while (stack.GetSize() < 10)
        {
            do
            {
                number = random.Next(0, 21);

            } while (IsAlreadyAt(stack, number));

            stack.Push(new MyInteger(number));
        }
    }

    static MyInteger[] GetIntersection(MyIntegerStack stack, MyIntegerQueue queue)
    {
        MyInteger[] values = new MyInteger[10];
        MyIntegerQueue auxQueue = queue.GetCopy(); ;
        MyIntegerStack auxStack;
        MyInteger auxInteger;
        int counter = 0;

        do
        {
            auxInteger = auxQueue.Remove();
            auxStack = stack.GetCopy();

            do
            {
                if (auxInteger.GetValue() == auxStack.Pop().GetValue())
                    values[counter++] = auxInteger;
            } while (!auxStack.IsEmpty());

        } while (!auxQueue.IsEmpty());

        MyInteger[] fittedValues = new MyInteger[counter];

        for (int index = 0, aux = counter; index < counter; index++)
            fittedValues[index] = values[--aux];

        return fittedValues;
    }

    private static void Main(string[] args)
    {
        MyIntegerQueue queue = new MyIntegerQueue();
        MyIntegerStack stack = new MyIntegerStack();

        int command;
        MyInteger aux;

        do
        {
            ClearScreen();
            ShowMenu();

            command = GetCommand();

            switch (command)
            {
                case 1:
                    if (stack.IsEmpty())
                    {
                        FillMyStack(stack);
                        PrintBetweenColor("\n\t\tStack filled!\n");
                    }
                    else
                        PrintBetweenColor("\n\t\tClear it first!\n");
                    break;

                case 2:
                    if (queue.IsEmpty())
                    {
                        FillMyQueue(queue);
                        PrintBetweenColor("\n\t\tQueue filled!\n");
                    }
                    else
                        PrintBetweenColor("\n\t\tClear it first!\n");
                    break;

                case 3:
                    if (!stack.IsEmpty() && !queue.IsEmpty())
                    {
                        MyInteger[] auxIntegers = GetIntersection(stack, queue);

                        if (auxIntegers.Length > 0)
                        {
                            PrintBetweenColor("\n\t\tValues: \n");

                            for (int index = 0; index < auxIntegers.Length; index++)
                                PrintBetweenColor($"\n\t\t{auxIntegers[index]}");

                            Console.WriteLine();
                        }
                        else
                            PrintBetweenColor("\n\t\tThere are no numbers intersecting!\n");
                    }
                    else
                        if (stack.IsEmpty() && queue.IsEmpty())
                        PrintBetweenColor("\n\t\tFill stack and queue first!\n");
                    else
                        PrintBetweenColor($"\n\t\tFill {(stack.IsEmpty() ? "stack" : "queue")} first\n");
                    break;

                case 4:
                    MyIntegerStack auxStack = stack.GetCopy();

                    if (!auxStack.IsEmpty())
                    {
                        while (!auxStack.IsEmpty())
                            PrintBetweenColor($"\n\t\t{auxStack.Pop()}");
                        Console.WriteLine();
                    }
                    else
                        PrintBetweenColor("\n\t\tStack is empty!\n");
                    break;

                case 5:
                    MyIntegerQueue auxQueue = queue.GetCopy();

                    if (!auxQueue.IsEmpty())
                    {
                        while (!auxQueue.IsEmpty())
                            PrintBetweenColor($"\n\t\t{auxQueue.Remove()}");
                        Console.WriteLine();
                    }
                    else
                        PrintBetweenColor("\n\t\tQueue is empty!\n");
                    break;

                case 6:
                    if (!stack.IsEmpty())
                    {
                        while (!stack.IsEmpty())
                            PrintBetweenColor($"\n\t\t{stack.Pop()}", " removed!");
                        Console.WriteLine();
                    }

                    PrintBetweenColor("\n\t\tThe stack is empty!\n");
                    break;

                case 7:
                    if (!queue.IsEmpty())
                    {
                        while (!queue.IsEmpty())
                            PrintBetweenColor($"\n\t\t{queue.Remove()}", " removed!"); ;
                        Console.WriteLine();
                    }
                    PrintBetweenColor("\n\t\tThe queue is empty!\n");
                    break;
            }

            Console.Write("\n\t\tPress any key to continue...");
            Console.ReadKey();

        } while (command != 0);

        PrintBetweenColor("\t\t---------- Exiting ----------\n");
    }
}