namespace Ex23_StudentsGrades
{
    internal class GradesQueue
    {
        Grade? head;
        Grade? tail;

        public GradesQueue()
        {
            this.head = null;
            this.tail = null;
        }

        public bool IsEmpty() { return head == null; }

        public void Insert(Grade p)
        {
            if (IsEmpty())
                head = p;
            else
                tail.SetNext(p);

            tail = p;
        }

        public Grade Remove()
        {
            Grade? removed = head;

            if (IsEmpty())
                tail = null;
            else
                head = head.GetNext();

            return removed;
        }

        public GradesQueue GetCopy()
        {
            GradesQueue copy = new GradesQueue();
            Grade walker = head;

            if (!IsEmpty())
            {
                do
                {
                    copy.Insert(new Grade(walker.GetGrade(), walker.GetId()));
                    walker = walker.GetNext();
                } while (walker != null);
            }

            return copy;
        }
    }
}