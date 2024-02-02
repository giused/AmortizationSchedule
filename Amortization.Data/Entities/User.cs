using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amortization.Data
{
    public class User
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public ICollection<MortgageParameter> Parameters { get; set; }
    }
}
