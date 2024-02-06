using Amortization.Identity;
using Amortization.Services;
using Amortization.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Amortization.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IAmortizationService AmortizationService { get; set; }
        IIdentityService IdentityService { get; set; }
        
        public HomeController(IIdentityService identityService, IAmortizationService amortizationService, ILogger<HomeController> logger)
        {
            _logger = logger;
            AmortizationService = amortizationService;
            IdentityService = identityService;
        }

        public async Task<IActionResult> Index()
        {
            var userHistory = await AmortizationService.GetUserHistoryAsync(IdentityService.GetUserName());
            return View(userHistory);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
