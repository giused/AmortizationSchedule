using Amortization.Data;
using Amortization.Models;

namespace Amortization.Services
{
    internal interface ModelFactory
    {
        public static AmortizationParameters ToModel(MortgageParameter parameter)
        {
            return new AmortizationParameters
            {
                AnnualInterestRate = parameter.AnnualInterestRate,
                NumberOfPayments = parameter.NumberOfPayments,
                TotalLoanAmount = parameter.PrincipalLoanAmount,
                MortgageParameterId = parameter.MortgageParameterId
            };
        }
    }
}
