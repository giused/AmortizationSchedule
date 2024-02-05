using Amortization.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Amortization.UI.Models
{
    public class AmortizationModel
    {
        [Required]
        [DisplayName("Annual Interest Rate")]
        [DisplayFormat(DataFormatString = "{0:0.00}%")]
        public double AnnualInterestRate { get; set; }
        
        [DisplayName("Number of Payments")]
        public int NumberOfPayments { get; set; }
        
        [DisplayName("Total Loan Amount")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double LoanAmount { get; set; }

        public List<MortgagePayment>? Schedule {  get; set; }

    }
}
