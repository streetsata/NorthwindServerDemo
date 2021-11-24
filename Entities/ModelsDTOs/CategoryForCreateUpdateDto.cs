using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.ModelsDTOs
{
    public class CategoryForCreateUpdateDto
    {
        [Required(ErrorMessage = "Category Name is required")]
        [StringLength(15, ErrorMessage = "Category name cannot be longer than 15 characters")]
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
