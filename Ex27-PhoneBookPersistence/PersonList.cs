namespace Ex27_PhoneBookPersistence
{
    internal class PersonList
    {
        List<Person> list;

        public PersonList()
        {
            list = new List<Person>();
        }

        public bool IsEmpty() { return list.Count == 0; }

        public bool Add(Person newPerson)
        {
            if (!list.Contains(newPerson))
            {
                list.Add(newPerson);
                return true;
            }

            return false;
        }

        public bool Remove(Person person)
        {
            if (list.Contains(person))
            {
                list.Remove(person);
                return true;
            }

            return false;
        }

        public bool Update(Person oldPerson, Person newPerson)
        {
            if (list.Contains(oldPerson))
            {
                list.Remove(oldPerson);
                list.Add(newPerson);
                return true;
            }

            return false;
        }

        public Person? GetByName(string name)
        {
            foreach (var person in list)
            {
                if (person.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                    return person;
            }

            return null;
        }

        public Person? GetByIndex(int index)
        {
            int count = 0;

            foreach (var person in list)
            {
                if (count++ == index)
                    return person;
            }

            return null;
        }

        public Person? GetById(int id)
        {
            if (list.Count != 0)
            {
                foreach (var person in list)
                {
                    if (person.Id == id)
                        return person;
                }
            }

            return null;
        }

        public List<Person> GetAll()
        {
            return list;
        }
    }
}