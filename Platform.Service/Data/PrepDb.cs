using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Platform.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Platform.Service.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("--> Seeding Data...");

                context.Platforms.AddRange(
                        new PlatForm() { Name = "Dot Net", Publisher = "Microsoft", Cost = "Free" },
                        new PlatForm() { Name = "Sql Server Express", Publisher = "Microsoft", Cost = "Free" },
                        new PlatForm() { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" }
                    );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}
