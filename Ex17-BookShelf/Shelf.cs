namespace Ex17.BookShelff
{
    internal class Shelf
    {
        Book[] books = new Book[10];
        int bookCount = -1;

        public Shelf() { }

        public int GetStoredQuantity() { return bookCount; }

        public bool IsFull() { return bookCount == 9; }

        public bool IsEmpty() { return bookCount == -1; }

        private bool HasIndex(int index) { return bookCount >= index && index > -1; }

        public bool AddBook(Book b)
        {
            if (books != null && bookCount < 9)
            {
                books[++bookCount] = b;
                return true;
            }

            return false;
        }

        public Book GetBookByIndex(int position)
        {
            if (HasIndex(position))
                return books[position];
            return null;
        }

        public bool UpdateBook(int position, Book updated)
        {
            if (HasIndex(position))
            {
                books[position] = updated;
                return true;
            }
            return false;
        }

        public bool RemoveBook(int position)
        {
            if (HasIndex(position))
            {
                while (position < bookCount)
                    books[position++] = books[position];

                bookCount--;
                return true;
            }
            return false;
        }

        public void ShowBooks()
        {
            if (!IsEmpty())
            {
                Console.WriteLine($"\n-------------- Shelf --------------");
                for (int position = 0; position <= bookCount; position++)
                {
                    Console.WriteLine($"\n       Book {position + 1}");
                    books[position].ShowInfo();
                }
            }
            else
                Console.WriteLine("The shelf is empty!");
        }
    }
}