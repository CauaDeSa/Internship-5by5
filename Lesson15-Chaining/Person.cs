namespace Lesson15_Chaining
{
    internal class Person
    {
        string name;
        int age;
        Address address;

        public Person(string name, int age, Address address)
        {
            this.name = name;
            this.age = age;
            this.address = address;
        }

        public override string? ToString()
        {
            return "\n       Person Info         \n\n"+
                   $"Name..............: {this.name}\n" +
                   $"Age...............: {this.age}" +
                   address.ToString();
        }
    }
}