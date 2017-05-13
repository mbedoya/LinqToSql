namespace LinqToSql.Data.Migrations
{
    using LinqToSql.Common;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LinqToSql.Data.LinqContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(LinqToSql.Data.LinqContext context)
        {

            /*
            context.Categories.AddOrUpdate(
                  new CategoryDTO { Name = "Technology" },
                  new CategoryDTO { Name = "Appliances" },
                  new CategoryDTO { Name = "Sports" },
                  new CategoryDTO { Name = "Books" },
                  new CategoryDTO { Name = "Clothes" },
                  new CategoryDTO { Name = "Jewerly" }
                );

            context.Products.AddOrUpdate(
                  new ProductDTO { Name = "Dell Laptop", CategoryId = 1 },
                  new ProductDTO { Name = "Logitech Camera", CategoryId = 1 },
                  new ProductDTO { Name = "Microsoft Mouse", CategoryId = 1 },
                  new ProductDTO { Name = "Quiet Fan", CategoryId = 2 },
                  new ProductDTO { Name = "Lg Refrigerator", CategoryId = 2 }
                );
             */
        }
    }
}
