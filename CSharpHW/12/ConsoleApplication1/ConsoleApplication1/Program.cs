using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleApplication1
{
    class Program
    {
        class User : IUser, IValidator
        {
            public string Name { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }
            public DateTime LastDate { get; set; }

            public User(string Name, string Password, string Email)
            {
                this.Name = Name;
                this.Password = Password;
                this.Email = Email;
            }

            public string GetFullInfo()
            {
                return Name + " " + Password + " " + Email;
            }
            public bool ValidateUser(IUser user)
            {
                if ((this.Name.Equals(user.Name) && this.Password.Equals(user.Password)) ||
                    (this.Email.Equals(user.Email) && this.Password.Equals(user.Password)))
                {
                    Console.WriteLine("Last login: "+user.LastDate.ToString());
                    user.LastDate = DateTime.Now;
                    return true;
                }
                return false;
            }
        }

        static class DataBase
        {
            static List<User> users = new List<User>();
            static public void AddUser(User user)
            {
                user.LastDate = DateTime.Now;
                users.Add(user);
            }
            static public bool ValidateUser(User user)
            {
                for (int i = 0; i < users.Count; ++i)
                    if (user.ValidateUser(users[i])) return true;
                return false;
            }
        }

        interface IUser
        {
            string Name { get; set; }
            string Password { get; set; }
            string Email { get; set; }
            DateTime LastDate { get; set; }
            string GetFullInfo();
        }
        interface IValidator
        {
            bool ValidateUser(IUser user);
        }

        public static void inputHelper(out string name, out string password, out string email)
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Please enter name, password, email:");
            name = Console.ReadLine();
            password = Console.ReadLine();
            email = Console.ReadLine();
            Console.WriteLine("---------------------------");
        }

        static void Main(string[] args)
        {
            User u1 = new User("root", "root1", "root@mail.ru");
            DataBase.AddUser(u1);
            string name, password, email;
            inputHelper(out name,out  password,out  email);
            while (!(name == "exit" && password == "exit" && email == "exit"))
            {
                u1 = new User(name, password, email);
                if (DataBase.ValidateUser(u1))
                {
                    Console.WriteLine("Welcome!");
                    Console.WriteLine(u1.GetFullInfo());
                }
                else
                {
                    DataBase.AddUser(u1);
                    Console.WriteLine("Welcome new user!");
                    Console.WriteLine(u1.GetFullInfo());
                }

                inputHelper(out name, out password, out email);
            }
        }
    }
}
