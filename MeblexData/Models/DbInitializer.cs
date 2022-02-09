using MeblexData.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeblexData.Models
{
    public class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));
            }

            if (!context.Products.Any())
            {
                context.AddRange
                    (
                    new Product
                    {
                        Name = "Magiczny stolik",
                        Price = 300,
                        Lenght = 50,
                        Width = 50,
                        ImageUrl ="/imagies/basic.png",
                        Height = 30,
                        Weight = 3,
                        Description = "Porządny stolik do wielu zadań",
                        Material = "Drewno",
                        Color = "Czarny",
                        IsPreferred = false,
                        Category = Categories["Stolik"]
                    },
                    new Product
                    {
                        Name = "Magiczne Krzesło",
                        Price = 300,
                        Lenght = 50,
                        Width = 50,
                        ImageUrl = "/imagies/basic.png",
                        Height = 30,
                        Weight = 3,
                        Description = "Porządny stolik do wielu zadań",
                        Material = "Drewno",
                        Color = "Czarny",
                        IsPreferred = true,
                        Category = Categories["Krzesło"]
                    },
                    new Product
                    {
                        Name = "Magiczne Biurko",
                        Price = 300,
                        Lenght = 50,
                        Width = 50,
                        ImageUrl = "/imagies/basic.png",
                        Height = 30,
                        Weight = 3,
                        Description = "Porządny stolik do wielu zadań",
                        Material = "Drewno",
                        Color = "Czarny",
                        IsPreferred = true,
                        Category = Categories["Biurko"]
                    },
                    new Product
                    {
                        Name = "Magiczny stół",
                        Price = 300,
                        Lenght = 50,
                        Width = 50,
                        ImageUrl = "/imagies/basic.png",
                        Height = 30,
                        Weight = 3,
                        Description = "Porządny stolik do wielu zadań",
                        Material = "Drewno",
                        Color = "Czarny",
                        IsPreferred = false,
                        Category = Categories["Stół"]
                    },
                    new Product
                    {
                        Name = "Magiczne Łóżko",
                        Price = 300,
                        Lenght = 50,
                        Width = 50,
                        Height = 30,
                        Weight = 3,
                        ImageUrl = "/imagies/basic.png",
                        Description = "Porządny stolik do wielu zadań",
                        Material = "Drewno",
                        Color = "Czarny",
                        IsPreferred = true,
                        Category = Categories["Łóżko"]
                    }
                    
                    );
            }
            context.SaveChanges();
        }


        private static Dictionary<string, Category> categories;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var genresList = new Category[]
                    {
                        new Category { Name = "Łóżko", Description="Wygodne łóżko" },
                        new Category { Name = "Stół", Description="Stół do salonu" },
                        new Category { Name = "Krzesło", Description="Wygodne krzesła" },
                        new Category { Name = "Biurko", Description="Idealne do nauki" },
                        new Category { Name = "Stolik", Description="Stolik idealny koło łóżka" }

                    };

                    categories = new Dictionary<string, Category>();

                    foreach (Category genre in genresList)
                    {
                        categories.Add(genre.Name, genre);
                    }
                }

                return categories;
            }
        }


    }
    
}
