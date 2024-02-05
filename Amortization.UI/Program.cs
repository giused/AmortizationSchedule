using Amortization.Identity;
using Amortization.Services;
using Amortization.Services.Client;
using RestSharp;

namespace Amortization.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();
            var apiUrl = builder.Configuration["RestEndpoint"];
            Uri baseUrl = new Uri(apiUrl);

            builder.Services.AddSingleton(new RestClient(new RestClientOptions { BaseUrl = baseUrl, UseDefaultCredentials = true }));
            builder.Services.AddScoped<IAmortizationService, AmortizationService>();
            builder.Services.AddScoped<IIdentityService, WindowsIdentityService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
