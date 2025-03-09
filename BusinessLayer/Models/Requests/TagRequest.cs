using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models.Requests
{
    public class TagRequest
    {
        public string TagName { get; set; } = string.Empty;
        public string? Note { get; set; }
    }
}
