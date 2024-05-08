namespace Ex27_PhoneBookPersistence
{
    internal class ObjectByNameComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
}