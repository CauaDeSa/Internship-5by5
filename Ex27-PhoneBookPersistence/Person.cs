namespace Ex27_PhoneBookPersistence
{
    internal class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public PhoneList Phones { get; set; }
        public Address Address { get; set; }
        public Person? Next { get; set; }

        public Person(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
            Phones = new();
            Address = new();
            Next = null;
        }

        public Person(int id, string name, string email, PhoneList phones, Address address)
        {
            Id = id;
            Name = name;
            Email = email;
            Phones = phones;
            Address = address;
            Next = null;
        }

        public string FormatToSave()
        {
            return $"{Id};{Name};{Email}";
        }

        public override string? ToString()
        {
            return "\n\t\t\t-------Person Info-------\n" +
                  $"\n\t\t\tName..............: {Name}" +
                  $"\n\t\t\tEmail.............: {Email} ";
        }
    }
}