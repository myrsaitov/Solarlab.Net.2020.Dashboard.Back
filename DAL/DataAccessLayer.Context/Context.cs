using System;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var categories = new Category[]
           {
                new Category
                {
                    Id = 1,
                    Name = "Транспорт",
                },
                new Category
                {
                    Id = 2,
                    Name = "Недвижимость",
                },
                 new Category
                {
                    Id = 3,
                    Name = "Мебель",
                },
                  new Category
                {
                    Id = 4,
                    Name = "Одежда",
                },
                   new Category
                {
                    Id = 5,
                    Name = "Бытовая техника",
                },
                    new Category
                {
                    Id = 6,
                    Name = "Косметика",
                },
           };
            modelBuilder.Entity<Category>().HasData(categories);
        }
    }
}
