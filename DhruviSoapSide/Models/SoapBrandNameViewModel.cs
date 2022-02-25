using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace DhruviSoapSide.Models
{
    public class SoapBrandNameViewModel
    {
        public List<Soaps> Soaps { get; set; }
        public SelectList BrandName { get; set; }
        public string SoapBrand { get; set; }
        public string SearchString { get; set; }
    }
}