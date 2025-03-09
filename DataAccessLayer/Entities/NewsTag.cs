using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class NewsTag
    {
        public int NewsArticleID { get; set; }
        [ForeignKey("NewsArticleID")]
        public NewsArticle? NewsArticle { get; set; }

        public int TagID { get; set; }
        [ForeignKey("TagID")]
        public Tag? Tag { get; set; }
    }
}
