using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models.Requests
{
    public class CategoryRequest
    {
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
        public int? ParentCategoryID { get; set; }
        public bool IsActive { get; set; } = true;
        public Category? ParentCategory { get; set; }
    }
}
