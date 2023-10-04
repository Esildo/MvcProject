using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;


namespace WebPetProject.Models
{
    public class SeedData
    {
        public static void EnSurePopilated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Kayak",
                        Description = "A boat for one person",
                        Category = "Watersports", Price = 275 
                    },
                    new Product
                    {
                        Name = "Lifejacket",
                        Description = "Protective and fashionaЫe",
                        Category = "Watersports",
                        Price = 48.95m
                    },
                    new Product
                    { 
                        Name = "Soccer Ball",
                        Description = "FIFA-approved size and weight",
                        Category = "Soccer", 
                        Price = 19.50m 
                    },
                    new Product
                    {
                        Name = "Corner Flags",
                        Description = "Give your playing field а professional touch",
                        Category = "Soccer",
                        Price = 34.95m
                    }, 
                    new Product
                    {
                        Name = "Stadium",
                        Description = "Flat-packed 35, 000-seat stadium",
                        Category = "Soccer",
                        Price = 79500
                    },
                    new Product
                    {
                        Name = "Thinking Сар",
                        Description = "Improve brain efficiency Ьу 75i",
                        Category = "Chess",
                        Price = 16
                    },  
                    new Product
                    {
                        Name = "Unsteady Chair",
                        Description = "Secretly give your opponent а disadvantage",
                        Category = "Chess",
                        Price = 29.95m
                    }, 
                    new Product 
                    {
                        Name = "Human Chess Board",
                        Description = "А fun game for the family",
                        Category = "Chess", Price = 75 } , 
                    new Product
                    {

                        Name = "Bling-Bling King",
                        Description = "Gold-plated, diamond-studded King",
                        Category = "Chess",
                        Price = 1200
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
