namespace Lesson13.Inheritance;

internal class Program
{
    private static void Main(string[] args)
    {
        Client c1 = RegisterClient();
        c1.ShowClient();

        Employee e1 = RegisterEmployee();
        e1.ShowEmployee();

        Person RegisterPerson(String type)
        {
            Person c1 = new Person();

            Console.WriteLine("\n------- Register -------\n");

            Console.Write($"Type {type} name: ");
            c1.SetName(Console.ReadLine());


            Console.Write($"Type {type} address: ");
            c1.SetAddress(Console.ReadLine());


            Console.Write($"Type {type} sex: ");
            c1.SetSex(Console.ReadLine());

            Console.Write($"Type {type} phone: ");
            c1.SetPhone(Console.ReadLine());

            Console.Write($"Type {type} salary: R$ ");
            c1.SetSalary(double.Parse(Console.ReadLine()));

            Console.Write($"Type {type} born date: ");
            c1.SetBornDate(DateOnly.Parse(Console.ReadLine()));

            return c1;
        }

        Client RegisterClient()
        {
            Client c1 = new Client(RegisterPerson("client"));

            Console.Write("Type client account number: ");
            c1.SetAccount(int.Parse(Console.ReadLine()));

            return c1;
        }

        Employee RegisterEmployee()
        {
            Employee e1 = new Employee(RegisterPerson("employee"));

            Console.Write("Type employee identifier: ");
            e1.SetIdentifier(int.Parse(Console.ReadLine()));

            Console.Write("Type employee position: ");
            e1.SetPosition(Console.ReadLine());

            return e1;
        }
    }
}