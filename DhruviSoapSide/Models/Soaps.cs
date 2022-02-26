using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DhruviSoapSide.Models
{
    public class Soaps
    {
        public int Id { get; set; }
        
        [Display(Name = "Product Name")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string ProductName { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string Aroma { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Shape { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(5)]
        [Required]
        public int Quality { get; set; }

        [Display(Name = "Brand Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(30)]
        public string BrandName { get; set; }

        public decimal Weight { get; set; }
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }
}
