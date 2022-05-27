using GroceryDelivery.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GroceryDelivery.DataLayer
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new GroceryDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<GroceryDbContext>>()))
            {
                if (context.Menubars.Any())
                {
                    return;   // Data was already seeded
                }
                context.Menubars.AddRange(
                    new Menubar
                    {
                        Id = 1,
                        Title = "Home",
                        Url = "~/",
                        OpenInNewWindow = false
                    },
                new Menubar
                {
                    Id = 2,
                    Title = "Electronics",
                    Url = "~/Home/Index/1",
                    OpenInNewWindow = false
                },
                new Menubar
                {
                    Id = 3,
                    Title = "TVs Appliance",
                    Url = "~/Home/Index/2",
                    OpenInNewWindow = false
                },
                new Menubar
                {
                    Id = 4,
                    Title = "Mean",
                    Url = "~/Home/Index/3",
                    OpenInNewWindow = false
                },
                new Menubar
                {
                    Id = 5,
                    Title = "Woman",
                    Url = "~/Home/Index/4",
                    OpenInNewWindow = false
                },
                new Menubar
                {
                    Id = 6,
                    Title = "Bady Kids",
                    Url = "~/Home/Index/5",
                    OpenInNewWindow = false
                },
                new Menubar
                {
                    Id = 7,
                    Title = "Home Furniture",
                    Url = "~/Home/Index/6",
                    OpenInNewWindow = false
                },
                new Menubar
                {
                    Id = 8,
                    Title = "Sports Book More",
                    Url = "~/Home/Index/7",
                    OpenInNewWindow = false
                });
                context.SaveChanges();
                if (context.Products.Any())
                {
                    return;   // Data was already seeded
                }
                context.Products.AddRange(
                new Product
                {
                    ProductId = 1,
                    ProductName = "Samsung",
                    Description = "RAM-3 GB, SSD-128 GB,Processor-Snap Dragon 805, Retina Display-3",
                    Amount = 12900,
                    stock = 10,
                    CatId = 1
                },
                new Product
                {
                    ProductId = 2,
                    ProductName = "Samsung - TV",
                    Description = "Size - 72, SSD-128 GB, Processor-Snap Dragon 805, Screen - 4500X3000PX",
                    Amount = 12990,
                    stock = 13,
                    CatId = 2
                },
                new Product
                {
                    ProductId = 3,
                    ProductName = "Sports Runnig Shoes - Reebok",
                    Description = "Size - 8, Color - Brown White",
                    Amount = 1900,
                    stock = 101,
                    CatId = 3
                },
                new Product
                {
                    ProductId = 4,
                    ProductName = "One Pic - Kurti",
                    Description = "Size - 40, Height - 5Ft, Color - Pink",
                    Amount = 990,
                    stock = 183,
                    CatId = 4
                });
                context.SaveChanges();
            }
        }
    }
}
