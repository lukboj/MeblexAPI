using MeblexData.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeblexData.Models.ShoppingCart;
using MeblexData.Models.Order;

namespace MeblexData.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products {get; set;}
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Opinion> Opinions { get; set; }

        public DbSet<OrderDetail> OrdersDetails { get; set; }
        public DbSet<ApplicationUser> AplicationUsers { get; set; }



    }
}
