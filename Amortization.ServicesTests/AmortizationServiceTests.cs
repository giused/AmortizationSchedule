using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amortization.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amortization.Data.Repositories;
using Amortization.Identity;
using Amortization.Models;

namespace Amortization.Services.Tests
{
    [TestClass()]
    public class AmortizationServiceTests
    {

        private IIdentityService identityService;
        private IAmortizationRepository repo;
        private AmortizationService service;

        [TestInitialize()]
        public void AmortizationServiceTestInitialization()
        {
            identityService = new WindowsIdentityService();
            repo = new AmortizationRepository();
            service = new AmortizationService(identityService, repo);
        }

        [TestMethod()]
        public void CalculateLoanPaymentTest()
        {
            AmortizationParameters parameters = new AmortizationParameters();
            parameters.PrincipalLoanAmount = 5000;
            parameters.NumberOfPayments = 12;
            parameters.AnnualInterestRate = 4;
            double payment = Math.Round(service.CalculateLoanPayment(parameters), 2);
            Assert.AreEqual(payment, 425.75);
        }

        [TestMethod()]
        public void CalculateLoanPaymentTest2()
        {
            AmortizationParameters parameters = new AmortizationParameters();
            parameters.PrincipalLoanAmount = 5000;
            parameters.NumberOfPayments = 60;
            parameters.AnnualInterestRate = 5.5;
            double payment = Math.Round(service.CalculateLoanPayment(parameters), 2);
            Assert.AreEqual(payment, 95.51);
        }


        [TestMethod()]
        public void GenerateScheduleTest()
        {
            AmortizationParameters parameters = new AmortizationParameters();
            parameters.PrincipalLoanAmount = 5000;
            parameters.NumberOfPayments = 60;
            parameters.AnnualInterestRate = 5.5;

            var schedule = service.GenerateSchedule(parameters);
            Assert.AreEqual(Math.Round(schedule[0].BeginningBalance, 2), parameters.PrincipalLoanAmount);
            Assert.AreEqual(schedule[0].PaymentNumber, 1);
            Assert.AreEqual(Math.Round(schedule[0].TotalPayment, 2), 95.51);
            Assert.AreEqual(Math.Round(schedule[0].RemainingBalance, 2), 4927.41);

            Assert.AreEqual(Math.Round(schedule[7].BeginningBalance, 2), 4484.84);
            Assert.AreEqual(schedule[7].PaymentNumber, 8);
            Assert.AreEqual(Math.Round(schedule[7].TotalPayment, 2), 95.51);
            Assert.AreEqual(Math.Round(schedule[7].RemainingBalance, 2), 4409.89);
        }

        [TestMethod()]
        public void GenerateScheduleTest2()
        {
            AmortizationParameters parameters = new AmortizationParameters();
            parameters.PrincipalLoanAmount = 12000;
            parameters.NumberOfPayments = 72;
            parameters.AnnualInterestRate = 2.95;

            var schedule = service.GenerateSchedule(parameters);
            Assert.AreEqual(181.61, Math.Round(schedule[71].BeginningBalance, 2));
            Assert.AreEqual(72, schedule[71].PaymentNumber);
            Assert.AreEqual(182.06, Math.Round(schedule[71].TotalPayment, 2));
            Assert.AreEqual(0, Math.Round(schedule[71].RemainingBalance, 2));
            Assert.AreEqual(1108.02, Math.Round(schedule[71].CumulativeInterestPaid , 2));
        }
    }
}