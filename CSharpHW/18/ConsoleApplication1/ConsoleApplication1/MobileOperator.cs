using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class MobileOperator
    {
        private Dictionary<string, MobileAccount> Accounts = new Dictionary<string, MobileAccount>();

        public void AddAccount(MobileAccount acc)
        {
            Accounts.Add(acc.Number, acc);
        }

        public void HandlingCall(MobileAccount from, string to)
        {
            if (!Accounts.ContainsKey(to))
            {
                Console.WriteLine("No such number!");
                return;
            }
            if (Accounts[to].Contacts.ContainsKey(from.Number))
                Console.WriteLine(to + " : Call from " + Accounts[to].Contacts[from.Number]);
            else
                Console.WriteLine(to + " : Call from  " + from.Number);
        }

        public void HandlingSMS(MobileAccount from, string to)
        {
            if (!Accounts.ContainsKey(to))
            {
                Console.WriteLine("No such number!");
                return;
            }
            if (Accounts[to].Contacts.ContainsKey(from.Number))
                Console.WriteLine(to + " : SMS from " + Accounts[to].Contacts[from.Number]);
            else
                Console.WriteLine(to + " : SMS from  " + from.Number);
        }
    }
}
