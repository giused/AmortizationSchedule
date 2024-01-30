namespace Amortization.Services
{
    public class AmortizationCalculator
    {
        /// <summary>
        /// Calculates monthly loan payment based on parameters provided
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>Monthly mortgage payment</returns>
        public double CalculateLoanPayment(AmortizationParameters parameters)
        {
            double monthlyInterest = parameters.AnnualInterestRate / 12;
            double enumerator = monthlyInterest * Math.Pow((1 + monthlyInterest), parameters.NumberOfPayments);
            double denominator = Math.Pow((1 + monthlyInterest), parameters.NumberOfPayments) - 1;
            double payment = Math.Round(parameters.PrincipalLoanAmount * (enumerator / denominator), 2);
            return payment;
        }
    }
}
