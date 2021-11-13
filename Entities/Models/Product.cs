using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("Products")]
    public class Product
    {
        [Column("ProductID")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Product Name is required")]
        [StringLength(40, ErrorMessage = "Product name cannot be longer than 40 characters")]
        public string ProductName { get; set; }
        public int? SupplierID { get; set; }
        [StringLength(40, ErrorMessage = "Product name cannot be longer than 40 characters")]
        public string QuantityPerUnit { get; set; }
        [Column(TypeName = "money")]
        public decimal? UnitPrice { get; set; }
        public bool Discontinued { get; set; }

        // Nav
        [ForeignKey(nameof(Category))]
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
