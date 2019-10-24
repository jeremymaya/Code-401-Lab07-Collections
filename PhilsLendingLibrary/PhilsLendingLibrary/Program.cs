using System;
using PhilsLendingLibrary.Classes;

namespace PhilsLendingLibrary
{
    public enum Genre
    {
        Fiction = 1,
        NonFiction,
        Poetry,
        Biography,
        Romance
    }

    public class Program
    {
        public static Library<Book> Library = new Library<Book>();

        static void Main(string[] args)
        {
            LoadBooks();

            bool displayMenu = true;
            while (displayMenu)
            {
                displayMenu = UserInterface();
            }
        }

        public static bool UserInterface()
        {
            Console.Clear();
            Console.WriteLine("1. View all books");
            Console.WriteLine("2. Add a book");
            Console.WriteLine("3. Borrow a book");
            Console.WriteLine("4. Return a book");
            Console.WriteLine("5. View Book Bag");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    ViewBooks();
                    Console.WriteLine("");
                    Console.WriteLine("Press 'Enter' to continue");
                    Console.ReadLine();
                    return true;
                case "2":
                    Console.Clear();
                    Console.Write("Title: ");
                    string title = Console.ReadLine();
                    Console.Write("First Name of the author: ");
                    string firstName = Console.ReadLine();
                    Console.Write("Last Name of the auhor: ");
                    string lastName = Console.ReadLine();
                    Console.Write("Number of Pages: ");
                    string numberOfPages = Console.ReadLine();
                    Console.WriteLine("1. Fiction");
                    Console.WriteLine("2. Non-Fiction");
                    Console.WriteLine("3. Poetry:");
                    Console.WriteLine("4. Biography");
                    Console.WriteLine("5. Romance");
                    string genre = Console.ReadLine();

                    AddABook(title, firstName, lastName, Convert.ToInt32(numberOfPages), (Genre)Convert.ToInt32(genre));
                    return true;
                /*
                case "3":
                    Console.WriteLine("Enter an amount to deposit.");
                    string deposit = Console.ReadLine();
                    try
                    {
                        balance = Deposit(balance, Decimal.Parse(deposit));
                        Console.WriteLine($"Your current balance is ${balance}.");
                        return true;
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("The deposit amount you entered is too large.");
                        return true;
                    }
                */
                case "6":
                    return false;
                default:
                    Console.WriteLine("That was an invalid entry.");
                    return true;
            }
        }

        public static void ViewBooks()
        {
            foreach (var book in Library)
            {
                Console.WriteLine(book.Title);
            }
        }

        public static void LoadBooks()
        {
            AddABook("To Kill a Mockingbird", "Harper", "Lee", 296, Genre.Fiction);
            AddABook("The Diary of a Young Girl", "Anne", "Frank", 283, Genre.NonFiction);
            AddABook("Steve Jobs", "Walter", "Isaacson", 656, Genre.Biography);
            AddABook("Odyssey", "Hormer", "", 448, Genre.Poetry);
            AddABook("Pride and Prejudice", "Jane", "Austen", 401, Genre.Romance);
        }

        public static void AddABook(string title, string firstName, string lastName, int numberOfPages, Genre genre)
        {
            Book book = new Book()
            {
                Title = title,
                Author = new Author()
                {
                    FirstName = firstName,
                    LastName = lastName
                },
                NumberOfPages = numberOfPages,
                Genre = genre
            };
            Library.Add(book);
        }
        /*
        static void ReturnBook()
        {
            Dictionary<int, Book> books = new Dictionary<int, Book>();
            Console.WriteLine("Which book would you like to return");
            int counter = 1;
                foreach (var item in BookBag)
                {
                    books.Add(counter, item);
                    Console.WriteLine($"{counter++}. {item.Title} - {item.Author.FirstName} {item.Author.LastName}");

                }

            string response = Console.ReadLine();
            int.TryParse(response, out int selection);
            books.TryGetValue(selection, out Book returnedBook);
            BookBag.Remove(returnedBook);
            Library.Add(returnedBook);
        }
        */
    }
}
