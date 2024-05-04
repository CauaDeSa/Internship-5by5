namespace Ex22_StackQueueReport
{
    internal class MyIntegerStack
    {
        MyInteger? head;
        int size;

        public MyIntegerStack() { head = null; }

        public bool IsEmpty() { return head == null; }

        public int GetSize() { return size; }

        public void Push(MyInteger newInteger)
        {
            newInteger.SetNext(head);
            this.head = newInteger;
            size++;
        }

        public MyInteger Pop()
        {
            MyInteger aux = head;

            if (!IsEmpty())
                head = head.GetNext();

            if (aux != null)
                size--;

            return aux;
        }

        public MyIntegerStack GetCopy()
        {
            MyIntegerStack copy = new MyIntegerStack();
            MyInteger walker = head;

            if (!IsEmpty())
            {
                do
                {
                    copy.Push(new MyInteger(walker.GetValue()));
                    walker = walker.GetNext();
                } while (walker != null);
            }

            return copy;
        }
    }
}