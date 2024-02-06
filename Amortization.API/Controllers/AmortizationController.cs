// Ignore Spelling: API

using Amortization.Identity;
using Amortization.Models;
using Amortization.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Amortization.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AmortizationController : ControllerBase
    {
        private readonly ILogger<AmortizationController> Logger;

        private IIdentityService IdentityService { get; set; }

        private IAmortizationService AmortizationService { get; set; }

        public AmortizationController(IIdentityService identityService, IAmortizationService amortizationService, ILogger<AmortizationController> logger)
        {
            Logger = logger;
            IdentityService = identityService;
            AmortizationService = amortizationService;
        }

        /// <summary>
        /// Generates an amortization schedule based on the parameters provided.
        /// </summary>
        /// <param name="parameters">Amortization parameters</param>
        /// <returns>List of mortgage payments</returns>
        [HttpPost("GenerateSchedule")]
        public async Task<IActionResult> Get(AmortizationParameters parameters)
        {
            try
            {
                var result = await AmortizationService.GenerateScheduleAsync(parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, "An exception occurred generating a schedule", parameters);
                return Problem(detail:ex.Message, statusCode:(int)HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Generates an amortization schedule based on the mortgage parameter retrieved by the id
        /// </summary>
        /// <param name="mortgageParameterId">Mortgage parameter Id</param>
        /// <returns>List of mortgage payments</returns>
        [HttpGet("GenerateSchedule")]
        public async Task<IActionResult> GetById(int mortgageParameterId)
        {
            try
            {
                var result = await AmortizationService.GenerateScheduleAsync(mortgageParameterId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, "An exception occurred generating a schedule", mortgageParameterId);
                return Problem(detail: ex.Message, statusCode: (int)HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Gets the users amortization schedule history
        /// </summary>
        /// <param name="userName">User to retrieve histrory for</param>
        /// <returns>List of amortization parameters.</returns>
        [HttpGet("GetUserHistory")]
        public async Task<IActionResult> GetUserHistory(string userName)
        {
            try
            {
                var result = await AmortizationService.GetUserHistoryAsync(IdentityService.GetUserName());
                return Ok(result);
            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, "An exception occurred retrieving user history", userName);
                return Problem(detail: ex.Message, statusCode: (int)HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Saves user parameters and returns Id of newly saved data.
        /// </summary>
        /// <param name="parameters">Parameters to save</param>
        /// <param name="userName">User name</param>
        /// <returns>Id of mortgage parameters</returns>
        [HttpPost("SaveParameters/{userName}")]
        public async Task<IActionResult> SaveUserParameters(AmortizationParameters parameters, string userName)
        {
            try
            {
                var result = await AmortizationService.SaveUserAmortizationQueryAsync(userName, parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, "An exception occurred saving user parameters", userName, parameters);
                return Problem(detail: ex.Message, statusCode: (int)HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Gets the amortization parameters based on the Id.
        /// </summary>
        /// <param name="id">Id of the parameters</param>
        /// <returns>AmortizationParameters</returns>
        [HttpGet("Parameter")]
        public async Task<IActionResult> GetAmortizationParameter(int id)
        {
            try
            {
                var result = await AmortizationService.GetParametersAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Logger.LogCritical(ex, "An exception occurred getting user parameters", id);
                return Problem(detail: ex.Message, statusCode: (int)HttpStatusCode.BadRequest);
            }
        }
    }
}
