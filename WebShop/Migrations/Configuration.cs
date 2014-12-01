namespace WebShop.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebShop.MainDB>
    {
        public Configuration()
        {

            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(WebShop.MainDB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Genres.AddOrUpdate(g => g.GenreName,
                new Genre { GenreName = "Action" },
                new Genre { GenreName = "Adventure" },
                new Genre { GenreName = "FPS" },
                new Genre { GenreName = "Driving" },
                new Genre { GenreName = "Fighting" },
                new Genre { GenreName = "Simulation" }
                );

            Konsol k1 =new Konsol() { ConsoleName = "Playstation 4" };
            Konsol k2 =new Konsol() { ConsoleName = "Xbox One"};
            Konsol k3 = new Konsol() { ConsoleName = "PC" };
            Konsol k4 = new Konsol() { ConsoleName = "Xbox 360" };
            Konsol k5 =  new Konsol() { ConsoleName = "Wii U" };
            Konsol k6 =  new Konsol() { ConsoleName = "Playstation 3" };

            context.Konsols.AddOrUpdate(c => c.ConsoleName,
                k1,
                k2,
                k3,
                k4,
                k5,
                k6);
            
               
            context.SaveChanges();

            Product p1 = 
                new Product() { ProductName = "Assasins Creed Black Flag", Price = 599, YearOfRelease = 2014, PicLocation = "~/Content/AssCreedBF.jpg" };
           
            context.Products.AddOrUpdate(
                a => new {a.ProductName, a.PicLocation },
                p1);
            Product p2 =
                new Product() { ProductName = "Destiny", Price = 699, YearOfRelease = 2014, PicLocation = "~/Content/destiny.jpg"};
            context.Products.AddOrUpdate(
                 c => new {c.ProductName, c.PicLocation});
            Product p3 =
                new Product() { ProductName = "Evil Within", Price = 499, YearOfRelease = 2013, PicLocation = "~/Content/EvilwithinPS4.jpg"};
            context.Products.AddOrUpdate(
                 d => new {d.ProductName, d.PicLocation});
            Product p4 =
               new Product() { ProductName = "GTA V", Price = 699, YearOfRelease = 2014, PicLocation = "~/Content/gta5ps4.jpg" };
            context.Products.AddOrUpdate(
                 e => new { e.ProductName, e.PicLocation }); 
            context.SaveChanges();
            
            p1.Konsols.Add(k1);
            p2.Konsols.Add(k1);
            p3.Konsols.Add(k1);
            p4.Konsols.Add(k1);

            context.SaveChanges();


        


        }
    }
}
