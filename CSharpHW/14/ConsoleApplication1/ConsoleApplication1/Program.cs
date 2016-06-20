using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int[] winComb = new int[6];
            for (int i = 0; i < winComb.Length; i++) winComb[i] = rand.Next(1, 9);
            Ticket winTicket = new Ticket(winComb);

            Console.WriteLine("Please write six int numbers (from 1 to 9) in one line. Example: 123456");
            string inp = Console.ReadLine();
            if (inp.Length != 6) Console.WriteLine("Wrong length!");
            int[] ticket = new int[6];
            for (int i = 0; i < inp.Length; ++i)
            {
                if ((inp[i] - '0') > 9 || (inp[i] - '0') < 1)
                {
                    Console.WriteLine("Wrong number!");
                    return;
                }
                ticket[i] = inp[i] - '0';
            }
            Ticket userTicket = new Ticket(ticket);

            Console.WriteLine("----------------------------");
            Console.WriteLine("Comparing digits...");

            for (int i = 0; i < 6; i++)
            {
                if (!winTicket[i].Equals(userTicket[i]))
                {
                    Console.WriteLine("You lost!");
                    break;
                }
            }

            Console.WriteLine("Winning combination:");
            foreach (int digit in winComb)
            {
                Console.Write(digit);
            }

            Console.ReadLine();

        }
    }
}
