using Amortization.Data;
using Amortization.Data.Repositories;
using Amortization.Identity;
using Amortization.Models;

namespace Amortization.Services
{
    public class AmortizationService : IAmortizationService
    {
        public IIdentityService IdentityService { get; set; }

        public IAmortizationRepository AmortizationRepository { get; set; }

        /// <summary>
        /// Constructor for Amortization service
        /// </summary>
        /// <param name="identityService"></param>
        /// <param name="amortizationRepository"></param>
        public AmortizationService(IIdentityService identityService, IAmortizationRepository amortizationRepository)
        {
            IdentityService = identityService;
            AmortizationRepository = amortizationRepository;
        }

        /// <summary>
        /// Calculates monthly loan payment based on parameters provided
        /// </summary>
        /// <param name="parameters">Mortgage amortization parameters</param>
        /// <returns>Monthly mortgage payment</returns>
        public double CalculateLoanPayment(AmortizationParameters parameters)
        {
            double monthlyInterest = parameters.MonthlyInterestRate / 100;
            double enumerator = monthlyInterest * Math.Pow((1 + monthlyInterest), parameters.NumberOfPayments);
            double denominator = Math.Pow((1 + monthlyInterest), parameters.NumberOfPayments) - 1;
            double payment = parameters.TotalLoanAmount * (enumerator / denominator);
            return payment;
        }

        /// <summary>
        /// Generates schedule based on parameters supplied
        /// </summary>
        /// <param name="parameters">Mortgage amortization parameters</param>
        /// <returns>List of Mortgage Payments</returns>
        public async Task<List<MortgagePayment>> GenerateScheduleAsync(AmortizationParameters parameters)
        {
            double remainingBalance = parameters.TotalLoanAmount;
            double monthlyPayment = CalculateLoanPayment(parameters);
            DateTime paymentDate = DateTime.Now.AddMonths(1);
            double monthlyInterest = parameters.MonthlyInterestRate / 100;
            double cumulativeInterest = 0;

            List<MortgagePayment> schedule = new List<MortgagePayment>();
            MortgagePayment payment;
            for (int i = 1; i <= parameters.NumberOfPayments; i++)
            {
                payment= new MortgagePayment();
                payment.TotalPayment = monthlyPayment;
                payment.BeginningBalance = remainingBalance;
                payment.MonthlyInterestRate = monthlyInterest;
                payment.PaymentDate = paymentDate;
                payment.PaymentNumber = i;
                cumulativeInterest += payment.InterestPayment;
                payment.CumulativeInterestPaid = cumulativeInterest;
                schedule.Add(payment);

                remainingBalance = payment.RemainingBalance;
                paymentDate = paymentDate.AddMonths(1);
            }
            return await Task.FromResult(schedule);
        }

        /// <summary>
        /// Saves
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<int> SaveUserAmortizationQueryAsync(string userName, AmortizationParameters parameters)
        {
            MortgageParameter dataParameters = new MortgageParameter() { 
                AnnualInterestRate = parameters.AnnualInterestRate, 
                NumberOfPayments = parameters.NumberOfPayments, 
                PrincipalLoanAmount = parameters.TotalLoanAmount };

            User user = await AmortizationRepository.GetUserAsync(userName);

            if (user == null)
            {
                user = new User();
                user.UserName = userName;
                await AmortizationRepository.SaveUserAsync(user);
            }

            int id = await AmortizationRepository.SaveMortgageParameterAsync(dataParameters, user);
            return id;
        }

        public async Task<List<MortgagePayment>> GenerateScheduleAsync(int mortgageParameterId)
        {
            MortgageParameter parameters = await AmortizationRepository.GetMortgageParametersAsync(mortgageParameterId);
            return await GenerateScheduleAsync(new AmortizationParameters { AnnualInterestRate = parameters.AnnualInterestRate, NumberOfPayments = parameters.NumberOfPayments, TotalLoanAmount = parameters.PrincipalLoanAmount});
        }


        public async Task<List<AmortizationParameters>> GetUserHistoryAsync(string userName)
        {
            User user = await AmortizationRepository.GetUserAsync(userName);
            if(user == null)
            {
                return new List<AmortizationParameters>();
            }
            var history = await AmortizationRepository.GetUserHistoryAsync(userName);
            return history.Select(x => ModelFactory.ToModel(x)).ToList();
        }

        public async Task<AmortizationParameters> GetParametersAsync(int id)
        {
            MortgageParameter parameters = await AmortizationRepository.GetMortgageParametersAsync(id);
            return ModelFactory.ToModel(parameters);
        }
    }
}
