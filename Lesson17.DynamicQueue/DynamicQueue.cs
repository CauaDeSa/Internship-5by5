using System.Runtime.Intrinsics.X86;

namespace Lesson17_DynamicQueue
{
    internal class DynamicQueue
    {
        Person? head;
        Person? tail;

        public DynamicQueue ()
        {
            this.head = null;
            this.tail = null;
        }

        private bool IsEmpty()
        {
            return head == null;
        }

        public void Insert(Person p)
        {
            if (IsEmpty())
                head = p;
            else
                tail.SetNext(p);

            tail = p;
        }

        public Person Remove()
        {
            Person? removed = head;

            if (IsEmpty())
                tail = null;
            else
                head = head.GetNext();
            
            return removed;
        }

        public void ShowAll()
        {
            Person aux = head;

            Console.WriteLine();

            do
            {
                if (aux != null)
                {
                    Console.WriteLine($"\t\t{aux}");
                    aux = aux.GetNext();
                }
                else
                    Console.WriteLine();
            } while (aux != null);
        }
    }
}