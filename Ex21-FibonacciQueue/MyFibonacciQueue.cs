namespace Ex21_FibonacciQueue
{
    internal class MyFibonacciQueue
    {
        MyFibonacci? head;
        MyFibonacci? tail;

        public MyFibonacciQueue()
        {
            this.head = null;
            this.tail = null;
        }

        public bool IsEmpty() { return head == null; }

        public void Insert(MyFibonacci p)
        {
            if (IsEmpty())
                head = p;
            else
                tail.SetNext(p);

            tail = p;
        }

        public MyFibonacci Remove()
        {
            MyFibonacci? removed = head;

            if (IsEmpty())
                tail = null;
            else
                head = head.GetNext();

            return removed;
        }
    }
}