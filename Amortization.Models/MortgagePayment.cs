using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Amortization.Models
{
    public class MortgagePayment
    {
        [JsonPropertyName("PaymentNumber")]
        [Display(Name = "Payment Number")]
        public int PaymentNumber { get; set; }

        [JsonPropertyName("PrinciplePayment")]
        [Display(Name = "Principle Payment")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double PrinciplePayment
        {
            get
            {
                return TotalPayment - InterestPayment;
            }
        }

        [JsonPropertyName("InterestPayment")]
        [Display(Name = "Interest Payment")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double InterestPayment
        {
            get
            {
                return BeginningBalance * MonthlyInterestRate;
            }
        }

        [JsonPropertyName("BeginningBalance")]
        [Display(Name = "Beginning Balance")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double BeginningBalance { get; set; }

        [JsonPropertyName("RemainingBalance")]
        [Display(Name = "Remaining Balance")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double RemainingBalance { get { return BeginningBalance - PrinciplePayment; } }
        
        [JsonPropertyName("TotalPayment")]
        [Display(Name = "Total Payment")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double TotalPayment { get; set; }

        [JsonPropertyName("MonthlyInterestRate")]
        [Display(Name = "Monthly Interest Rate")]
        public double MonthlyInterestRate { get; set; }

        [JsonPropertyName("PaymentDate")]
        [Display(Name = "Payment Date")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime PaymentDate { get; set; }

        [JsonPropertyName("CumulativeInterestPaid")]
        [Display(Name = "Cumulative Interest Paid")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double CumulativeInterestPaid { get; set; }
    }
}
