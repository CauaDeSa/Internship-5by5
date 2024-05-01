
namespace Lesson16_DynamicStack
{
    internal class DynamicStack
    {
        Book head;
        int counter;

        public DynamicStack() 
        { 
            head = null;
            counter = 0;
        }

        public void Push(Book book)
        {
            counter++;
            book.SetNext(head);
            this.head = book;
        }

        public Book Pop()
        {
            Book aux = head;

            if (!IsEmpty())
            {
                counter--;
                head = head.GetNext();
            }

            return aux;
        }

        public int GetCounter() { return  counter; }

        public bool IsEmpty() { return head == null; }

        public int PopById(string title)
        {
            Book walker = head;
            int finded = 0;

            if (!IsEmpty())
            {
                do
                {
                    if (walker.GetTitle() == title)
                        finded++;
                    walker = walker.GetNext();
                } while (walker != null);
            }

            return finded;
        }
    }
}