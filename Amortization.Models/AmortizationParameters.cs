namespace Amortization.Models
{
    /// <summary>
    /// Object to contain parameters used for mortgage calculation.
    /// </summary>
    public class AmortizationParameters
    {
        /// <summary>
        /// Gets or sets the principal loan amount
        /// </summary>
        public double PrincipalLoanAmount { get; set; }

        /// <summary>
        /// Gets or sets the annual interest rate
        /// </summary>
        public double AnnualInterestRate { get; set; }
        
        /// <summary>
        /// Gets or sets the number of payments in terms of months
        /// </summary>
        public int NumberOfPayments { get; set; }
    }
}
