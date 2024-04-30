namespace Lesson14.Encapsulation;

internal class Program
{
    private static Person RegisterPerson()
    {
        string name, address, sex, phone;
        double salary;
        DateOnly birthDate;

        Console.WriteLine("\n------- Register -------\n");

        Console.Write($"Type name: ");
        name = Console.ReadLine();


        Console.Write($"Type address: ");
        address = Console.ReadLine();


        Console.Write($"Type sex: ");
        sex = Console.ReadLine();

        Console.Write($"Type phone: ");
        phone = Console.ReadLine();

        Console.Write($"Type salary: R$ ");
        salary = double.Parse(Console.ReadLine());

        Console.Write($"Type birth date: ");
        birthDate = DateOnly.Parse(Console.ReadLine());
        
        return new Person(name, address, sex, phone, salary, birthDate);
    }
    private static void Main(string[] args)
    {
        Person[] persons = new Person[2];

        for (int index = 0; index < persons.Length; index++)
            persons[index] = RegisterPerson();

        for (int index = 0; index < persons.Length; index++)
            persons[index].ShowPerson();

        Console.ReadKey();
    }
}