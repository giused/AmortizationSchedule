using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amortization.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amortization.Models;
using Amortization.Identity;
using Amortization.Data.Repositories;

namespace Amortization.Services.Tests
{
    [TestClass()]
    public class AmortizationCalculatorTests
    {
        [TestMethod()]
        public void CalculateLoanPaymentTest()
        {
            IIdentityService identityService = new WindowsIdentityService();
            IAmortizationRepository repo = new AmortizationRepository();
            AmortizationService service = new AmortizationService(identityService, repo);

            AmortizationParameters parameters = new AmortizationParameters();
            parameters.PrincipalLoanAmount = 5000;
            parameters.NumberOfPayments = 12;
            parameters.AnnualInterestRate = .04;
            double payment = service.CalculateLoanPayment(parameters);
            Assert.AreEqual(payment, 425.75);
        }
    }
}