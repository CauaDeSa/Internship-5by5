namespace Ex17.BookShelff
{
    internal class Book
    {
        string title;
        string author;
        DateOnly releaseDate;
        string publisher;
        string edition;
        string isbn;
        int pageQuantity;

        public Book(string title, string author, DateOnly releaseDate, string publisher, string edition, string isbn, int pageQuantity)
        {
            this.title = title;
            this.author = author;
            this.releaseDate = releaseDate;
            this.publisher = publisher;
            this.edition = edition;
            this.isbn = isbn;
            this.pageQuantity = pageQuantity;
        }
        public void SetTitle(string title) { this.title = title; }
        public void SetAuthor(string author) { this.author = author; }
        public void SetReleaseDate(DateOnly releaseDate) { this.releaseDate = releaseDate; }
        public void SetPublisher(string publisher) { this.publisher = publisher; }
        public void SetEdition(string edition) { this.edition = edition; }
        public void SetIsbn(string isbn) { this.isbn = isbn; }
        public void SetPageQuantity(int quantity) { this.pageQuantity = quantity; }

        public void ShowInfo()
        {
            Console.WriteLine($"\nBook Title......:{this.title}");
            Console.WriteLine($"Author..........:{this.author}");
            Console.WriteLine($"Release date....:{this.releaseDate}");
            Console.WriteLine($"Publisher.......:{this.publisher}");
            Console.WriteLine($"Edition.........:{this.edition}");
            Console.WriteLine($"ISBN............:{this.isbn}");
            Console.WriteLine($"Page quantity...:{this.pageQuantity}");
        }
    }
}