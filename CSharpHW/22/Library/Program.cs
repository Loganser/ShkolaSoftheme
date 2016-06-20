using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO.Compression;

namespace Library
{
    class Program
    {
        private const string xml_path = "books_xml.txt";
        static void Main(string[] args)
        {
            Library.Add_user("root");

            Helper.Download_Library(xml_path, "Library.zip");

            Console.WriteLine("Please enter login:");
            string login;
            login = Console.ReadLine();
            User user = new User(login);
            Helper.Validate_user(user);
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
                Helper.Save_Library(xml_path, "Library.zip");
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
                            Literature book_to_take = user.Take_book(book_name, book_aut);
                            Book book_to_take1 = book_to_take as Book;
                            if (book_to_take1 == null)
                            {
                                Console.WriteLine("ERROR: You can not take this book!");
                            } else
                            {
                                 user.books_taken.Add(book_to_take1);
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
                            Helper.Validate_literature(new_book);
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
                                Console.WriteLine("Most popular book:");
                                Console.WriteLine("Title: " + pop_book.title + " ; Author: " + pop_book.author_name);
                            }
                            break;                }
            }
    }
    }
}
