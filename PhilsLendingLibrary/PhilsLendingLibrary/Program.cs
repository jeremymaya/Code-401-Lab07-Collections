using System;
using PhilsLendingLibrary.Classes;

namespace PhilsLendingLibrary
{
    public enum Genre
    {
        Fiction,
        Novel,
        NonFiction,
        ScienceFiction,
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
            ViewBooks();

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
