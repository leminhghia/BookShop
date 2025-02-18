using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class ApplicationDbContext: IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get;  set; }
        public DbSet<ShoppingCart> ShoppingCarts { get;  set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
             new Category { CatId = 1, Name = "Hành Động" },
             new Category { CatId = 2, Name = "Khoa Học" },
             new Category { CatId = 3, Name = "Lịch Sử" }
             );
            modelBuilder.Entity<Product>().HasData(
      new Product
      {
          ProId = 1,
          Title = "Fortune of Time",
          Author = "Billy Spark",
          Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
          ISBN = "SWD9999001",
          ListPrice = 99,
          Price = 90,
          CatId = 2,
          ImageUrl = ""
      },
         new Product
         {
             ProId = 2,
             Title = "Dark Skies",
             Author = "Nancy Hoover",
             Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
             ISBN = "CAW777777701",
             ListPrice = 40,
             Price = 30,
             CatId = 4,
             ImageUrl = ""

         },
         new Product
         {
             ProId = 3,
             Title = "Vanish in the Sunset",
             Author = "Julian Button",
             Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
             ISBN = "RITO5555501",
             ListPrice = 55,
             Price = 50,
             CatId = 2,
             ImageUrl = ""

         });
        }
    }
}
