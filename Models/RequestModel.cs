using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Automation.Models
{
    public class CreateAccountRequest
    {
        public int InitialBalance { get; set; }
        public string AccountName { get; set; }
        public string Address { get; set; }
    }

    public class DepositRequest
    {
        public string AccountNumber { get; set; }
        public int Amount { get; set; }
    }

    public class WithdrawRequest
    {
        public string AccountNumber { get; set; }
        public int Amount { get; set; }
    }
}