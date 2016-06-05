using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        struct User1
        {
            public int age;
            public string name;
            public User1(int age, string name)
            {
                this.age = age;
                this.name = name;
            }
            public void show()
            {
                Console.WriteLine("-----------------");
                Console.WriteLine("Name: "+ name);
                Console.WriteLine("Age" + age);
                Console.WriteLine("-----------------");
            }
        }
        class User
        {
            public int age;
            public string name;
            public User(int age, string name)
            {
                this.age = age;
                this.name = name;
            }
            public void show()
            {
                Console.WriteLine("-----------------");
                Console.WriteLine("Name: " + name);
                Console.WriteLine("Age" + age);
                Console.WriteLine("-----------------");
            }
        }
        static void changeUser(User1 user)
        {
            user.name = "Peter";
            user.age = 42;
        }
        static void changeUser(User user)
        {
            user.name = "Andrew";
            user.age = 45;
        }

        static void Main(string[] args)
        {
            User1 u1 = new User1(20, "Vova");
            u1.show();
            changeUser(u1);
            u1.show(); //nothing was changed in u1
            Console.WriteLine("------------------------------------------------");
            User u2 = new User(21, "Petya");
            u2.show();
            changeUser(u2);
            u2.show();
            Console.ReadLine();
        }
    }
}
