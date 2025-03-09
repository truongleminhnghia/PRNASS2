using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models.Responses
{
    public class NewsArticleResponse
    {
        public int NewsArticleID { get; set; }
        public string? NewsTitle { get; set; }
        public string? Headline { get; set; }
        public string? NewsContent { get; set; }
        public string? NewsSource { get; set; }
        public string? NewsStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public int CreatedByID { get; set; }
        public string? CreatedByName { get; set; }
        public List<TagResponse> Tags { get; set; } = new List<TagResponse>();
    }
}
