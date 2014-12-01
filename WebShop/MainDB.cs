using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop
{
    public class MainDB : DbContext
    {
        public MainDB()
            : base("WebShop")
        {

        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Konsol> Konsols { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().
                HasMany(g => g.Genres).
                WithMany(p => p.Products).Map(
                    m =>
                    {
                        m.MapLeftKey("ProductId");
                        m.MapRightKey("GenreId");
                        m.ToTable("ProductGenre");
                    });

            modelBuilder.Entity<Product>().
                HasMany(c => c.Konsols).
                WithMany(p => p.Products).Map(
                    m =>
                    {
                        m.MapLeftKey("ProductId");
                        m.MapRightKey("KonsolId");
                        m.ToTable("ProductKonsol");
                    });
            base.OnModelCreating(modelBuilder);
        }
    }
}
