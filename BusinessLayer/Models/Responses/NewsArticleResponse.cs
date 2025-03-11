using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.Models.Responses
{
    public class NewsArticleResponse
    {
        public int NewsArticleID { get; set; }
        public string NewsTitle { get; set; }
        public string? Headline { get; set; }
        public string? NewsContent { get; set; }
        public string? NewsSource { get; set; }
        public string? NewsStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? CategoryID { get; set; }
        public int? CreatedByID { get; set; }
        public int? UpdatedByID { get; set; }

        public List<string> Tags { get; set; }
    }
}
