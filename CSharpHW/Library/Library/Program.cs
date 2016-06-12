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
        

        static void Main(string[] args)
        {
            Library.Add_user("root");
            Book b1 = new Book("rose and gold", "Pushkin", Genre.drama, 1960, 1123, 2);
            Book b2 = new Book("white and blue", "Tolstoy", Genre.humor, 1932, 678, 1);
            Library.Add_book(b1);
            Library.Add_book(b2);
            Library.Add_book(b2);

            Console.WriteLine("Please enter login:");
            string login;
            login = Console.ReadLine();
            User user = new User(login);
            if (Library.Is_user(login))
            {
                user.Set_privileges();
                Console.WriteLine("Welcome "+login+"! We are glad you are back!");
            } else
            {
                Console.WriteLine("Welcome unknown user.");
            }
            string book_name, book_aut;
            Genre book_genre;
            int book_year, book_pages;

            Console.WriteLine("Please command. Enter \"help\" for help.");
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("$");
                Console.ResetColor();
                string inp = Console.ReadLine();
                inp = inp.ToUpper();
                if (user.autorized)
                {
                    switch (inp)
                    {
                        case "TAKE_BOOK":
                            Console.WriteLine("Please enter the name of the book:");
                            book_name = Console.ReadLine();
                            Console.WriteLine("Please enter the author of the book:");
                            book_aut = Console.ReadLine();
                            Book book_to_take = user.Take_book(book_name, book_aut);
                            if (book_to_take == null)
                            {
                                Console.WriteLine("There is no such book or it is already taken!");
                            } else
                            {
                                user.books_taken.Add(book_to_take);
                                Console.WriteLine("You have taken the book!");
                            }
                            break;
                        case "RETURN_BOOK":
                            Console.WriteLine("Please enter the name of the book:");
                            book_name = Console.ReadLine();
                            Console.WriteLine("Please enter the author of the book:");
                            book_aut = Console.ReadLine();
                            if (!user.Return_book(book_name, book_aut))
                            {
                                Console.WriteLine("Error");
                            }
                            else
                            {
                                Console.WriteLine("You have returned the book!");
                            }
                            break;
                        case "ADD_BOOK":
                            Console.WriteLine("Please enter the name of the book:");
                            book_name = Console.ReadLine();
                            Console.WriteLine("Please enter the author:");
                            book_aut = Console.ReadLine();
                            Console.WriteLine("Please enter the genre:");
                            for (int i = 0; i < Enum.GetNames(typeof(Genre)).Length; ++i)
                            {
                                Genre tmp_g = (Genre)i;
                                Console.WriteLine(i.ToString() + " - " + tmp_g.ToString());
                            }
                            book_genre = (Genre)int.Parse(Console.ReadLine());
                            Console.WriteLine("Please enter the year:");
                            book_year = int.Parse(Console.ReadLine());
                            Console.WriteLine("Please enter the number of pages:");
                            book_pages = int.Parse(Console.ReadLine());
                            Book new_book = new Book(book_name, book_aut, book_genre, book_year, book_pages, 1);
                            Library.Add_book(new_book);
                            break;
                    }
                }
                
                    switch (inp)
                    {
                        case "EXIT":
                            Helper.Exit_helper(user);
                            break;
                        case "HELP":
                            Helper.Show_help(user);
                            break;
                        case "SHOW_INFO":
                        Library.Show_info();
                            break;
                        case "CHECK_BOOK":
                            Console.WriteLine("Please choose option:");
                            Console.WriteLine("1 - search by title");
                            Console.WriteLine("2 - search by author");
                            Console.WriteLine("3 - search by title and author");
                            int inp2 = int.Parse(Console.ReadLine());
                            switch (inp2)
                            {
                                case 1:
                                    Console.WriteLine("Please enter the name of the book:");
                                    book_name = Console.ReadLine();
                                    Console.WriteLine("Book is in the library: " + Library.Check_book(book_name, "", 1));
                                    break;
                                    break;
                                case 2:
                                    Console.WriteLine("Please enter the author:");
                                    book_aut = Console.ReadLine();
                                    Console.WriteLine("Book is in the library: " + Library.Check_book("", book_aut, 2));
                                    break;
                                case 3:
                                    Console.WriteLine("Please enter the name of the book:");
                                    book_name = Console.ReadLine();
                                    Console.WriteLine("Please enter the author:");
                                    book_aut = Console.ReadLine();
                                    Console.WriteLine("Book is in the library: " + Library.Check_book(book_name, book_aut, 3));
                                    break;
                            }
                            break;
                        case "POPULAR_IN_GENRE":
                            Console.WriteLine("Please enter the genre:");
                            for (int i = 0; i < Enum.GetNames(typeof(Genre)).Length; ++i)
                            {
                                Genre tmp_g = (Genre)i;
                                Console.WriteLine(i.ToString() + " - " + tmp_g.ToString());
                            }
                            book_genre = (Genre)int.Parse(Console.ReadLine());
                            Book pop_book = Library.Find_pop_book_in_genre(book_genre);
                            if (pop_book == null)
                            {
                                Console.WriteLine("No popular books of that genre !");
                            }
                            else
                            {
                                Console.WriteLine("Nost popular book:");
                                Console.WriteLine("Title: " + pop_book.title + " ; Author: " + pop_book.author_name);
                            }
                            break;

                }
                
                
            }
            
    }
    }
}
