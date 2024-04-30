using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Number of persons to register: ");
        int personQuantity = int.Parse(Console.ReadLine());
        Person[] persons = new Person[personQuantity];

        do
        {
            persons[--personQuantity] = RegisterPerson();

            Console.WriteLine("\nPress enter to continue...");
            Console.ReadKey();
        } while (personQuantity > 0);

        Console.Clear();

        for (int person = 0; person < persons.Length; person++)
        {
            Console.WriteLine($"\n----- {persons[person].Name} {persons[person].SecondName} Info -----");
            persons[person].ShowData();
        }

        Person RegisterPerson()
        {
            Console.Clear();
            Person person = new Person();

            Console.WriteLine($"\n----- Register -----");
            person = new Person();

            Console.Write("Type name: ");
            person.setName(Console.ReadLine());

            Console.Write("Type second name: ");
            person.setSecondName(Console.ReadLine());

            Console.Write("Type age: ");
            person.setAge(int.Parse(Console.ReadLine()));

            Console.Write("Type telephone: ");
            person.setTelephone(Console.ReadLine());

            Console.Write("Type cellPhone: ");
            person.setCellPhone(Console.ReadLine());

            Console.Write("Type email: ");
            person.setEmail(Console.ReadLine());

            return person;
        }
    }

}