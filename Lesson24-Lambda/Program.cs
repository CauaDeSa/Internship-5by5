using Lesson24_Lambda;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Person> personList = new()
        {
            new Person(1, "Caua"),
            new Person(2, "Pedro")
        };

        if (personList.Exists((p => p.Name == "Caua")))
            Console.WriteLine("Found!");
        else
            Console.WriteLine("Not found!");
    }
}