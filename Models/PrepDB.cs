using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Blogger.Models
{
    public static class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<ColorContext>());
            }

        }

        public static void SeedData(ColorContext context)
        {
            System.Console.WriteLine("Applying Migrations...");
            context.Database.Migrate();

            if(!context.ColorItems.Any())
            {
                System.Console.WriteLine("Adding data - Seeding!");
                context.AddRange(
                    new Color { ColorName = "red" },
                    new Color { ColorName = "blue" },
                    new Color { ColorName = "yellow" },
                    new Color { ColorName = "green" },
                    new Color { ColorName = "orange" }
                );
                context.SaveChanges();
            }else
            {
                System.Console.WriteLine("Already have data - not seeding!");
            }
        }
    }
}