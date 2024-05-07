namespace Ex25_PhoneBook
{
    internal class PhoneList
    {
        Phone? head;
        Phone? tail;

        public PhoneList()
        {
            head = null;
            tail = null;
        }

        public bool IsEmpty() { return head == null; }

        public void Add(Phone newPhone)
        {
            if (IsEmpty())
                head = tail = newPhone;

            else
            {
                Phone walker = head;
                Phone? stalker = null;
                int compare = -1;

                do
                {
                    if (compare > 0 && walker.GetNext() != null)
                    {
                        stalker = walker;
                        walker = walker.GetNext();
                    }

                    compare = string.Compare(newPhone.GetPhoneNumber(), walker.GetPhoneNumber(), comparisonType: StringComparison.OrdinalIgnoreCase);

                } while (compare > 0 && walker.GetNext() != null);

                if (compare < 0)
                {
                    newPhone.SetNext(walker);
                    if (stalker == null)
                        head = newPhone;
                    else
                        stalker.SetNext(newPhone);
                }
                else
                {
                    if (walker.GetNext() == null)
                        tail = newPhone;
                    else
                        newPhone.SetNext(walker.GetNext());
                    walker.SetNext(newPhone);
                }
            }
        }

        public bool RemoveByPhoneNumber(string phoneNumber)
        {
            Phone? removed = null;

            if (!IsEmpty())
            {
                Phone walker = head;
                Phone? stalker = null;
                int compare = 0;

                do
                {
                    if (compare != 0 && walker.GetNext() != null)
                    {
                        stalker = walker;
                        walker = walker.GetNext();
                    }

                    compare = string.Compare(phoneNumber, walker.GetPhoneNumber(), comparisonType: StringComparison.OrdinalIgnoreCase);

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

            return removed != null;
        }

        public PhoneList GetCopy()
        {
            PhoneList copy = new PhoneList();
            Phone walker = head;

            if (!IsEmpty())
            {
                do
                {
                    copy.Add(new Phone(walker.GetPhoneNumber()));
                    walker = walker.GetNext();
                } while (walker != null);
            }

            return copy;
        }

        public override string ToString()
        {
            Phone? walker = head;
            string message = "";

            while (walker != null)
            {
                message += $"{walker}\n";
                walker = walker.GetNext();
            }

            return message;
        }
    }
}