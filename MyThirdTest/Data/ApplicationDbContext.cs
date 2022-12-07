using System;
using Microsoft.EntityFrameworkCore;
using MyThirdTest.Models;

namespace MyThirdTest.Data
{
	public class ApplicationDbContext : DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Product>().ToTable("Products", "Projet");
        }

        public DbSet<Product> Products { get; set; }
    }
}

