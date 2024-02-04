using Amortization.Services;
using Amortization.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Amortization.UI.Controllers
{
    public class AmortizationController : Controller
    {
        public IAmortizationService AmortizationService { get; set; }

        public AmortizationController(IAmortizationService amortizationService)
        {
            AmortizationService = amortizationService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AmortizationModel model)
        { 
            if (ModelState.IsValid)
            {
                
            }
            return View(model);
        }
    }
}
