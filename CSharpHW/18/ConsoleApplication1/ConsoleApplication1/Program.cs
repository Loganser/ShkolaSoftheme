using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            MobileOperator OP = new MobileOperator();
            MobileAccount Alice = new MobileAccount(OP, "111");
            MobileAccount Bob = new MobileAccount(OP, "222");

            Alice.Contacts.Add("222", "BOB");
            Bob.Contacts.Add("111", "Alice");

            Alice.MakeCall("222");


            MobileAccount Charlie = new MobileAccount(OP, "333");
            Alice.MakeCall("333");

            Console.ReadLine();
        }
    }
}
