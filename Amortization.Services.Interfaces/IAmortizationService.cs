using Amortization.Models;

namespace Amortization.Services
{
    public interface IAmortizationService
    {
        double CalculateLoanPayment(AmortizationParameters parameters);

        Task<List<MortgagePayment>> GenerateScheduleAsync(AmortizationParameters parameters);

        Task<List<MortgagePayment>> GenerateScheduleAsync(int mortgageParameterId);

        Task<int> SaveUserAmortizationQueryAsync(string userName, AmortizationParameters parameters);

        Task<List<AmortizationParameters>> GetUserHistoryAsync(string userName);
    }
}
