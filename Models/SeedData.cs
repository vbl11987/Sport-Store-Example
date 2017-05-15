using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace SportsStore.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app){
            SportsStoreDbContext context = app.ApplicationServices.GetRequiredService<SportsStoreDbContext>();

            if(!context.Products.Any()){
                context.Products.AddRange(
                    new Product {
                        Name = "Kayak",
                        Description = "One persons boat",
                        Category = "Watersports",
                        Price = 300
                    },
                    new Product {
                        Name = "LifeJacket",
                        Description = "Protective jacket",
                        Category = "Watersports",
                        Price = 48.95m
                    },
                    new Product {
                        Name = "Soccer Ball",
                        Description = "FIFA-approved",
                        Category = "Soccer",
                        Price = 19.50m
                    },
                    new Product {
                        Name = "Corner Flags",
                        Description = "For Soccer fields",
                        Category = "Soccer",
                        Price = 34.50m
                    },
                    new Product {
                        Name = "LifeJacket",
                        Description = "Protective jacket",
                        Category = "Watersports",
                        Price = 48.95m
                    }
                );
                context.SaveChanges();
            }
        }
    }
}