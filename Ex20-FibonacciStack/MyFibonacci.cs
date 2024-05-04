namespace Ex20_FibonacciStack
{
    internal class MyFibonacci
    {
        int value;
        MyFibonacci? next;

        public MyFibonacci(int value)
        {
            this.value = value;
            next = null;
        }

        public MyFibonacci GetNext()
        {
            return next;
        }

        public void SetNext(MyFibonacci value)
        {
            next = value;
        }

        public int GetValue()
        {
            return value;
        }

        public override string ToString()
        {
            return $"Fibonacci: {value}";
        }
    }
}
