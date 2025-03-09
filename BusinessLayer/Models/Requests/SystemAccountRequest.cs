using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models.Requests
{
    public class SystemAccountRequest
    {
        public string? AccountName { get; set; }
        public string? AccountEmail { get; set; }
        public string? AccountRole { get; set; }
        public string? AccountPassword { get; set; }
        public string? AccountStatus { get; set; }
    }
}
