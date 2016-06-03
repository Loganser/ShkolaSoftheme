using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Library
{
    class Program
    {
        enum Genre { classic, humor, drama}
        class Book
        {
            public string title { get; set; }
            string author_name;
            int year;
            int pages;
            public int pop_index { get; set; }
            public Genre genre;
            public int max_count;
            public int count { get; set; }
            public string last_taken_by;

            public Book(string title, string author_name, Genre genre, int year, int pages, int count)
            {
                this.title = title;
                this.author_name = author_name;
                this.genre = genre;
                this.year = year;
                this.pages = pages;
                this.pop_index = 0;
                this.count = this.max_count = count;
                this.last_taken_by = "no one";
            }

            public void change_last_user(User user)
            {
                last_taken_by = user.login;
            }
        }

        class User
        {
            public bool autorized { get; set; }
            public string login { get; set; }
            public List<Book> books_taken = new List<Book>();
            

            public User(string login)
            {
                this.login = login;
                this.autorized = false;
            }

            public void set_privileges()
            {
                this.autorized = true;
            }
            public Book take_book(string title)
            {
                foreach (Book book in Library.books)
                {
                    if (book.title.Equals(title) && book.count > 0)
                    {
                        book.count--;
                        book.pop_index++;
                        book.change_last_user(this);
                        books_taken.Add(book);
                        return book;
                    }
                }
                    return null;
            }

            public bool return_book(string title)
            {
                foreach (Book book in Library.books)
                {
                    bool found = false;
                    foreach (Book book1 in books_taken)
                    {
                        if (book.title.Equals(title)) found = true;
                    }

                        if (book.title.Equals(title) && book.count < book.max_count && found)
                    {
                        book.count++;
                        return true;
                    }
                }
                return false;
            }

        }

        static class Library
        {
            public static List<Book> books = new List<Book>();
            static HashSet<string> users = new HashSet<string>();

            public static void show_info()
            {
                Dictionary<Genre, int> c_by_genres = new Dictionary<Genre, int>();
                c_by_genres.Add(Genre.classic, 0);
                c_by_genres.Add(Genre.drama, 0);
                c_by_genres.Add(Genre.humor, 0);
                foreach (Book book in books) {
                    c_by_genres[book.genre]++;
                }
                //foreach (Dictionary<Genre, int> count in c_by_genres)
                //{
                //    Console.WriteLine("The number books of "+book.genre.ToString()+" genre: " + c_by_genres[book.genre]);
                //}
            }

            public static void add_book(Book book)
            {
                books.Add(book);
            }

            public static bool is_user(string login)
            {
                return users.Contains(login);
            }

            static public void add_user(string login)
            {
                users.Add(login);
            }
            

        }

        static void exit_helper(User user)
        {
            if (!user.autorized)
            {
                Console.WriteLine(user.login + ", do you want to autorize? (yes/no)");
                string inp = Console.ReadLine();
                if (inp.Equals("yes"))
                {
                    Library.add_user(user.login);
                    Console.WriteLine("You are added to our database!");
                }
            }
            
            Console.WriteLine("Bye, "+user.login+". Please come back!");
            System.Threading.Thread.Sleep(1000);
            Environment.Exit(0);
        }
        static void show_help(User user)
        {
            Console.WriteLine("You may enter the following commands: ");
            if (user.autorized)
            {

            } else
            {

            }
        }

        static void Main(string[] args)
        {
            Library.add_user("root");
            Book b1 = new Book("rose and gold", "Pushkin", Genre.drama, 1960, 1123, 2);
            Book b2 = new Book("white and blue", "Tolstoy", Genre.humor, 1932, 678, 1);
            Library.books.Add(b1);
            Library.books.Add(b1);

            Console.WriteLine("Please enter login:");
            string login;
            login = Console.ReadLine();
            User user = new User(login);
            if (Library.is_user(login))
            {
                user.set_privileges();
                Console.WriteLine("Welcome "+login+"! We are glad you are back!");
            } else
            {
                Console.WriteLine("Welcome unknown user.");
            }
            

            Console.WriteLine("Please command. Enter \"help\" for help.");
            while (true)
            {
                string inp = Console.ReadLine();
                if (user.autorized)
                {
                    switch (inp)
                    {
                        case "exit":
                            exit_helper(user);
                            break;
                        case "help":
                            show_help(user);
                            break;
                        case "take_book":
                            Console.WriteLine("Please enter the name of the book:");
                            string book_name = Console.ReadLine();
                            Book book_to_take = user.take_book(book_name);
                            if (book_to_take == null)
                            {
                                Console.WriteLine("There is no such book or it is already taken!");
                            } else
                            {
                                user.books_taken.Add(book_to_take);
                                Console.WriteLine("You have taken the book!");
                            }
                            break;
                        case "return_book":
                            Console.WriteLine("Please enter the name of the book:");
                            string book_name1 = Console.ReadLine();
                            bool f  = user.return_book(book_name1);
                            if (!f)
                            {
                                Console.WriteLine("Error");
                            }
                            else
                            {
                                Console.WriteLine("You have returned the book!");
                            }
                            break;
                    }
                }
                
                    switch (inp)
                    {
                        case "exit":
                            exit_helper(user);
                            break;
                        case "help":
                            show_help(user);
                            break;
                        case "show_info":
                        Library.show_info();
                            break;
                        
                    }
                
                
            }
            
    }
    }
}
