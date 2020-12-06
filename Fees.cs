using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_POO
{
    class Fees
    {
        private double accountBalance;
        private double paymentDue;
        private DateTime limitDate;
        private bool paymentStatus;

        public Fees(double AccountBalance, bool PaymentStatus, double PaymentDue)
        {
            this.limitDate = new DateTime(2021, 6, 4);//voir si changement
            this.accountBalance = AccountBalance;
            this.paymentDue = PaymentDue;
            this.paymentStatus = PaymentStatus;
        }
        public double AccountBalance
        {
            get { return this.accountBalance; }
            set { accountBalance = value; }
        }
        public DateTime LimitDate
        {
            get { return this.limitDate; }
            set { limitDate = value; }
        }
        public bool PaymentStatus
        {
            get { return this.paymentStatus; }
        }
        public double PaymentDue
        {
            get { return this.paymentDue; }
            set { paymentDue = value; }
        }

        public void PaymentDelay()
        {
            Console.Clear();
            if (DateTime.Compare(limitDate, DateTime.Today) < 0)
            {
                Console.WriteLine("Reminder : you have to pay your university fees, you are late for payment. You still have " + paymentDue + " to pay.");
            }
            else
            {
                Console.WriteLine("You have until " + limitDate.ToString() + " to pay.");
            }
            Console.ReadKey();
        }

        public void FeesInfo()
        {
            Console.Clear();
            Console.WriteLine("There is still " + paymentDue + " to pay.");
            Console.ReadKey();
        }

        public bool MakePayment(double ValuePayment)
        {
            bool Result = false;
            if (ValuePayment <= accountBalance && ValuePayment <= paymentDue)
            {
                paymentDue = paymentDue - ValuePayment;
                accountBalance = accountBalance - ValuePayment;
                Result = true;
            }
            return Result;
        }
    }
}
