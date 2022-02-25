using System;
using System.ComponentModel.DataAnnotations;

namespace DhruviSoapSide.Models
{
    public class Soaps
    {
        public int Id { get; set; } 
        public string ProductName { get; set; }
        public string Aroma { get; set; }
        public string Shape { get; set; }

        public int Quality { get; set; }

        public string BrandName { get; set; }

        public decimal Weight { get; set; }
        public decimal Price { get; set; }
    }
}
