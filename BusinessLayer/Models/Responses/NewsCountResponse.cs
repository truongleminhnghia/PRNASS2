using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models.Responses
{
    public class NewsCountResponse
    {
        public int NewsCountToday { get; set; }
        public int NewsCountThisMonth { get; set; }
        public int NewsCountThisYear { get; set; }
    }

}
