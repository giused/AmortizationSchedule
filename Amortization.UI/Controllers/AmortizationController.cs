using Amortization.Identity;
using Amortization.Models;
using Amortization.Services;
using Amortization.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Amortization.UI.Controllers
{
    public class AmortizationController : Controller
    {
        public IAmortizationService AmortizationService { get; set; }

        public IIdentityService IdentityService { get; set; }

        public AmortizationController(IAmortizationService amortizationService, IIdentityService identityService)
        {
            AmortizationService = amortizationService;
            IdentityService = identityService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AmortizationModel model)
        { 
            if (ModelState.IsValid)
            {
                AmortizationParameters parameters = new AmortizationParameters(model.LoanAmount, model.AnnualInterestRate, model.NumberOfPayments);

                // save parameters, then pass id of parameters
                int id = await AmortizationService.SaveUserAmortizationQueryAsync(IdentityService.GetUserName(), parameters);
                return RedirectToAction("Schedule", "Amortization", new { id = id });
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Schedule(int id)
        {
            List<MortgagePayment> schedule = await AmortizationService.GenerateScheduleAsync(id);
            AmortizationParameters parameters = await AmortizationService.GetParametersAsync(id);
            AmortizationModel model = new AmortizationModel();
            model.Schedule = schedule;
            model.NumberOfPayments = parameters.NumberOfPayments;
            model.AnnualInterestRate = parameters.AnnualInterestRate;
            model.LoanAmount = parameters.TotalLoanAmount;
            return View(model);
        }
    }
}
