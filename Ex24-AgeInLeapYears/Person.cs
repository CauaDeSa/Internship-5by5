namespace Ex24_AgeInLeapYears
{
    internal class Person
    {
        string name;
        int yearOfBirth;
        string profession;

        public Person(string name, int age, string profession)
        {
            this.name = name;
            yearOfBirth = DateTime.Now.Year - age;
            this.profession = profession;
        }

        public string GetName() { return this.name; }

        public int GetYearOfBirth() { return this.yearOfBirth; }

        public int GetAge() { return DateTime.Now.Year - yearOfBirth; }

        public string GetProfession() {  return this.profession; }

        public override string ToString() { return $"\n\t\tName........: {name}\n\t\tAge.........: {GetAge()}\n\t\tProfession..: {profession}\n"; }
    }
}
