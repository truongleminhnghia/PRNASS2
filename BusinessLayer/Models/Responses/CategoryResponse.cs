using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace BusinessLayer.Models.Responses
{
    public class CategoryResponse
    {
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
        public int? ParentCategoryID { get; set; } // Add this line
        public string? ParentCategoryName { get; set; }
        public bool IsActive { get; set; }
    }
}
