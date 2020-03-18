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

        public DbSet<Category> Comment { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AdvertTag>()
            .HasKey(t => new { t.AdvertId, t.TagId });

            modelBuilder.Entity<AdvertTag>()
                .HasOne(pt => pt.Advertisement)
                .WithMany(p => p.Tags)
                .HasForeignKey(pt => pt.AdvertId);

            modelBuilder.Entity<AdvertTag>()
                .HasOne(pt => pt.Tag)
                .WithMany(t => t.Advertisements)
                .HasForeignKey(pt => pt.TagId);

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
