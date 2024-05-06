namespace Lesson19_SimplyThreadedList
{
    internal class ContactList
    {
        Contact? head;
        Contact? tail;

        public ContactList()
        {
            head = null;
            tail = null;
        }

        public bool IsEmpty() { return head == null; }

        public void Add(Contact newContact)
        {
            if (IsEmpty())
                head = tail = newContact;

            else
            {
                Contact walker = head;
                Contact? stalker = null;
                int compare = -1;

                do
                {
                    if (compare > 0 && walker.GetNext() != null)
                    {
                        stalker = walker;
                        walker = walker.GetNext();
                    }
                    
                    compare = string.Compare(newContact.GetName(), walker.GetName(), comparisonType: StringComparison.OrdinalIgnoreCase);

                } while (compare > 0 && walker.GetNext() != null);
                
                if (compare < 0)
                {
                    newContact.SetNext(walker);
                    if (stalker == null)
                        head = newContact;
                    else
                        stalker.SetNext(newContact);
                }
                else
                {
                    if (walker.GetNext() == null)
                        tail = newContact;
                    else
                        newContact.SetNext(walker.GetNext());
                    walker.SetNext(newContact);
                }
            }
        }

        public Contact RemoveByName(string name)
        {
            Contact? removed = null;

            if (!IsEmpty())
            {
                Contact walker = head;
                Contact? stalker = null;
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

        public void Show()
        {
            Contact walker = head;

            Console.WriteLine($"\tHead: {head.GetName()}\n");

            while (walker != null)
            {
                Console.WriteLine(walker.ToString() + "\n");
                walker = walker.GetNext();
            }

            Console.WriteLine($"\n\tTail: {tail.GetName()}");
        }
    }
}