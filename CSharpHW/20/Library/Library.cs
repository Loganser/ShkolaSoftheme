using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    static class Library
    {
        static public List<Literature> books = new List<Literature>();
        static HashSet<string> users = new HashSet<string>();
        static public Dictionary<Literature, string> journal = new Dictionary<Literature, string>();

        static public void Update_journal(Literature book)
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
            var pop_book = from book in books
                               orderby book.pop_index descending
                               select book;
            var fresh_book = from book in books
                           orderby book.year descending
                           select book;
            var oldest_book = from book in books
                             orderby book.year
                             select book;
            List<Book> books1 = new List<Book>();
            foreach (var book in books)
            {
                var book1 = book as Book;
                if (book1 != null) books1.Add(book1);
            }

                foreach (var line in books1.GroupBy(book => book.genre)
                            .Select(group => new {
                                Genre = group.Key,
                                Count = group.Sum(c => c.count)
                            })
                            .OrderBy(x => x.Genre))
                {
                    Console.WriteLine("The number of books of " + line.Genre.ToString() + " genre: " + line.Count);
                }
            
            
            Console.WriteLine();
            Console.WriteLine("The most fresh book is: " + fresh_book.First().title);
            Console.WriteLine("The oldest book is: " + oldest_book.First().title);
            if (pop_book.First().pop_index == 0)
                Console.WriteLine("One of he most popular books is: no popular books yet");
            else
                Console.WriteLine("One of he most popular books is:" + pop_book.First().title);
        }

        static public void Add_book(Literature book)
        {
            for (int i = 0; i < books.Count; ++i)
            {
                var book1 = books[i] as Book;
                if (book.title == books[i].title && book.author_name == books[i].author_name /*&& book1 != null && book.genre == book1.genre */     //for books only
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
            List<Book> books1 = new List<Book>();
            foreach (var book in books)
            {
                var book1 = book as Book;
                if (book1 != null) books1.Add(book1);
            }
            var result = books1
                .GroupBy(b => b.genre)
                .Select(x => new
                {
                    Book = x.First(),
                    Genre = x.Key,
                    Count = x.Sum(c => c.pop_index)
                }).OrderByDescending(xb => xb.Count ) ;

            if (result.First().Count == 0) return null;
            return result.First().Book;
        }

        static public bool Check_book(string title, string author, int checker)
        {
            switch(checker)
            {
                case 1:
                    var res_book = from book in books
                                   where book.title == title
                                   select book;
                    if (res_book.Count() > 0) return true;
                    break;
                case 2:
                    res_book = from book in books
                                   where book.author_name == author
                                   select book;
                    if (res_book.Count() > 0) return true;
                    break;
                case 3:
                    res_book = from book in books
                               where book.author_name == author & book.title == title
                               select book;
                    if (res_book.Count() > 0) return true;
                    break;
            }
            
                return false;
        }

    }
}
