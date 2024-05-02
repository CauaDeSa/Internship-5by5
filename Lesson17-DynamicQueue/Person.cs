namespace Lesson17_DynamicQueue
{
    internal class Person
    {
        string name;
        Person? next;

        public Person(string name)
        {
            this.name = name;
            this.next = null;
        }

        public void SetNext(Person p) { this.next = p; }

        public Person GetNext() { return this.next; }

        public string GetName() { return name; }

        public override string? ToString()
        {
            return $"Nome: {name}";
        }
    }
}