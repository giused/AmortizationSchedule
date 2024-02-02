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

        public async Task SaveUser(User user)
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

        public async Task<User> GetUser(string username)
        {
            var user = from u in DataContext.Users where u.UserName == username select u;
            return user.FirstOrDefault();
        }

        public async Task<IEnumerable<MortgageParameter>> GetUserHistory(string username)
        {
            var userHistory = from u in DataContext.Users
                              join m in DataContext.MortgageParameters on u.UserId equals m.User.UserId
                              where u.UserName == username
                              select m;
            return userHistory.AsEnumerable();
        }

        public async Task<User> SaveUser(string username)
        {
            // need to make sure user doesn't exist first
            User newUser = new User();
            newUser.UserName = username;
            DataContext.Users.Add(newUser);
            await DataContext.SaveChangesAsync();
            return newUser;
        }

        public Task SaveMortgageParameter(MortgageParameter parameter, User user)
        {
            // need to check to make sure history doesn't exist for user.
            throw new NotImplementedException();
        }
    }
}
