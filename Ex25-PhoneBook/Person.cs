namespace Ex25_PhoneBook
{
    internal class Person
    {
        string name;
        PhoneList phones;
        Address address;
        string email;
        Person? Next;

        public Person(string name, string email, PhoneList phones, Address address)
        {
            this.name = name;
            this.email = email;
            this.phones = phones;
            this.address = address;
        }

        public string GetName() { return name; }

        public Person GetNext() { return this.Next; }

        public PhoneList GetPhones() { return this.phones; }

        public Address GetAddress() { return this.address; }

        public string GetEmail() { return this.email; }

        public void SetNext(Person next) { this.Next = next; }

        public void SetName(string name) { this.name = name; }

        public void SetEmail(string email) { this.email = email; }

        public void AddPhoneNumber(Phone newPhone) { phones.Add(newPhone); }

        public bool RemovePhoneNumber(String phone) { return phones.RemoveByPhoneNumber(phone); }

        public override string? ToString()
        {
            return "\n       Person Info          \n" +
                  $"\nName..............: {this.name}" +
                  $"\nEmail.............: {this.email} " +
                $"\n\n         Phones               \n" +
                    phones.ToString();
        }
    }
}