using Ex17.BookShelff;
using System;

internal class Program
{
    static void MockData(Shelf shelf)
    {
        string[] titles = new string[4] { "Harry", "Potter", "Hobbit", "Game Of Thrones" };
        string[] authors = new string[4] { "J.K.", "Rowling", "Tolkien", "Martin" };
        string[] dates = new string[4] { "1965/07/31", "1965/07/30", "1937/09/21", "1996/08/6" };
        string[] publishers = new string[4] { "Blooms", "bury", "Allen & Unwin", "Sei la" };
        string[] editions = new string[4] { "1", "2", "3", "4" };
        string[] isbns = new string[4] { "978-0-439-02348-1", "009-0-439-02348-1", "070-439-02348-1", "800-0-439-02348-1" };
        int[] pageQuantitys = new int[4] { 310, 197, 139, 686 };

        for (int i = 0; i < 4; i++)
        {
            Book book = new Book(titles[i], authors[i], DateOnly.Parse(dates[i]), publishers[i], editions[i], isbns[i], pageQuantitys[i]);
            shelf.AddBook(book);
        }
    }

    static void ClearScreen()
    {
        Console.Clear();
        Console.WriteLine("  ____              _       _____ _          _  __ \r\n |  _ \\            | |     / ____| |        | |/ _|\r\n | |_) | ___   ___ | | __ | (___ | |__   ___| | |_ \r\n |  _ < / _ \\ / _ \\| |/ /  \\___ \\| '_ \\ / _ \\ |  _|\r\n | |_) | (_) | (_) |   <   ____) | | | |  __/ | |  \r\n |____/ \\___/ \\___/|_|\\_\\ |_____/|_| |_|\\___|_|_|  \r\n                                                   \r\n                                                   ");
    }

    static void ShowMenu()
    {
        Console.WriteLine("[0] View all books");
        Console.WriteLine("[1] Add book");
        Console.WriteLine("[2] Remove book by index");
        Console.WriteLine("[3] Update book by index");
        Console.WriteLine("[4] Exit");
    }

    static void ShowEditMenu()
    {
        ClearScreen();
        Console.WriteLine("Wich information you want to edit?\n");
        Console.WriteLine("[0] Title");
        Console.WriteLine("[1] Author");
        Console.WriteLine("[2] Release Date");
        Console.WriteLine("[3] Publisher");
        Console.WriteLine("[4] Edition");
        Console.WriteLine("[5] ISBN");
        Console.WriteLine("[6] Page quantity");
        Console.WriteLine("[7] Cancel edition");
    }

    static Book RegisterBook()
    {
        string title;
        string author;
        DateOnly releaseDate;
        string publisher;
        string edition;
        string isbn;
        int pageQuantity;

        ClearScreen();
        Console.WriteLine($"----- Book Register -----\n");

        Console.Write("Type title: ");
        title = Console.ReadLine();

        Console.Write("Type author(s) name ");
        author = Console.ReadLine();

        Console.Write("Type release release date: ");
        releaseDate = DateOnly.Parse(Console.ReadLine());

        Console.Write("Type publisher: ");
        publisher = Console.ReadLine();

        Console.Write("Type edition: ");
        edition = Console.ReadLine();

        Console.Write("Type isbn: ");
        isbn = Console.ReadLine();

        Console.Write("Type page quantity: ");
        pageQuantity = int.Parse(Console.ReadLine());

        return new Book(title, author, releaseDate, publisher, edition, isbn, pageQuantity);
    }

    private static void Main(string[] args)
    {
        int menuChoose, bookIndex;
        Shelf shelf = new Shelf();

        MockData(shelf);

        do
        {
            do
            {
                ClearScreen();
                ShowMenu();
                Console.Write("\nOption: ");
                menuChoose = int.Parse(Console.ReadLine());

            } while (menuChoose < 0 || menuChoose > 3);

            switch (menuChoose)
            {
                case 0:
                    ClearScreen();
                    shelf.ShowBooks();
                    Console.Write("\nPress any key to continue");
                    Console.ReadKey();
                    break;

                case 1:
                    shelf.AddBook(RegisterBook());
                    break;

                case 2:
                    do
                    {
                        ClearScreen();
                        Console.Write("Type the number of the book that should be removed: ");
                        bookIndex = int.Parse(Console.ReadLine()) - 1;
                    } while (bookIndex < 0 || bookIndex > 9);

                    if (shelf.RemoveBook(bookIndex))
                        Console.WriteLine("\nBook successfully removed!");
                    else
                        Console.WriteLine("\nWe can't remove a book we don't have!");

                    Console.Write("\nPress any key to continue");
                    Console.ReadKey();
                    break;

                case 3:
                    Console.Write("Type the book number to update: ");
                    bookIndex = int.Parse(Console.ReadLine());
                    Book temp = shelf.GetBookByIndex(bookIndex - 1);

                    if (temp != null)
                    {
                        do
                        {
                            ShowEditMenu();
                            Console.Write("\nOption: ");
                            menuChoose = int.Parse(Console.ReadLine());
                        } while (menuChoose < 0 || menuChoose > 7);

                        ClearScreen();

                        switch (menuChoose)
                        {
                            case 0:
                                Console.Write("New title: ");
                                temp.SetTitle(Console.ReadLine());
                                Console.WriteLine("\nSuccess!");
                                break;

                            case 1:
                                Console.Write("New author(s) name ");
                                temp.SetAuthor(Console.ReadLine());
                                Console.WriteLine("\nSuccess!");
                                break;

                            case 2:
                                Console.Write("Type release release date: ");
                                temp.SetReleaseDate(DateOnly.Parse(Console.ReadLine()));
                                Console.WriteLine("\nSuccess!");
                                break;

                            case 3:
                                Console.Write("Type publisher: ");
                                temp.SetPublisher(Console.ReadLine());
                                Console.WriteLine("\nSuccess!");
                                break;

                            case 4:
                                Console.Write("Type edition: ");
                                temp.SetEdition(Console.ReadLine());
                                Console.WriteLine("\nSuccess!");
                                break;

                            case 5:
                                Console.Write("Type isbn: ");
                                temp.SetIsbn(Console.ReadLine());
                                Console.WriteLine("\nSuccess!");
                                break;

                            case 6:
                                Console.Write("Type page quantity: ");
                                temp.SetPageQuantity(int.Parse(Console.ReadLine()));
                                Console.WriteLine("\nSuccess!");
                                break;

                            case 7:
                                Console.WriteLine("Operation cancelled!");
                                break;

                        }
                    }

                    else
                        Console.WriteLine("\nBut we don't have that book!");

                    Console.WriteLine("\nPress any key to continue");
                    Console.ReadKey();
                    break;
            }

        } while (menuChoose != 4);
    }
}