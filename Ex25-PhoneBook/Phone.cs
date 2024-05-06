using System.Xml.Linq;

namespace Ex25_PhoneBook
{
    internal class Phone
    {
        string phoneNumber;
        Phone? Next;

        public Phone(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
            Next = null;
        }

        public string GetPhoneNumber() { return this.phoneNumber; }

        public Phone GetNext() { return this.Next; }

        public void SetNext(Phone Next) { this.Next = Next; }

        public override string ToString() { return $"\n\t\t\t   Phone number: {this.phoneNumber}"; }
    }
}