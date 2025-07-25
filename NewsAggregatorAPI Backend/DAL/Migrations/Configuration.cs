namespace DAL.Migrations
{
    using DAL.Model;
    using DAL.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.Model.ArticlesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.Model.ArticlesContext context)
        {
           /* Random random = new Random();


            for (int i = 1; i <= 10; i++)
            {
                context.Users.AddOrUpdate(new User
                {
                    Uname = "User-" + i,
                    Name = Guid.NewGuid().ToString().Substring(0, 15),
                    Password = Guid.NewGuid().ToString().Substring(0, 10),
                    Type = "General"
                });
            }


            for (int i = 1; i <= 8; i++)
            {
                context.Categories.AddOrUpdate(new Category
                {
                    CategoryId = i,
                    Name = "Category-" + i,
                    Description = "This is category " + i
                });
            }


            for (int i = 1; i <= 8; i++)
            {
                context.Sources.AddOrUpdate(new Source
                {
                    SourceId = i,
                    Name = "Source-" + i,
                    URL = "https://example.com/source" + i
                });
            }

            context.SaveChanges(); // Ensure foreign key references are valid


            for (int i = 1; i <= 20; i++)
            {
                context.Articles.AddOrUpdate(new Article
                {
                    Title = "Title-" + Guid.NewGuid().ToString().Substring(0, 8),
                    Description = "Description-" + Guid.NewGuid().ToString(),
                    Date = DateTime.Now.AddDays(-random.Next(0, 100)),
                    PostedBy = "User-" + random.Next(1, 11),
                    CategoryId = random.Next(1, 6),
                    SourceId = random.Next(1, 6)
                });
            }

            context.SaveChanges();
           */
        }
    }
}
