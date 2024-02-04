using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Amortization.UI.Models
{
    public class AmortizationModel
    {
        [Required]
        [DisplayName("Annual Interest Rate")]
        public double AnnualInterestRate { get; set; }
        
        [DisplayName("Number of Payments")]
        public int NumberOfPayments { get; set; }
        
        [DisplayName("Total Loan Amount")]
        public double LoanAmount { get; set; }

        public List<MortgagePaymentModel> Schedule { get; set; }
    }
}
