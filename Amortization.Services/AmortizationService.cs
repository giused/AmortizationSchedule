using Amortization.Data.Repositories;
using Amortization.Identity;
using Amortization.Models;

namespace Amortization.Services
{
    public class AmortizationService : IAmortizationService
    {
        public IIdentityService IdentityService { get; set; }

        public IAmortizationRepository AmortizationRepository { get; set; }

        public AmortizationService(IIdentityService identityService, IAmortizationRepository amortizationRepository)
        {
            IdentityService = identityService;
            AmortizationRepository = amortizationRepository;
        }

        /// <summary>
        /// Calculates monthly loan payment based on parameters provided
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>Monthly mortgage payment</returns>
        public double CalculateLoanPayment(AmortizationParameters parameters)
        {
            double monthlyInterest = parameters.MonthlyInterestRate / 100;
            double enumerator = monthlyInterest * Math.Pow((1 + monthlyInterest), parameters.NumberOfPayments);
            double denominator = Math.Pow((1 + monthlyInterest), parameters.NumberOfPayments) - 1;
            double payment = parameters.PrincipalLoanAmount * (enumerator / denominator);
            return payment;
        }

        public List<MortgagePayment> GenerateSchedule(AmortizationParameters parameters)
        {
            double remainingBalance = parameters.PrincipalLoanAmount;
            double monthlyPayment = CalculateLoanPayment(parameters);
            DateTime paymentDate = DateTime.Now.AddMonths(1);
            double monthlyInterest = parameters.MonthlyInterestRate / 100;
            double cumulativeInterest = 0;

            List<MortgagePayment> schedule = new List<MortgagePayment>();
            MortgagePayment payment;
            for (int i = 1; i <= parameters.NumberOfPayments; i++)
            {
                payment= new MortgagePayment();
                payment.TotalPayment = monthlyPayment;
                payment.BeginningBalance = remainingBalance;
                payment.MonthlyInterestRate = monthlyInterest;
                payment.PaymentDate = paymentDate;
                payment.PaymentNumber = i;
                cumulativeInterest += payment.InterestPayment;
                payment.CumulativeInterestPaid = cumulativeInterest;
                schedule.Add(payment);

                remainingBalance = payment.RemainingBalance;
                paymentDate = paymentDate.AddMonths(1);
            }
            return schedule;
        }

        private void SaveUserAmortizationQuery(string userName, AmortizationParameters parameters)
        {

        }
    }
}
