using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagementAPI.Models
{
    // to run the migrations
    public class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<OrderContext>());
            }

        }

        public static void SeedData(OrderContext context)
        {
            Console.WriteLine("Applying Migrations...");

            context.Database.Migrate();

            if (!context.OrderItems.Any())
            {
                Console.WriteLine("Adding data - seeding");
                context.OrderItems.AddRange(
                    new Order() { Order_Status = "Test1" },
                    new Order() { Order_Status = "Test2" }
                    );
                context.SaveChanges();
            }
            else
            {
                System.Console.WriteLine("Already have data - not seeding");
            }
        }
    }
}
