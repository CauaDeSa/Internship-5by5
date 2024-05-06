using System.Diagnostics;
using System.Drawing;

namespace Ex25_PhoneBook
{
    internal class PersonList
    {
        Person? head;
        Person? tail;

        public PersonList()
        {
            head = null;
            tail = null;
        }

        public bool IsEmpty() { return head == null; }

        public bool Add(Person newPerson)
        {
            int compare = -1;

            if (IsEmpty())
                head = tail = newPerson;

            else
            {
                Person walker = head;
                Person? stalker = null;

                do
                {
                    if (compare > 0 && walker.GetNext() != null)
                    {
                        stalker = walker;
                        walker = walker.GetNext();
                    }

                    compare = string.Compare(newPerson.GetName(), walker.GetName(), comparisonType: StringComparison.OrdinalIgnoreCase);

                } while (compare > 0 && walker.GetNext() != null);

                if (compare < 0)
                {
                    newPerson.SetNext(walker);
                    if (stalker == null)
                        head = newPerson;
                    else
                        stalker.SetNext(newPerson);
                }
                else if (compare > 0)
                {
                    if (walker.GetNext() == null)
                        tail = newPerson;
                    else
                        newPerson.SetNext(walker.GetNext());
                    walker.SetNext(newPerson);
                }
            }

            return compare != 0;
        }

        public Person Remove()
        {
            Person aux = head;

            if (!IsEmpty())
            {
                head = head.GetNext();
            }

            return aux;
        }

        public Person RemoveByName(string name)
        {
            Person? removed = null;

            if (!IsEmpty())
            {
                Person walker = head;
                Person? stalker = null;
                int compare = 0;

                do
                {
                    if (compare != 0 && walker.GetNext() != null)
                    {
                        stalker = walker;
                        walker = walker.GetNext();
                    }

                    compare = string.Compare(name, walker.GetName(), comparisonType: StringComparison.OrdinalIgnoreCase);

                } while (compare != 0 && walker.GetNext() != null);

                if (compare == 0)
                {
                    removed = walker;

                    if (walker.GetNext() == null)
                        tail = stalker;
                    if (stalker == null)
                        head = walker.GetNext();
                    else
                        stalker.SetNext(walker.GetNext());
                }
            }

            return removed;
        }

        public Person GetByName(string name)
        {
            Person? aux = null;

            if (!IsEmpty())
            {
                Person walker = head;
                Person? stalker = null;
                int compare = 0;

                do
                {
                    if (compare != 0 && walker.GetNext() != null)
                    {
                        stalker = walker;
                        walker = walker.GetNext();
                    }

                    compare = string.Compare(name, walker.GetName(), comparisonType: StringComparison.OrdinalIgnoreCase);

                } while (compare != 0 && walker.GetNext() != null);

                if (compare == 0)
                    aux = walker;
            }

            return aux;
        }

        public PersonList GetCopy()
        {
            PersonList copy = new PersonList();
            Person walker = head;

            if (!IsEmpty())
            {
                do
                {
                    copy.Add(new Person(walker.GetName(), walker.GetEmail(), walker.GetPhones(), walker.GetAddress()));
                    walker = walker.GetNext();
                } while (walker != null);
            }

            return copy;
        }

        public override string ToString()
        {
            Person? walker = head;
            string message = "";

            while (walker != null)
            {
                message += $"\n{walker}";
                walker = walker.GetNext();
            }

            return message;
        }
    }
}