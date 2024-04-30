namespace Lesson13.Inheritance
{
    internal class Employee : Person
    {
        string position;
        int identifier;

        public Employee(Person p)
        {
            SetName(p.name);
            SetAddress(p.address);
            SetSex(p.sex);
            SetPhone(p.phone);
            SetSalary(p.salary);
        }

        public void SetPosition(string position) { this.position = position; }

        public void SetIdentifier(int identifier) { this.identifier = identifier; }

        public void ShowEmployee()
        {
            ShowPerson();
            Console.WriteLine($" Position:   {this.position}");
            Console.WriteLine($" Identifier: {this.identifier}");
        }
    }
}