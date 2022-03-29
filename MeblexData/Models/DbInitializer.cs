using MeblexData.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
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
      
        private static Dictionary<string, Category> categories;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var genresList = new Category[]
                    {
                        new Category { Name = "Łóżko", Description = "Wygodne łóżko" },
                        new Category { Name = "Stół", Description = "Stół do salonu" },
                        new Category { Name = "Krzesło", Description = "Wygodne krzesła" },
                        new Category { Name = "Biurko", Description = "Idealne do nauki" },
                        new Category { Name = "Stolik", Description = "Stolik idealny koło łóżka" }

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

        public static void Seed(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> rolemanager, AppDbContext appDbContext)
        {
            appDbContext.Database.EnsureCreated();


            SeedRoles(rolemanager);
            SeedUser(userManager);

            if (!appDbContext.Categories.Any())
            {
                appDbContext.Categories.AddRange(Categories.Select(c => c.Value));
                appDbContext.SaveChanges();

            }

            if (!appDbContext.Products.Any())
            {
                appDbContext.AddRange
                    (
                    new Product
                    {
                        Name = "Magiczny stolik",
                        Price = 500,
                        Lenght = 90,
                        Width = 100,
                        ImageUrl = "/imagies/stolik1.png",
                        Height = 30,
                        Weight = 20,
                        Description = "Porządny stolik do wielu zadań",
                        Material = "Drewno Machoniowe",
                        Color = "Czarny",
                        IsPreferred = true,
                        Category = Categories["Stolik"]
                    },
                    new Product
                    {
                        Name = "Magiczne Krzesło",
                        Price = 900,
                        Lenght = 100,
                        Width = 50,
                        ImageUrl = "/imagies/fotel1.png",
                        Height = 30,
                        Weight = 15,
                        Description = "Porządne krzesło do wielu zadań",
                        Material = "Drewno",
                        Color = "Biały",
                        IsPreferred = true,
                        Category = Categories["Krzesło"]
                    },
                    new Product
                    {
                        Name = "Magiczne Biurko",
                        Price = 1000,
                        Lenght = 100,
                        Width = 100,
                        ImageUrl = "/imagies/biurko1.png",
                        Height = 70,
                        Weight = 30,
                        Description = "Porządne biurko do wielu zadań",
                        Material = "Drewno",
                        Color = "Czarny",
                        IsPreferred = true,
                        Category = Categories["Biurko"]
                    },
                    new Product
                    {
                        Name = "Magiczny stół",
                        Price = 1200,
                        Lenght = 150,
                        Width = 150,
                        ImageUrl = "/imagies/stolik3.png",
                        Height = 70,
                        Weight = 19,
                        Description = "Porządny stół do wielu zadań",
                        Material = "Drewno",
                        Color = "Czarny",
                        IsPreferred = true,
                        Category = Categories["Stół"]
                    },
                    new Product
                    {
                        Name = "Magiczne Łóżko",
                        Price = 800,
                        Lenght = 200,
                        Width = 80,
                        Height = 40,
                        Weight = 30,
                        ImageUrl = "/imagies/lozko1.png",
                        Description = "Porządne łożko do wielu zadań",
                        Material = "Drewno",
                        Color = "Czarny",
                        IsPreferred = true,
                        Category = Categories["Łóżko"]
                    },
                    new Product
                    {
                        Name = "Magiczne Łóżko",
                        Price = 300,
                        Lenght = 50,
                        Width = 50,
                        Height = 30,
                        Weight = 3,
                        ImageUrl = "/imagies/lozko2.png",
                        Description = "Porządne łóżko do wielu zadań",
                        Material = "Drewno",
                        Color = "Białe",
                        IsPreferred = true,
                        Category = Categories["Łóżko"]
                    },
                    new Product
                    {
                        Name = "Boskie Łóżko",
                        Price = 2000,
                        Lenght = 200,
                        Width = 150,
                        Height = 35,
                        Weight = 30,
                        ImageUrl = "/imagies/lozko3.png",
                        Description = "Porządne łożko do wielu zadań",
                        Material = "Drewno",
                        Color = "Zielone",
                        IsPreferred = true,
                        Category = Categories["Łóżko"]
                    },
                    new Product
                    {
                        Name = "Kolorowe Łóżko",
                        Price = 5300,
                        Lenght = 50,
                        Width = 50,
                        Height = 30,
                        Weight = 3,
                        ImageUrl = "/imagies/lozko4.png",
                        Description = "Porządne i dobre łożko do wielu zadań",
                        Material = "Drewno machoniowe",
                        Color = "Czarny",
                        IsPreferred = true,
                        Category = Categories["Łóżko"]
                    },
                    new Product
                    {
                        Name = "Drewniane Łóżko",
                        Price = 500,
                        Lenght = 100,
                        Width = 50,
                        Height = 30,
                        Weight = 3,
                        ImageUrl = "/imagies/lozko5.png",
                        Description = "Porządne łóżko do spania",
                        Material = "Sosna",
                        Color = "Czarny",
                        IsPreferred = true,
                        Category = Categories["Łóżko"]
                    }
                    );
                appDbContext.SaveChanges();


            }


        }
        private static void SeedUser(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByNameAsync("admin@localhost.pl").Result == null)
            {
                var user = new IdentityUser
                {
                    UserName = "admin@localhost.pl",
                    Email = "admin@localhost.pl"
                };

                var result = userManager.CreateAsync(user, "Password123!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
            {

            }
        }

        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Administrator"
                };
                var result = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Default").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Default"
                };
                var result = roleManager.CreateAsync(role).Result;
            }
        }





    }

}
