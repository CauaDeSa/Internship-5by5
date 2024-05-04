namespace Ex20_FibonacciStack
{
    internal class MyFibonacciStack
    {
        MyFibonacci? head;
        int size;

        public MyFibonacciStack()
        {
            head = null;
            size = 0;
        }

        public void Push(MyFibonacci fibonacci)
        {
            size++;
            fibonacci.SetNext(head);
            this.head = fibonacci;
        }

        public MyFibonacci Pop()
        {
            MyFibonacci aux = head;

            if (!IsEmpty())
            {
                size--;
                head = head.GetNext();
            }

            return aux;
        }

        public int GetSize() { return size; }

        public bool IsEmpty() { return head == null; }
    }
}
