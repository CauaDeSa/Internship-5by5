namespace Ex22_StackQueueReport
{
    internal class MyInteger
    {
        int value;
        MyInteger? next;

        public MyInteger(int value)
        {
            this.value = value;
            next = null;
        }

        public MyInteger? GetNext()
        {
            return next;
        }

        public void SetNext(MyInteger value)
        {
            next = value;
        }

        public int GetValue()
        {
            return value;
        }

        public override string ToString()
        {
            return $"Number: {value}";
        }
    }
}
