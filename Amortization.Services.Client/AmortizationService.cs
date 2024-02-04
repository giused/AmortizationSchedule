using Amortization.Models;
using RestSharp;
using System.Buffers.Text;

namespace Amortization.Services.Client
{
    public class AmortizationService : BaseService, IAmortizationService
    {
        public double CalculateLoanPayment(AmortizationParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}
