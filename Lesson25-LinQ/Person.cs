namespace Lesson25_LinQ
{
    public class Person
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Telephone { get; set; }
        public int? Age { get; set; }

        public Person() { }

        public override string? ToString() => $"Id.........: {Id}\nName.......: {Name}\nAge........: {Age}\nTelephone..: {Telephone}";
    }
}