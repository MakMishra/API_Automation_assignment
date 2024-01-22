using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Automation.Models
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public string[] Errors { get; set; }
    }

    public class AccountDetails
    {
        public int NewBalance { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
    }
}