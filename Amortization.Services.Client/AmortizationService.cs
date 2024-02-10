using Amortization.Models;
using RestSharp;
using System.Net.Http.Json;
using System.Text.Json;

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

        public async Task<List<MortgagePayment>> GenerateScheduleAsync(AmortizationParameters parameters)
        {
            RestRequest request = new RestRequest("api/Amortization/GenerateSchedule");
            
            request.AddJsonBody(parameters);
                
            var response = await _client.PostAsync<List<MortgagePayment>>(request);
            return response;
        }

        public async Task<List<MortgagePayment>> GenerateScheduleAsync(int mortgageParameterId)
        {
            RestRequest request = new RestRequest("api/Amortization/GenerateSchedule");
            request.AddParameter("mortgageParameterId", mortgageParameterId);

            var response = await _client.GetAsync(request);
            if (response.IsSuccessful)
            {
                var result = JsonSerializer.Deserialize<List<MortgagePayment>>(response.Content);
                return result;
            }
            return null;
        }

        public async Task<AmortizationParameters> GetParametersAsync(int id)
        {
            //Parameter
            RestRequest request = new RestRequest("api/Amortization/Parameter");
            request.AddParameter("id", id);
            var response = await _client.GetAsync<AmortizationParameters>(request);
            return response;
        }

        public async Task<List<AmortizationParameters>> GetUserHistoryAsync(string userName)
        {
            RestRequest request = new RestRequest("api/Amortization/GetUserHistory");
            //request.AddHeader("content-type", "application/json");
            request.AddParameter("userName", userName);
            //request.AddJsonBody(parameters);
            return await _client.GetAsync<List<AmortizationParameters>>(request);
        }

        public async Task<int> SaveUserAmortizationQueryAsync(string userName, AmortizationParameters parameters)
        {
            RestRequest request = new RestRequest("api/Amortization/{userName}/Parameters/", Method.Post);
            request.AddUrlSegment("userName", userName);
            request.AddJsonBody(parameters);
            return await _client.PostAsync<int>(request);
        }
    }
}
