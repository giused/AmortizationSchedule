namespace Amortization.Models
{
    public class MortgagePayment
    {
        public int PaymentNumber { get; set; }

        public double PrinciplePayment
        {
            get
            {
                return TotalPayment - InterestPayment;
            }
        }
        public double InterestPayment
        {
            get
            {
                return BeginningBalance * MonthlyInterestRate;
            }
        }

        public double BeginningBalance { get; set; }

        public double RemainingBalance { get { return BeginningBalance - PrinciplePayment; } }

        public double TotalPayment { get; set; }

        public double MonthlyInterestRate { get; set; }

        public DateTime PaymentDate { get; set; }

        public double CumulativeInterestPaid { get; set; }
    }
}
