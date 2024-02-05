using Microsoft.EntityFrameworkCore;

namespace Amortization.Data.Repositories
{
    public class AmortizationRepository : IAmortizationRepository
    {
        public ApplicationDbContext DataContext { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AmortizationRepository"/> class.
        /// </summary>
        public AmortizationRepository()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AmortizationRepository"/> class.
        /// </summary>
        /// <param name="dataContext">The dataContext.</param>
        public AmortizationRepository(ApplicationDbContext dataContext)
        {
            DataContext = dataContext;
        }

        public async Task SaveUserAsync(User user)
        {
            if (user.UserId == 0)
            {
                DataContext.Entry(user).State = EntityState.Added;
            }
            else
            {
                DataContext.Entry(user).State = EntityState.Modified;
            }
            await DataContext.SaveChangesAsync();
        }

        public async Task<User> GetUserAsync(string username)
        {
            var user = from u in DataContext.Users where u.UserName == username select u;
            return await user.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<MortgageParameter>> GetUserHistoryAsync(string username)
        {
            var userHistory = from u in DataContext.Users
                              join m in DataContext.MortgageParameters on u.UserId equals m.User.UserId
                              where u.UserName == username
                              select m;
            return await userHistory.ToListAsync();
        }

        public async Task<User> SaveUserAsync(string username)
        {
            // need to make sure user doesn't exist first
            User newUser = new User();
            newUser.UserName = username;
            DataContext.Users.Add(newUser);
            await DataContext.SaveChangesAsync();
            return newUser;
        }

        public async Task<int> SaveMortgageParameterAsync(MortgageParameter parameter, User user)
        {
            // need to check to make sure history doesn't exist for user.
            var savedParameters = from p in DataContext.MortgageParameters 
                                  where p.User == user 
                                  select p;
            var match = await savedParameters.FirstOrDefaultAsync(p => p.PrincipalLoanAmount == parameter.PrincipalLoanAmount && p.NumberOfPayments == parameter.NumberOfPayments && p.AnnualInterestRate == parameter.AnnualInterestRate);
            if (match != null)
            {
                return match.MortgageParameterId;
            }
            parameter.User = user; 
            
            DataContext.Entry(parameter).State = EntityState.Added;
            await DataContext.SaveChangesAsync();
            return parameter.MortgageParameterId;
        }

        public async Task<MortgageParameter> GetMortgageParametersAsync(int mortgageParameterId)
        {
            var parameter = from p in DataContext.MortgageParameters where p.MortgageParameterId == mortgageParameterId select p;
            return await parameter.FirstOrDefaultAsync();
        }
    }
}
