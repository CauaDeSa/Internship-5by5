internal class Program
{
    private static void Main(string[] args)
    {
        List<string> list = new();

        list.Sort();

        Console.WriteLine(list.FirstOrDefault("null"));
    }
} 