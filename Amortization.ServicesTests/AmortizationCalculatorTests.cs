using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amortization.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amortization.Services.Tests
{
    [TestClass()]
    public class AmortizationCalculatorTests
    {
        [TestMethod()]
        public void CalculateLoanPaymentTest()
        {
            AmortizationCalculator calculator = new AmortizationCalculator();  
            AmortizationParameters parameters = new AmortizationParameters();
            parameters.PrincipalLoanAmount = 5000;
            parameters.NumberOfPayments = 12;
            parameters.AnnualInterestRate = .04;
            double payment = calculator.CalculateLoanPayment(parameters);
            Assert.AreEqual(payment, 425.75);
        }
    }
}