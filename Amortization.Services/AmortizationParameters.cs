using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amortization.Services
{
    public class AmortizationParameters
    {
        public double PrincipalLoanAmount { get; set; }

        public double AnnualInterestRate { get; set; }
        
        public int NumberOfPayments { get; set; }
    }
}
