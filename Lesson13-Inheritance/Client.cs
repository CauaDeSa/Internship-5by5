namespace Lesson13.Inheritance
{
    internal class Client : Person
    {
        private int account;

        public Client(Person p)
        {
            SetName(p.name);
            SetAddress(p.address);
            SetSex(p.sex);
            SetPhone(p.phone);
            SetSalary(p.salary);
        }

        public void SetAccount(int account)
        {
            this.account = account;
        }

        public int GetAccount()
        {
            return this.account;
        }

        public void ShowClient()
        {
            ShowPerson();
            Console.WriteLine($" Account:    {this.account}");
        }
    }
}