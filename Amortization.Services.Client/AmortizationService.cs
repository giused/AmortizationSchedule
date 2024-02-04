using Amortization.Models;
using RestSharp;

namespace Amortization.Services.Client
{
    public class AmortizationService : BaseService, IAmortizationService
    {
        public AmortizationService(RestClient client) : base(client)
        {
            
        }

        public double CalculateLoanPayment(AmortizationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public List<MortgagePayment> GenerateSchedule(AmortizationParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}
