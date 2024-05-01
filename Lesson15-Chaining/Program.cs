using Lesson15_Chaining;

internal class Program
{
    private static void Main(string[] args)
    {
        Address address = new Address("14805-253", "Araraquara", "Sao Paulo", "Dr Jose Augusto", "Rua", "Maria Luiza", 725, "");
        Person person = new Person("Caua", 19, address);

        Console.WriteLine(person.ToString());
    }
} 