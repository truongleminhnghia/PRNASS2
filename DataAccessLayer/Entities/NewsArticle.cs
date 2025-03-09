using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class NewsArticle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NewsArticleID { get; set; }
        public string? NewsTitle { get; set; }
        public string? Headline { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string? NewsContent { get; set; }
        public string? NewsSource { get; set; }
        public string? NewsStatus { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public int? CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public Category? Category { get; set; }

        public int? CreatedByID { get; set; }
        [ForeignKey("CreatedByID")]
        public SystemAccount? CreatedBy { get; set; }

        public int? UpdatedByID { get; set; }
        [ForeignKey("UpdatedByID")]
        public SystemAccount? UpdatedBy { get; set; }
        public ICollection<NewsTag>? NewsTags { get; set; }
    }
}
