namespace Amortization.Models
{
    /// <summary>
    /// Object to contain parameters used for mortgage calculation.
    /// </summary>
    public class AmortizationParameters
    {
        /// <summary>
        /// Initializes a new instance of the Amortization parameters
        /// </summary>
        public AmortizationParameters() { }

        /// <summary>
        /// Initializes a new instance of the Amortization parameters
        /// </summary>
        /// <param name="totalLoanAmount">Total Loan Amount</param>
        /// <param name="annualInterestRate">Annual Interest Rate</param>
        /// <param name="numberOfPayments">Number of payments in months</param>
        public AmortizationParameters(double totalLoanAmount, double annualInterestRate, int numberOfPayments)
        {
            TotalLoanAmount = totalLoanAmount;
            AnnualInterestRate = annualInterestRate;
            NumberOfPayments = numberOfPayments;
        }
        /// <summary>
        /// Gets or sets the total loan amount
        /// </summary>
        public double TotalLoanAmount { get; set; }

        /// <summary>
        /// Gets or sets the annual interest rate
        /// </summary>
        public double AnnualInterestRate { get; set; }

        /// <summary>
        /// Gets or sets the number of payments in terms of months
        /// </summary>
        public int NumberOfPayments { get; set; }

        /// <summary>
        /// Gets the monthly interest rate based on the Annual Interest Rate provided
        /// </summary>
        public double MonthlyInterestRate
        {
            get
            {
                return AnnualInterestRate / 12;
            }
        }
    }
}
