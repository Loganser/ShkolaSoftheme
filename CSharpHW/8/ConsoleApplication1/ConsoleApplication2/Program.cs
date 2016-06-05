using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        enum CarColor { blue, yellow, red, green}
        enum CarTransmission { auto, manual}
        class Engine
        {
            public int power;
            public Engine(int power)
            {
                this.power = power;
            }
        }
        class Color
        {
            public CarColor color;
            public Color(CarColor color)
            {
                this.color = color;
            }
        }
        class Transmission
        {
            public CarTransmission transmission;
            public Transmission(CarTransmission transmission)
            {
                this.transmission = transmission;
            }
        }
        static class CarConstructor
        {
            public static Car construct(Engine engine, Color color, Transmission transmission)
            {
                Car car = new Car(engine, color, transmission);
                return car;
            }
            public static void reconstruct(Car car)
            {
                Engine newEngine = new Engine(100500);
                car.changeEngine(newEngine);
            }
        }
        class Car
        {
            Engine engine;
            Color color;
            Transmission transmission;
            public void changeEngine(Engine engine)
            {
                this.engine = engine;
            }
            public Car(Engine engine, Color color, Transmission transmission)
            {
                this.engine = engine;
                this.color = color;
                this.transmission = transmission;
            }
            public void show()
            {
                Console.WriteLine("----------------");
                Console.WriteLine("Engine power: " + engine.power);
                Console.WriteLine("Color: " + color.color);
                Console.WriteLine("Transmission: " + transmission.transmission);
                Console.WriteLine("----------------");
            }
        }


        static void Main(string[] args)
        {
            Engine engine = new Engine(200);
            Color color = new Color(CarColor.blue);
            Transmission transmission = new Transmission(CarTransmission.auto);
            Car myCar = CarConstructor.construct(engine, color, transmission);
            myCar.show();
            CarConstructor.reconstruct(myCar);
            myCar.show();


            Console.ReadLine();
        }
    }
}
