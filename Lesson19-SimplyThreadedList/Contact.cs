namespace Lesson19_SimplyThreadedList
{
    internal class Contact
    {
        string name;
        string phone;
        Contact next;

        public Contact(string name, string phone)
        {
            this.phone = phone;
            this.name = name;
        }

        public string GetName() { return this.name; }

        public string GetPhone() { return this.phone; }

        public Contact GetNext() { return this.next; }

        public void SetNext(Contact next) { this.next = next; }

        public override string ToString()
        {
            return $"\tName: {name}\n\tPhone: {this.phone}";
        }
    }
}
