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

        [HttpPost("GenerateSchedule")]
        public async Task<List<MortgagePayment>> Get(AmortizationParameters parameters)
        {
            //AmortizationParameters parameters = new AmortizationParameters(loanAmount, annualRate, termInMonths);
            return await AmortizationService.GenerateScheduleAsync(parameters);
        }

        [HttpGet("GenerateSchedule")]
        public async Task<List<MortgagePayment>> GetById(int mortgageParameterId)
        {
            return await AmortizationService.GenerateScheduleAsync(mortgageParameterId);
        }

        [HttpGet("GetUserHistory")]
        public async Task<IEnumerable<AmortizationParameters>> GetUserHistory(string userName)
        {
            return await AmortizationService.GetUserHistoryAsync(IdentityService.GetUserName());
        }

        [HttpPost("SaveParameters/{userName}")]
        public async Task<int> SaveUserParameters(AmortizationParameters parameters, string userName)
        {
            //string userName = IdentityService.GetUserName();
            return await AmortizationService.SaveUserAmortizationQueryAsync(userName, parameters);
        }


    }
}
