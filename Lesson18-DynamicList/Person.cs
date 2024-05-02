namespace Lesson18_DynamicList
{
    internal class Person
    {
        string name;
        int age;
        Person? next;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
            this.next = null;
        }

        public void SetNext(Person p) { this.next = p; }

        public Person GetNext() { return this.next; }

        public string GetName() { return name; }

        public int GetAge() { return age; }

        public override string? ToString() { return $"Age: {age}"; }
    }
}