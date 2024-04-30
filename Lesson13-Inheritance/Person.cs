internal class Person
{
    public string name;
    public string address;
    public string sex;
    public string phone;
    public double salary;
    public DateOnly bornDate;

    public Person() { }

    public void SetName(string name)
    {
        this.name = name;
    }

    public void SetAddress(string address)
    {
        this.address = address;
    }

    public void SetSex(string sex)
    {
        this.sex = sex;
    }

    public void SetPhone(string phone)
    {
        this.phone = phone;
    }

    public void SetSalary(double salary)
    {
        this.salary = salary;
    }

    public void SetBornDate(DateOnly bornDate)
    {
        this.bornDate = bornDate;
    }

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