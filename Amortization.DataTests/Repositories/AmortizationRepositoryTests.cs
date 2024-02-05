using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amortization.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Amortization.Data.Repositories.Tests
{
    [TestClass()]
    public class AmortizationRepositoryTests
    {

        protected ApplicationDbContext? DataContext { get; set; }
        protected AmortizationRepository AmortizationRepository { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-53bc9b9d-9d6a-45d4-8429-2a2761773502;Trusted_Connection=True;Multiple Active Result Sets=True").Options;
            DataContext = new ApplicationDbContext(options);
            AmortizationRepository = new AmortizationRepository(DataContext);
        }

        [TestMethod()]
        public async Task SaveUserTest()
        {
            User user = new User();
            user.UserName = "Test";
            await AmortizationRepository.SaveUserAsync(user);
            Assert.IsTrue(user.UserId > 0);
        }

        [TestMethod()]
        public async Task GetUserTest()
        {
            var user = await AmortizationRepository.GetUserAsync("test");
            Assert.IsNotNull(user);
        }

        [TestMethod()]
        public void SaveMortgageParameterAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public async Task GetUserHistoryAsyncTest()
        {
            var list = await AmortizationRepository.GetUserHistoryAsync("test");
            Assert.IsNotNull(list);
        }

        [TestMethod()]
        public async Task GetUserHistoryAsyncTest2()
        {
            var list = await AmortizationRepository.GetUserHistoryAsync("GINSPIRON\\giuse");
            Assert.IsNotNull(list);
            Assert.IsTrue(list.Count() > 0);
        }
    }
}