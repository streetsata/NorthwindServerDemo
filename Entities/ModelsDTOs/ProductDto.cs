using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ModelsDTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}
