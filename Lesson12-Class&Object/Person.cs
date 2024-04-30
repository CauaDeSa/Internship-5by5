internal class Person
{
    public string Name;
    public string SecondName;
    public int Age;
    public string Telephone;
    public string CellPhone;
    public string Email;

    public void setName(string name)
    {
        this.Name = name;
    }

    public void setSecondName(string secondName)
    {
        this.SecondName = secondName;
    }

    public void setAge(int age)
    {
        this.Age = age;
    }

    public void setTelephone(string telephone)
    {
        this.Telephone = telephone;
    }

    public void setCellPhone(string cellPhone)
    {
        this.CellPhone = cellPhone;
    }

    public void setEmail(string email)
    {
        this.Email = email;
    }

    public void ShowData()
    {
        Console.WriteLine($" Age:       {this.Age}");
        Console.WriteLine($" Telephone: {this.Telephone}");
        Console.WriteLine($" Cellphone: {this.CellPhone}");
        Console.WriteLine($" Email:     {this.Email}");
    }
}