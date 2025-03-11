using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Models.Responses
{
    public class DashboardStatistics
    {
        public Dictionary<int, int> TotalArticlesPerYear { get; set; } = new Dictionary<int, int>();
        public Dictionary<DateTime, int> TotalArticlesPerMonth { get; set; } = new Dictionary<DateTime, int>();
        public Dictionary<DateTime, int> TotalArticlesPerWeek { get; set; } = new Dictionary<DateTime, int>();
        public Dictionary<DateTime, int> TotalArticlesPerDay { get; set; } = new Dictionary<DateTime, int>();

        public Dictionary<DateTime, int> ArticlesPublishedPerMonth { get; set; } = new Dictionary<DateTime, int>();
        public Dictionary<DateTime, int> ArticlesPublishedPerWeek { get; set; } = new Dictionary<DateTime, int>();
        public Dictionary<DateTime, int> ArticlesPublishedPerDay { get; set; } = new Dictionary<DateTime, int>();

        public Dictionary<DateTime, int> ArticlesPublishedPerPeriod { get; set; } = new Dictionary<DateTime, int>();
        public Dictionary<DateTime, int> TotalArticlesPerPeriod { get; set; } = new Dictionary<DateTime, int>();

        public int ActiveArticlesCount { get; set; }
        public int InactiveArticlesCount { get; set; }
    }
}