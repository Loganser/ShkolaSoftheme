using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        public enum Model
        {
            Tatra,
            Caterham,
            Foton,
            Dacia
        }
        public enum Color
        {
            Red,
            Green,
            Blue,
            Pink,
            Yellow
        }

        static class TuningAtelier {
            public static void TuneCar(Car car)
            {
                car.color = Color.Red;
            }
        }

        class Car
        {
           public Model model { get; set; }
           public Color color { get; set; }
           public int year { get; set; }

            public Car(Model model, Color color, int year)
            {
                this.model = model;
                this.color = color;
                this.year = year;
            }

            public void printInfo()
            {
                Console.WriteLine("-------------------------");
                Console.Write("Model: " + model.ToString()+"\n");
                Console.Write("Color: " + color.ToString() + "\n");
                Console.Write("Year: " + year + "\n");
                Console.WriteLine("-------------------------");
            }

        }




        static void Main(string[] args)
        {
            Car car1 = new Car(Model.Dacia, Color.Yellow, 1994);
            Console.WriteLine("Before tuning");
            car1.printInfo();
            
            TuningAtelier.TuneCar(car1);
            Console.WriteLine("\nAfter tuning");
            car1.printInfo();

            Console.ReadLine();
        }
    }
}
