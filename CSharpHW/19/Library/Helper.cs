using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    enum Genre { classic, humor, drama }
    class Helper
    {
        static public void Exit_helper(User user)
        {
            if (!user.autorized)
            {
                Console.WriteLine(user.login + ", do you want to autorize? (yes/no)");
                string inp = Console.ReadLine();
                if (inp.Equals("yes"))
                {
                    Library.Add_user(user.login);
                    Console.WriteLine("You were added to our database!");
                }
            }

            Console.WriteLine("Bye, " + user.login + ". Please come back!");
            System.Threading.Thread.Sleep(1500);
            Environment.Exit(0);
        }

        static public void Show_help(User user)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("List of commands:");
            if (user.autorized)
            {
                Console.WriteLine("TAKE_BOOK");
                Console.WriteLine("RETURN_BOOK");
                Console.WriteLine("ADD_BOOK");
            }
            Console.WriteLine("SHOW_INFO");
            Console.WriteLine("CHECK_BOOK");
            Console.WriteLine("POPULAR_IN_GENRE");
            Console.WriteLine("EXIT");
            Console.ResetColor();
        }

    }
}
