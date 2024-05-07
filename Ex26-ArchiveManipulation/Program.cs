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
                              _     _             __  __             _             _       _   _             
               /\            | |   (_)           |  \/  |           (_)           | |     | | (_)            
              /  \   _ __ ___| |__  ___   _____  | \  / | __ _ _ __  _ _ __  _   _| | __ _| |_ _  ___  _ __  
             / /\ \ | '__/ __| '_ \| \ \ / / _ \ | |\/| |/ _` | '_ \| | '_ \| | | | |/ _` | __| |/ _ \| '_ \ 
            / ____ \| | | (__| | | | |\ V /  __/ | |  | | (_| | | | | | |_) | |_| | | (_| | |_| | (_) | | | |
           /_/    \_\_|  \___|_| |_|_| \_/ \___| |_|  |_|\__,_|_| |_|_| .__/ \__,_|_|\__,_|\__|_|\___/|_| |_|
                                                            | |                                    
                                                            |_|                                    
		" + "\n");
    }

    static void ShowMenu()
    {
        PrintBetweenColor("\t\t[1] ", "Show data\n");
        PrintBetweenColor("\t\t[2] ", "Store data\n");
        PrintBetweenColor("\t\t[3] ", "Remove last line\n");
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
                PrintBetweenColor("\n\t\tOption: ");
                command = Console.ReadLine();

            } while (!int.TryParse(command, out result));

        } while (result < 0 || result > 3);

        return result;
    }

    static void MaintainPersistence(string[] currentContent, StreamWriter writer)
    {
        foreach (string content in currentContent)
            writer.WriteLine(content);
    }

    static void WriteContentInFile(string[] currentContent, StreamWriter writer)
    {
        MaintainPersistence(currentContent, writer);
        writer.WriteLine(Console.ReadLine());
        writer.Close();
    }

    static string[] GetContentLines(StreamReader reader)
    {
        string fileContent = reader.ReadToEnd();
        reader.Close();

        return fileContent.Split("\n", StringSplitOptions.None);
    }

    static void ShowContent(string[] lines)
    {
        bool isEmpty = true;

        foreach (var line in lines)
            if (line.Length > 0)
                isEmpty = false;
        
        if (!isEmpty)
        {
            PrintBetweenColor("\n\t\t---------- Content ----------\n");
            foreach (string line in lines)
                Console.WriteLine($"\t\t{line}");
            PrintBetweenColor("\t\t-----------------------------\n");
        }
        else
            PrintBetweenColor("\n\t\tArchive is empty!\n");
    }

    private static void Main(string[] args)
    {
        string path = @"C:\Data\Week-04\Ex26\";
        string file = "archive.txt";

        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
        if (!File.Exists(path + file))
            File.Create(path + file);

        StreamReader reader;
        StreamWriter writer;

        int command;

        do
        {
            ClearScreen();
            ShowMenu();

            command = GetCommand();

            switch (command)
            {
                case 1:
                    ShowContent(GetContentLines(new StreamReader(path + file)));
                    break;

                case 2:
                    Console.Write("\n\t\tType what should be saved: \n\n\t\t");
                    WriteContentInFile(GetContentLines(new StreamReader(path + file)), new StreamWriter(path + file));
                    break;
            }

            Console.Write("\n\t\tPress any key to continue...");
            Console.ReadKey();

        } while (command != 0);

        PrintBetweenColor("\t\t---------- Exiting ----------\n");
    }
}