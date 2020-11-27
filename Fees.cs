using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Project
{
    class Fees
    {
        private int creditCardID;
        private double accountBalance;
        private double paymentDue;
        private DateTime limitDate;
        private bool paymentStatus;

        public Fees(int CreditCardID, double AccountBalance, DateTime LimitDate, bool PaymentStatus = false, double PaymentDue = 8000)
        {
            this.creditCardID = CreditCardID;
            this.limitDate = LimitDate;
            this.accountBalance = AccountBalance;
            this.paymentDue = PaymentDue;
            this.paymentStatus = PaymentStatus;
        }

        public int CreditCardID
        {
            get { return this.creditCardID; }
            set { creditCardID = value; }
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
            if (DateTime.Compare(limitDate, DateTime.Today) < 0)
            {
                Console.WriteLine("Reminder : you have to pay your university fees, you are late for payment. You still have " + paymentDue + " to pay.");
            }
            else
            {
                Console.WriteLine("You have until " + limitDate.ToString() + " to pay.");
            }
        }

        public string FeesInfo()
        {
            string Result="There is still "+paymentDue+" to pay.";
            return Result;
        }

        public bool MakePayment(double ValuePayment)
        {
            bool Result = false;
            if (ValuePayment<=accountBalance && ValuePayment<=paymentDue)
            {
                paymentDue = paymentDue - ValuePayment;
                Result = true;
            }
            return Result;
        }
    }
}
