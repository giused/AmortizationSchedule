namespace Amortization.Data
{
    public class MortgageParameter
    {
        public int MortgageParameterId { get; set; }
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

        public User User { get; set; }
    }
}