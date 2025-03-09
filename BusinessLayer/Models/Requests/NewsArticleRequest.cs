using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models.Requests
{
    public class NewsArticleRequest
    {
        public string NewsTitle { get; set; }
        public string Headline { get; set; }
        public string NewsContent { get; set; }
        public string? NewsSource { get; set; }
        public string? NewsStatus { get; set; }
        public int CategoryID { get; set; }
        public int CreatedByID { get; set; }
        public List<int> TagIDs { get; set; } = new List<int>();
    }
}
