namespace Ex19_IntegerQueueOperations
{
    internal class MyIntegerQueue
    {
        MyInteger head;
        MyInteger tail;
        string type;
        int size;

        public MyIntegerQueue(string type)
        {
            this.head = null;
            this.tail = null;
            this.type = type;
            this.size = 0;
        }

        public bool IsEmpty() { return head == null; }

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
            {
                size--;
                head = head.GetNext();
            }
            else 
                tail = null;

            return removed;
        }

        public int GetSize() { return size; }

        public string GetType() { return type; }

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
                    if ((param == 1) && current.GetValue() % 2 != 0)
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