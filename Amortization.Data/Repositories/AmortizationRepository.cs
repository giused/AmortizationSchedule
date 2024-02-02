using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amortization.Data.Repositories
{
    public class AmortizationRepository
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
            if(user.UserId == 0)
            {
                DataContext.Entry(user).State = EntityState.Added;
            }
            else
            {
                DataContext.Entry(user).State = EntityState.Modified;
            }
            await DataContext.SaveChangesAsync();
        }
    }
}
