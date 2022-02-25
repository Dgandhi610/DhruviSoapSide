using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DhruviSoapSide.Models
{
    public class Soaps
    {
        public int Id { get; set; }
        
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        public string Aroma { get; set; }
        public string Shape { get; set; }

        public int Quality { get; set; }

        [Display(Name = "Brand Name")]
        public string BrandName { get; set; }

        public decimal Weight { get; set; }
        public decimal Price { get; set; }
    }
}
