using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Library
{
    public enum Genre { classic, humor, drama }
    [Serializable]
    public class Helper
    {

        public static void Validate_user(User user)
        {

            var results = new List<ValidationResult>();
            var context = new ValidationContext(user);
            if (!Validator.TryValidateObject(user, context, results, true))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                    
                }
                Console.ResetColor();
                System.Threading.Thread.Sleep(1000);
                Environment.Exit(0);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("User is OK");
                Console.ResetColor();
            }
        }

        public static bool Validate_literature(Literature book)
        {

            var results = new List<ValidationResult>();
            var context = new ValidationContext(book);
            if (!Validator.TryValidateObject(book, context, results, true))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);

                }
                Console.ResetColor();
                return false;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Book is OK");
                Console.ResetColor();
                return true;
            }
        }

        public static void Exit_helper(User user)
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

        public static void Show_help(User user)
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
