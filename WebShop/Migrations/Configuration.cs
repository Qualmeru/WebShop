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

            Genre g1 = new Genre { GenreName = "Action" };
            Genre g2 = new Genre { GenreName = "Adventure" };
            Genre g3 = new Genre { GenreName = "FPS" };
            Genre g4 = new Genre { GenreName = "Driving" };
            Genre g5 = new Genre { GenreName = "Fighting" };
            Genre g6 = new Genre { GenreName = "Simulation" };
            context.Genres.AddOrUpdate(g => g.GenreName, g1, g2, g3, g4, g5, g6);
            context.SaveChanges();

            Konsol k1 = new Konsol() { ConsoleName = "Playstation 4" };
            Konsol k2 = new Konsol() { ConsoleName = "Xbox One" };
            Konsol k3 = new Konsol() { ConsoleName = "PC" };
            Konsol k4 = new Konsol() { ConsoleName = "Xbox 360" };
            Konsol k5 = new Konsol() { ConsoleName = "Wii U" };
            Konsol k6 = new Konsol() { ConsoleName = "Playstation 3" };

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
                a => new { a.ProductName, a.PicLocation }, p1);
            Product p2 =
                new Product() { ProductName = "Destiny", Price = 699, YearOfRelease = 2014, PicLocation = "~/Content/destiny.jpg" };

            context.Products.AddOrUpdate(
                 c => new { c.ProductName, c.PicLocation }, p2);

            Product p3 =
                new Product() { ProductName = "Evil Within", Price = 499, YearOfRelease = 2013, PicLocation = "~/Content/EvilwithinPS4.jpg" };
            context.Products.AddOrUpdate(
                 d => new { d.ProductName, d.PicLocation }, p3);
            Product p4 =
               new Product() { ProductName = "GTA V", Price = 699, YearOfRelease = 2014, PicLocation = "~/Content/gta5ps4.jpg" };
            context.Products.AddOrUpdate(
                 e => new { e.ProductName, e.PicLocation }, p4);
            context.SaveChanges();

            AddOrUpdateProduktConsole(context, p1.Id, k1.Id);
            AddOrUpdateProduktConsole(context, p2.Id, k1.Id);
            AddOrUpdateProduktConsole(context, p3.Id, k1.Id);
            AddOrUpdateProduktConsole(context, p4.Id, k1.Id);

            AddOrUpdateProductGenre(context, p1.Id, g1.Id);
            AddOrUpdateProductGenre(context, p2.Id, g2.Id);
            AddOrUpdateProductGenre(context, p3.Id, g3.Id);
            AddOrUpdateProductGenre(context, p4.Id, g4.Id);

            context.SaveChanges();





        }

        public void AddOrUpdateProduktConsole(MainDB context, int productId, int consoleId)
        {
            Product p = context.Products.Single(f => f.Id == productId);
            Konsol k = context.Konsols.Single(f => f.Id == consoleId);
            p.Konsols.Add(k);
        }

        public void AddOrUpdateProductGenre(MainDB context, int productId, int genreId)
        {
            Product p = context.Products.Single(f => f.Id == productId);
            Genre g = context.Genres.Single(f => f.Id == genreId);
            p.Genres.Add(g);
        }
    }
}
