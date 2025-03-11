using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models.Requests
{
    public class CategoryRequest
    {
        [Required(ErrorMessage = "Category Name is required")]
        public string? CategoryName { get; set; }

        public string? CategoryDescription { get; set; }

        public int? ParentCategoryID { get; set; }

        public bool IsActive { get; set; }
    }
}
