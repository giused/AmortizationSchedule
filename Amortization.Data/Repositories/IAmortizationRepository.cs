

namespace Amortization.Data.Repositories
{
    public interface IAmortizationRepository
    {
        ApplicationDbContext DataContext { get; set; }

        Task<User> GetUser(string username);
        Task<IEnumerable<MortgageParameter>> GetUserHistory(string username);
        Task SaveUser(User user);

        Task<User> SaveUser(string username);

        Task SaveMortgageParameter(MortgageParameter parameter, User user);
    }
}