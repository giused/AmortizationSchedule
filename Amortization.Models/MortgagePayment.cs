using System.ComponentModel.DataAnnotations;

namespace Amortization.Models
{
    public class MortgagePayment
    {
        public int PaymentNumber { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public double PrinciplePayment
        {
            get
            {
                return TotalPayment - InterestPayment;
            }
        }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public double InterestPayment
        {
            get
            {
                return BeginningBalance * MonthlyInterestRate;
            }
        }
        
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public double BeginningBalance { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public double RemainingBalance { get { return BeginningBalance - PrinciplePayment; } }
        
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public double TotalPayment { get; set; }

        public double MonthlyInterestRate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime PaymentDate { get; set; }

        
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public double CumulativeInterestPaid { get; set; }
    }
}
