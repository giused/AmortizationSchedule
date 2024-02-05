

namespace Amortization.Data.Repositories
{
    public interface IAmortizationRepository
    {
        ApplicationDbContext DataContext { get; set; }

        Task<User> GetUserAsync(string username);
        Task<IEnumerable<MortgageParameter>> GetUserHistoryAsync(string username);

        Task<MortgageParameter> GetMortgageParametersAsync(int mortgageParameterId);

        Task SaveUserAsync(User user);

        Task<User> SaveUserAsync(string username);

        Task<int> SaveMortgageParameterAsync(MortgageParameter parameter, User user);
    }
}