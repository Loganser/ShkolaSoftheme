using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.IO;


namespace Library
{
    [Serializable]
    static class Library
    {
        public static List<Literature> books { get; private set; } = new List<Literature>();
        static HashSet<string> users = new HashSet<string>();
        public static Dictionary<Literature, string> journal = new Dictionary<Literature, string>();

        public static void Update_journal(Literature book)
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

        public static void Show_info(string xml_path)
        {
            if (books.Count == 0)
            {
                Console.WriteLine("No books in the library!");
            }
            var xmlStr = File.ReadAllText(xml_path);
            var str = XElement.Parse(xmlStr);

            string max_pop = str.Elements("Literature").Max(x => (x.Element("pop_index").Value));
            var pop_book = str.Elements("Literature").Where(x =>
            {
                var xElement = x.Element("pop_index");
                return xElement.Value.Equals(max_pop);
            }
            ).ToList();

            string max_year = str.Elements("Literature").Max(x => (x.Element("year").Value));
            string min_year = str.Elements("Literature").Min(x => (x.Element("year").Value));

            var fresh_book = str.Elements("Literature").Where(x =>
            {
                var xElement = x.Element("year");
                return xElement.Value.Equals(max_year);
            }
            ).ToList();

            var oldest_book = str.Elements("Literature").Where(x =>
            {
                var xElement = x.Element("year");
                return xElement.Value.Equals(min_year);
            }
            ).ToList();


            var books1 = str.Elements("Literature").Where(x =>
            {
                var xElement = x.Element("genre");
                return xElement != null;
            });

            var pop_books = books1.Elements("Literature").GroupBy(book => book.Element("genre").Value)              //////
                            .Select(group => new
                            {
                                Genre = group.Key,
                                Count = group.Sum(c => int.Parse(c.Element("count").Value))
                            })
                            .OrderBy(x => x.Genre).ToList();
            foreach (var line in pop_books)
            {
                Console.WriteLine("The number of books of " + line.Genre.ToString() + " genre: " + line.Count);
            }


            Console.WriteLine();
            Console.WriteLine("The most fresh book is: " + fresh_book.First().Element("title").Value);
            Console.WriteLine("The oldest book is: " + oldest_book.First().Element("title").Value);
            if (pop_book.First().Element("title").Value.Equals(0))
                Console.WriteLine("One of he most popular books is: no popular books yet");
            else
                Console.WriteLine("One of the most popular books is:" + pop_book.First().Element("title").Value);
        }

        public static void Add_book(Literature book)
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



        public static bool Is_user(string login)
        {
            return users.Contains(login);
        }

        public static void Add_user(string login)
        {
            users.Add(login);
        }

        public static Book Find_pop_book_in_genre(Genre book_genre, string xml_path)
        {
            List<Book> books1 = new List<Book>();
            foreach (var book in books)
            {
                var book1 = book as Book;
                if (book1 != null) books1.Add(book1);
            }

            var xmlStr = File.ReadAllText(xml_path);
            var str = XElement.Parse(xmlStr);
            IEnumerable<XElement> result;
            result = str.Elements("Literature").Where(x =>
            {
                var xElement = x.Element("genre");
                return xElement != null && xElement.Value.Equals(book_genre.ToString());
            }).ToList();
            if (result.Count() == 0) return null;
            XElement max_el = result.First();
            int max_v = -1;
            foreach (XElement xel in result)
            {
                if ((int) xel.Element("pop_index") > max_v)
                {
                    max_v = (int)xel.Element("pop_index");
                    max_el = xel;
                }
            }

            Book res_book = new Book((string)max_el.Element("title"), (string)max_el.Element("author_name"), book_genre, (int)max_el.Element("year"), (int)max_el.Element("pages"), (int)max_el.Element("count"));
            return res_book;
        }

        public static bool Check_book(string title, string author, int checker, string xml_path)
        {
            var xmlStr = File.ReadAllText(xml_path);
            var str = XElement.Parse(xmlStr);
            IEnumerable<XElement> result;
            switch (checker)
            {
                case 1:
                    result = str.Elements("Literature").Where(x =>
                    {
                        var xElement = x.Element("title");
                        return xElement != null && xElement.Value.Equals(title);
                    }).ToList();
                    if (result.Count() > 0) return true;
                    break;
                case 2:
                    result = str.Elements("Literature").Where(x =>
                    {
                        var xElement = x.Element("author_name");
                        return xElement != null && xElement.Value.Equals(author);
                    }).ToList();
                    if (result.Count() > 0) return true;
                    break;
                case 3:
                    result = str.Elements("Literature").Where(x =>
                    {
                        var xElement = x.Element("author_name");
                        var xElement2 = x.Element("title");
                        return xElement != null && xElement.Value.Equals(author) &&
                                xElement2 != null && xElement2.Value.Equals(title);
                    }).ToList();
                    if (result.Count() > 0) return true;
                    break;
            }
            
                return false;
        }

    }
}
