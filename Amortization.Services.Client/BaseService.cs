﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
namespace Amortization.Services.Client
{
    public class BaseService
    {
        protected RestClient _client;

        public BaseService(RestClient client) 
        {
            _client = client;
            
        }     
    }
}
