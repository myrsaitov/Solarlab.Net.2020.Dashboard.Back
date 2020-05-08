using DataAccess.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class Context: IdentityDbContext<ApplicationUser>
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<Advertisement> Advertisements { get; set; }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<AdvertTag> AdvertTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            //Many-To-Many
            modelBuilder.Entity<AdvertTag>()
            .HasKey(t => new { t.AdvertId, t.TagId });
            
           
            
            
            modelBuilder.Entity<AdvertTag>()
                .HasOne(pt => pt.Advertisement)
                .WithMany(p => p.AdvertTags)
                .HasForeignKey(pt => pt.AdvertId);

            modelBuilder.Entity<AdvertTag>()
                .HasOne(pt => pt.Tag)
                .WithMany(t => t.Advertisements)
                .HasForeignKey(pt => pt.TagId);



            var advertisements = new[]
            {
                new Advertisement
                {
                    Id = 1,
                    Title = "Объявление 1",
                    Body = "Описание объявления 1"
                },
                new Advertisement
                {
                    Id = 2,
                    Title = "Объявление 2",
                    Body = "Описание объявления 2"
                }
            };




            var categories = new[]
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
                    new Category
               {
                     Id = 7,
                        Name = "Животные",
               },
           };
            modelBuilder.Entity<Category>().HasData(categories);
        }
    }
}
