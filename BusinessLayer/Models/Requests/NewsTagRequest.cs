using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models.Requests
{
    public class NewsTagRequest
    {
        public int NewsArticleID { get; set; }
        public List<int> TagIDs { get; set; } = new List<int>();
    }
}
