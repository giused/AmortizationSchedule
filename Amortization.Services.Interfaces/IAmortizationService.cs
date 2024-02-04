using Amortization.Models;

namespace Amortization.Services
{
    public interface IAmortizationService
    {
        double CalculateLoanPayment(AmortizationParameters parameters);

        List<MortgagePayment> GenerateSchedule(AmortizationParameters parameters);
        
    }
}
