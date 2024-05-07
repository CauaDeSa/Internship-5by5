internal class Program
{
    private static void Main(string[] args)
    {
        string path = @"C:\Data\Week-04\Lesson20\";
        string file = "archive.txt";

        StreamReader reader;
        StreamWriter writer;

        string text;
        string userInput, archiveOutput;

        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        if (!File.Exists(path + file))
            File.Create(path + file);

        reader = new(path + file);
        text = reader.ReadToEnd();
        reader.Close();

        writer = new(path + file);
        writer.WriteLine(text);

        Console.Write("Type your name: ");
        writer.WriteLine(Console.ReadLine());

        Console.Write("Type your email: ");
        writer.WriteLine(Console.ReadLine());

        writer.Close();

        reader = new(path + file);
        Console.Clear();
        Console.WriteLine(reader.ReadToEnd());

        reader.Close();

        //Console.WriteLine(File.ReadLines(path + file).ElementAt(2));
        Console.ReadKey();
    }
}