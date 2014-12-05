using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace WebShop
{
    public class MainDB : DbContext
    {
        public MainDB()
            : base("WebShop")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MainDB, Migrations.Configuration>());

        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Konsol> Konsols { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public Order GetOrderbyId(int id)
        {
            /*Create procedure spGetOrderById (@id int)
                As
                Begin
                select id, personId
                from orders 
                where id = @id
                end 
            */
            Order order = new Order();
            SqlParameter orderparameter = new SqlParameter("@id", id);
            object[] sqlParam = new object[] { orderparameter };
            order = this.Database.SqlQuery<Order>("spGetOrderById @Id", sqlParam).Single();

            return order;
        }
        
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
