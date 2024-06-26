﻿namespace Ex18_IntegerStackOperations
{
    internal class MyIntegerStack
    {
        MyInteger? head;
        string type;
        int size;

        public MyIntegerStack(string type)
        {
            head = null;
            size = 0;
            this.type = type;
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

        public string GetType() { return type; }

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

        private MyInteger[] filter(int param)
        {
            MyInteger current;
            MyInteger[] type = new MyInteger[size];
            int typeQuantity = 0;

            if (!IsEmpty())
            {
                current = head;
                do
                {
                    if((param == 1) && current.GetValue() % 2 != 0)
                        type[typeQuantity++] = current;

                    if ((param == 2) && current.GetValue() % 2 == 0)
                        type[typeQuantity++] = current;

                    current = current.GetNext();
                } while (current != null);
            }

            MyInteger[] fittedTypeVector = new MyInteger[typeQuantity];

            for (int index = 0, aux = typeQuantity; index < typeQuantity; index++)
                fittedTypeVector[index] = type[aux--];

            return fittedTypeVector;
        }

        public MyInteger[] GetOdds() { return filter(1); }

        public MyInteger[] GetEvens() { return filter(2); }
    }
}