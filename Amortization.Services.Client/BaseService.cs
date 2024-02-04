using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace Amortization.Services.Client
{
    public class BaseService
    {
        private RestClient _client;

        public BaseService() 
        {
            var options = new RestClientOptions("");
            _client = new RestClient(options);        
        }

     
    }
}
