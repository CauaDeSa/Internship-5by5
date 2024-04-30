namespace Lesson14.Encapsulation
{
    internal class Person
    {
        string name;
        string address;
        string sex;
        string phone;
        double salary;
        DateOnly bornDate;

        public Person(string name, string address, string sex, string phone, double salary, DateOnly bornDate)
        {
            this.name = name;
            this.address = address;
            this.sex = sex; 
            this.phone = phone;
            this.salary = salary;
            this.bornDate = bornDate;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetName() { return this.name; }

        public void SetAddress(string address)
        {
            this.address = address;
        }

        public string GetAddress() { return this.address; }

        public void SetSex(string sex)
        {
            this.sex = sex;
        }

        public string GetSex() { return this.sex; }

        public void SetPhone(string phone)
        {
            this.phone = phone;
        }

        public string GetPhone() { return this.phone; }

        public void SetSalary(double salary)
        {
            this.salary = salary;
        }

        public double GetSalary() { return this.salary; }

        public void SetBornDate(DateOnly bornDate)
        {
            this.bornDate = bornDate;
        }

        public DateOnly GetBornDate() { return this.bornDate; }

        public void ShowPerson()
        {
            Console.WriteLine("\n--------- Info ---------\n");

            Console.WriteLine($" Name:       {this.name}");
            Console.WriteLine($" Address:    {this.address}");
            Console.WriteLine($" Sex:        {this.sex}");
            Console.WriteLine($" Phone:      {this.phone}");
            Console.WriteLine($" Salary:     {this.salary}");
            Console.WriteLine($" Born Date:  {this.bornDate}");
        }
    }
}