using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models.Responses
{
    public class SystemAccountResponse
    {
        public int AccountID { get; set; }
        public string? AccountName { get; set; }
        public string? AccountEmail { get; set; }
        public string? AccountRole { get; set; }
        public string? AccountPassword { get; set; } 
        public string? AccountStatus { get; set; }
    }
}
