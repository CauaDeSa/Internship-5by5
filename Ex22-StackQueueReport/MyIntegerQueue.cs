namespace Ex22_StackQueueReport
{
    internal class MyIntegerQueue
    {
        MyInteger? head;
        MyInteger? tail;
        int size;

        public MyIntegerQueue()
        {
            this.head = null;
            this.tail = null;
            size = 0;
        }

        public bool IsEmpty() { return head == null; }

        public int GetSize() { return size; }

        public void Insert(MyInteger p)
        {
            if (!IsEmpty())
            {
                tail.SetNext(p);
            }
            else
                head = p;

            size++;
            tail = p;
        }

        public MyInteger Remove()
        {
            MyInteger? removed = head;

            if (!IsEmpty())
                head = head.GetNext();

            else
                tail = null;

            size--;
            return removed;
        }

        public MyIntegerQueue GetCopy()
        {
            MyIntegerQueue copy = new MyIntegerQueue();
            MyInteger walker = head;

            if (!IsEmpty())
            {
                do
                {
                    copy.Insert(new MyInteger(walker.GetValue()));
                    walker = walker.GetNext();
                } while (walker != null);
            }

            return copy;
        }
    }
}
