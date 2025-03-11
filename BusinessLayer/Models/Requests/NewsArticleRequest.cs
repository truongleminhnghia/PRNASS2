using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.Models.Requests
{
    public class NewsArticleRequest
    {
        [Required(ErrorMessage = "Title is required")]
        public string NewsTitle { get; set; }

        public string? Headline { get; set; }
        public string? NewsContent { get; set; }
        public string? NewsSource { get; set; }
        public string? NewsStatus { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedDate { get; set; }
        public int? CategoryID { get; set; }
        public int? CreatedByID { get; set; }
        public int? UpdatedByID { get; set; }

        public List<int> TagIDs { get; set; } = new List<int>();
    }
}
