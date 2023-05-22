using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ConsoleApp2
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }

    public class SqliteDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("FileName=sqldb1", option =>
            {
                option.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Products", "test");
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(k => k.Id);
                entity.HasIndex(i => i.Name).IsUnique();
            });
            base.OnModelCreating(modelBuilder);
        }
    }


}