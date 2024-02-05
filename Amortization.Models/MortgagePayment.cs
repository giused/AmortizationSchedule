using System.ComponentModel.DataAnnotations;

namespace Amortization.Models
{
    public class MortgagePayment
    {
        [Display(Name = "Payment Number")]
        public int PaymentNumber { get; set; }

        [Display(Name = "Principle Payment")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double PrinciplePayment
        {
            get
            {
                return TotalPayment - InterestPayment;
            }
        }

        [Display(Name = "Interest Payment")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double InterestPayment
        {
            get
            {
                return BeginningBalance * MonthlyInterestRate;
            }
        }

        [Display(Name = "Beginning Balance")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double BeginningBalance { get; set; }

        [Display(Name = "Remaining Balance")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double RemainingBalance { get { return BeginningBalance - PrinciplePayment; } }

        [Display(Name = "Total Payment")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double TotalPayment { get; set; }

        [Display(Name = "Monthly Interest Rate")]
        public double MonthlyInterestRate { get; set; }

        [Display(Name = "Payment Date")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime PaymentDate { get; set; }

        [Display(Name = "Cumulative Interest Paid")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double CumulativeInterestPaid { get; set; }
    }
}
