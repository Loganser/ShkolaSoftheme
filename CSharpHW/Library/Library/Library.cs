using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    static class Library
    {
        static public List<Book> books = new List<Book>();
        static HashSet<string> users = new HashSet<string>();
        static public Dictionary<Book, string> journal = new Dictionary<Book, string>();

        static public void Update_journal(Book book)
        {
            if (!journal.ContainsKey(book))
            {
                journal.Add(book, book.last_taken_by);
            }
            else
            {
                journal[book] = book.last_taken_by;
            }
        }

        static public void Show_info()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("No books in the library!");
            }
            Dictionary<Genre, int> c_by_genres = new Dictionary<Genre, int>();
            c_by_genres.Add(Genre.classic, 0);
            c_by_genres.Add(Genre.drama, 0);
            c_by_genres.Add(Genre.humor, 0);
            Book fresh_book = books[0];
            int fresh_year = int.MinValue;
            Book old_book = books[0];
            int old_year = int.MaxValue;
            Book pop_book = books[0];
            int pop_index = int.MinValue;

            foreach (Book book in books)
            {
                if (book.year > fresh_year)
                {
                    fresh_year = book.year;
                    fresh_book = book;
                } else
                {
                    old_year = book.year;
                    old_book = book;
                }

                if (book.pop_index > pop_index)
                {
                    pop_index = book.pop_index;
                    pop_book = book;
                }

                c_by_genres[book.genre] += book.count;
            }
            foreach (Genre genre in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("The number of books of "+ genre.ToString()+" genre: " + c_by_genres[genre]);
            }
            Console.WriteLine();
            Console.WriteLine("The most fresh book is: " + fresh_book.title);
            Console.WriteLine("The oldest book is: " + old_book.title);
            if (pop_index > 0)
                Console.WriteLine("One of he most popular books is: " + pop_book.title);
            else
                Console.WriteLine("One of he most popular books is: No popular books yet");
        }

        static public void Add_book(Book book)
        {
            for (int i = 0; i < books.Count; ++i)
            {
                if (book.title == books[i].title && book.author_name == books[i].author_name && book.genre == books[i].genre
                    && book.year == books[i].year && book.pages == books[i].pages)
                {
                    books[i].count += book.count;
                    return;
                }
            }
            Update_journal(book);
            books.Add(book);
        }



        static public bool Is_user(string login)
        {
            return users.Contains(login);
        }

        static public void Add_user(string login)
        {
            users.Add(login);
        }

        static public Book Find_pop_book_in_genre(Genre book_genre)
        {
            Book pop_book = null;
            int pop_index = int.MinValue;
            foreach (Book book in books)
            {
                if (book.genre == book_genre && book.pop_index > pop_index)
                {
                    pop_book = book;
                    pop_index = book.pop_index;
                }
            }
            if (pop_index == 0) return null;
            return pop_book;
        }

        static public bool Check_book(string title, string author, int checker)
        {
            bool res1, res2;
            foreach (Book book in books)
            {
                res1 = false;
                res2 = false;
                if ((checker & 1) == 1)
                {
                    if (book.title == title)
                        res1 = true;
                }
                else res1 = true;
                if ((checker & 2) == 2)
                {
                    if (book.author_name == author)
                        res2 = true;
                }
                else res2 = true;
                if (res1 && res2) return true;
            }
                return false;
        }

    }
}
