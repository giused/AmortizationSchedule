using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AmortizationService.Data;
namespace AmortizationService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("AmortizationServiceContextConnection") ?? throw new InvalidOperationException("Connection string 'AmortizationServiceContextConnection' not found.");

            builder.Services.AddDbContext<AmortizationServiceContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<AmortizationServiceUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AmortizationServiceContext>();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}