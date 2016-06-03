using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        private static string GetZodiacName(DateTime dt)
        {
            int month = dt.Month;
            int day = dt.Day;
            switch (month)
            {
                case 1:
                    if (day <= 19)
                        return "Capricorn";
                    else
                        return "Aquarius";

                case 2:
                    if (day <= 18)
                        return "Aquarius";
                    else
                        return "Pisces";
                case 3:
                    if (day <= 20)
                        return "Pisces";
                    else
                        return "Aries";
                case 4:
                    if (day <= 19)
                        return "Aries";
                    else
                        return "Taurus";
                case 5:
                    if (day <= 20)
                        return "Taurus";
                    else
                        return "Gemini";
                case 6:
                    if (day <= 20)
                        return "Gemini";
                    else
                        return "Cancer";
                case 7:
                    if (day <= 22)
                        return "Cancer";
                    else
                        return "Leo";
                case 8:
                    if (day <= 22)
                        return "Leo";
                    else
                        return "Virgo";
                case 9:
                    if (day <= 22)
                        return "Virgo";
                    else
                        return "Libra";
                case 10:
                    if (day <= 22)
                        return "Libra";
                    else
                        return "Scorpio";
                case 11:
                    if (day <= 21)
                        return "Scorpio";
                    else
                        return "Sagittarius";
                case 12:
                    if (day <= 21)
                        return "Sagittarius";
                    else
                        return "Capricorn";
            }
            return "";
        }
        static void Main(string[] args)
        {      
            DateTime todayDate = DateTime.Today;
            DateTime userBirthdate = DateTime.MinValue;

            Console.Write("Please enter your date of birth (DD/MM/YYYY):  ");

            bool inputValid = false;
            while (inputValid != true)
            {
                DateTime tmpDate = DateTime.MinValue;
                if (!DateTime.TryParse(Console.ReadLine(), out tmpDate) || tmpDate > todayDate)
                {
                    Console.Write("Invalid Date.  Please enter your date of birth (dd/mm/yy):  ");
                }
                else
                {
                    userBirthdate = tmpDate;
                    Console.WriteLine("OK. Your Zodiac Sign is: ");
                    Console.WriteLine(GetZodiacName(userBirthdate));
                    inputValid = true;
                }
               
            }
            Console.ReadLine();
        }
        
    }
}
