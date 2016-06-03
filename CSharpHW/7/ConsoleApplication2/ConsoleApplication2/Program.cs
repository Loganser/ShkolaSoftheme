using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        class Human
        {
            public string firstName { get; set; }
            public string lastName { get; set; }

            private int age { get; set; }

            public void calculateAge()
            {
                age = DateTime.Today.Year - birthDate.Year;
                //Console.WriteLine("dgdfgdfgfd");
                if (birthDate > DateTime.Today.AddYears(-age))
                    age--;
            }

            public bool equals(Human h)
            {
                if (this.age != h.age || !this.firstName.Equals(h.firstName) ||
                    !this.lastName.Equals(h.lastName) || !this.birthDate.Equals(h.birthDate)) return false;
                return true;
            }

            public DateTime birthDate;
            public DateTime BirthDate
            {
                get { return birthDate; }
                set { birthDate = value; }
            }
            

            public int getAge()
            {
                return age;
            }

            public Human()
            {
                DateTime tmpDate;
                DateTime.TryParse("11.01.1955", out tmpDate);
                if (tmpDate != null) this.birthDate = tmpDate;
                firstName = "";
                lastName = "";
            }
            public Human(DateTime birthDate, string firstName, string LastName)
            {
                this.birthDate = birthDate;
                this.firstName = firstName;
                this.lastName = lastName;
            }
        }




        static void Main(string[] args)
        {
            Human h1 = new Human();
            Console.WriteLine(h1.birthDate.Year);
            h1.calculateAge();
            Console.WriteLine(h1.getAge());
            //h1.age = 20; error

            Human h2 = new Human();
            Console.WriteLine("Before age calculation: "+h1.equals(h2));

            h2.calculateAge();
            Console.WriteLine("After age calculation: " + h1.equals(h2));
            Console.ReadLine();

        }
    }
}
