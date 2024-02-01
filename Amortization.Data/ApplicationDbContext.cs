using Microsoft.EntityFrameworkCore;

namespace Amortization.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<MortgageParameter> MortgageParameters { get; set; }

        //private readonly string _connectionString;


        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        //public ApplicationDbContext(string connectionString)
        //{
        //    _connectionString = connectionString;
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(_connectionString);
        //}
    }
}
