namespace Lesson16_DynamicStack
{
    internal class Book
    {
        string title;
        Book next;

        public Book(string title)
        {
            this.title = title;
            this.next = null;
        }

        public void SetNext(Book b) { this.next = b; }

        public Book GetNext() { return this.next;}

        public string GetTitle() { return title; }

        public override string? ToString()
        {
            return $"Livro: {title}";
        }
    }
}