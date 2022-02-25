using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DhruviSoapSide.Data;
using System;
using System.Linq;
namespace DhruviSoapSide.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DhruviSoapSideContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<DhruviSoapSideContext>>()))
            {
                // Look for any products.
                if (context.Soaps.Any())
                {
                    return;   // DB has been seeded
                }

                context.Soaps.AddRange(
                    new Soaps
                    {
                        ProductName = "Oatmilk and Honey Soap",
                        Aroma = "Honey",
                        Shape = "Circle",
                        Quality = 5,
                        BrandName = "WILD PRAIRIE",
                        Weight = 100.00M,
                        Price = 7.95M
                    },

                    new Soaps
                    {
                        ProductName = "Sunflower Soap",
                        Aroma = "Unisex scent",
                        Shape = "Circle",
                        Quality = 4 ,
                        BrandName = "WILD PRAIRIE",
                        Weight = 100.00M,
                        Price = 7.95M
                    },

                    new Soaps
                    {
                        ProductName = "Matcha Latte Artisan Soap",
                        Aroma = "Soothing Blend of Chamoline, wild violet, gree-tea leaves",
                        Shape = "Square",
                        Quality =5,
                        BrandName = "Artisan Soap",
                        Weight = 100.00M,
                        Price = 12.00M
                    },

                    new Soaps
                    {
                        ProductName = "Strawberry Patch Frosted Soap",
                        Aroma = "Summer Strawberry",
                        Shape = "Circle",
                        Quality = 4 / 10,
                        BrandName = "Artisan Soap",
                        Weight = 189.00M,
                        Price = 14.00M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
