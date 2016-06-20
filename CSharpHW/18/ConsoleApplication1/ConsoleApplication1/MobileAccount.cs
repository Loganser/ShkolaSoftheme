using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class MobileAccount
    {
        public string Number;
        public delegate void MobileIncomingHandler(MobileAccount from, string to);
        public event MobileIncomingHandler CallIncoming;
        public event MobileIncomingHandler SMSIncoming;
        public Dictionary<string, string> Contacts = new Dictionary<string, string>();

        public MobileAccount(MobileOperator Operator, string number)
        {
            Number = number;
            CallIncoming += Operator.HandlingCall;
            SMSIncoming += Operator.HandlingSMS;
            Operator.AddAccount(this);
        }

        public void MakeCall(string number)
        {
            CallIncoming(this, number);
        }

        public void SendSMS(string number)
        {
            SMSIncoming(this, number);
        }

    }
}
