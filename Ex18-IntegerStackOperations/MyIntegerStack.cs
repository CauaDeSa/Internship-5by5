﻿namespace Ex18_IntegerStackOperations
{
    internal class MyIntegerStack
    {
        MyInteger? head;
        int size;

        public MyIntegerStack()
        {
            head = null;
            size = 0;
        }

        public void Push(MyInteger newInteger)
        {
            size++;
            newInteger.SetNext(head);
            this.head = newInteger;
        }

        public MyInteger Pop()
        {
            MyInteger aux = head;

            if (!IsEmpty())
            {
                size--;
                head = head.GetNext();
            }

            return aux;
        }

        public int GetSize() { return size; }

        public bool IsEmpty() { return head == null; }

        public MyInteger GetMinor()
        {
            MyInteger aux = head;
            MyInteger finded = null;

            if (!IsEmpty())
            {
                finded = head;
                do
                {
                    if (aux.GetValue() < finded.GetValue())
                        finded = aux;
                    aux = aux.GetNext();
                } while (aux != null);
            }

            return finded;
        }

        public MyInteger GetBigger()
        {
            MyInteger aux = head;
            MyInteger finded = null;

            if (!IsEmpty())
            {
                finded = head;
                do
                {
                    if (aux.GetValue() > finded.GetValue())
                        finded = aux;
                    aux = aux.GetNext();
                } while (aux != null);
            }

            return finded;
        }

        public int GetArithmeticMean()
        {
            MyInteger walker = head;
            int mean = 0;

            if (!IsEmpty())
            {
                do
                {
                    mean += walker.GetValue();

                    walker = walker.GetNext();
                } while (walker != null);

                mean /= size;
            }

            return mean;
        }
    }
}