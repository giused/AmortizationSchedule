// Ignore Spelling: API

using Amortization.Data;
using Amortization.Data.Repositories;
using Amortization.Identity;
using Amortization.Models;
using Amortization.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace Amortization.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AmortizationController : ControllerBase
    {
        public IIdentityService IdentityService { get; set; }

        public IAmortizationRepository AmortizationRepository { get; set; }

        public IAmortizationService AmortizationService { get; set; }

        public AmortizationController(IIdentityService identityService, IAmortizationRepository amortizationRepository, IAmortizationService amortizationService)
        {
            IdentityService = identityService;
            AmortizationRepository = amortizationRepository;
            AmortizationService = amortizationService;
        }

        [HttpGet("GetPayment")]
        public double Get(int termInMonths, double annualRate, double loanAmount)
        {
            AmortizationParameters parameters = new AmortizationParameters();
            parameters.AnnualInterestRate = annualRate;
            parameters.NumberOfPayments = termInMonths;
            parameters.PrincipalLoanAmount = loanAmount;
            
            return AmortizationService.CalculateLoanPayment(parameters);
        }

        [HttpGet("GetUserHistory")]
        public async Task<IEnumerable<MortgageParameter>> GetUserHistory()
        {
            string currentUserName = IdentityService.GetUserName();
            return await AmortizationRepository.GetUserHistory(currentUserName);            
        }
    }
}
