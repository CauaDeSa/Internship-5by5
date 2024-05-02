namespace Lesson18_DynamicList
{
    internal class DynamicList
    {
        Person? head;
        Person? tail;

        public DynamicList()
        {
            head = null;
            tail = null;
        }

        public bool IsEmpty()
        {
            return head == null;
        }

        public void Add(Person newPerson)
        {
            Person walker = head;
            Person stalker = null;

            if (IsEmpty()) 
            {
                head = tail = newPerson;
            }

            else
            {
                while (newPerson.GetAge() > walker.GetAge() && walker.GetNext() != null)
                {
                    stalker = walker;
                    walker = walker.GetNext();
                }

                if (newPerson.GetAge() < walker.GetAge())
                {
                    newPerson.SetNext(walker);

                    if(stalker == null)
                        head = newPerson;
                    else
                        stalker.SetNext(newPerson);
                }
                else
                {
                    newPerson.SetNext(walker.GetNext());
                    walker.SetNext(newPerson);
                }
            }
        }

        public Person Remove()
        {
            Person? removed = head;

            if (IsEmpty())
                tail = null;
            else
                head = head.GetNext();

            return removed;
        }

        public void Show()
        {
            Person walker = head;

            while (walker != null) 
            {
                Console.WriteLine(walker);
                walker = walker.GetNext();
            }
        }
    }
}
