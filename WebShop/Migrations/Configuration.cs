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
            context.Konsols.AddOrUpdate(c => c.ConsoleName,
                new Konsol() { ConsoleName = "PC" },
                new Konsol() { ConsoleName = "Xbox One" },
                new Konsol() { ConsoleName = "Playstation 4" },
                new Konsol() { ConsoleName = "Xbox 360" },
                new Konsol() { ConsoleName = "Wii U" },
                new Konsol() { ConsoleName = "Playstation 3" });

        }
    }
}
