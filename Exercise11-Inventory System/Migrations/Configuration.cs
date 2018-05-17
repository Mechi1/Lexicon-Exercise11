namespace Exercise11_Inventory_System.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Exercise11_Inventory_System.DataAccessLayer.StorageContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Exercise11_Inventory_System.DataAccessLayer.StorageContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Products.AddOrUpdate(p => p.Name, new Models.Product()
            {
                Name = "Arla Milk",
                Price = 10,
                Category = "Dairy",
                Shelf = "Dairy cooler",
                Count = 53,
                Description = "Milk is a white liquid produced by the mammary glands of mammals. It is the primary source of nutrition for infant mammals before they are able to digest other types of food.",
                RestockLimit = 10
            });

            context.Products.AddOrUpdate(p => p.Name, new Models.Product()
            {
                Name = "Arla Whipped Cream 3dl",
                Price = 30,
                Category = "Dairy",
                Shelf = "Dairy cooler",
                Count = 10,
                Description = "Whipped cream is cream that is whipped by a whisk or mixer until it is light and fluffy. Whipped cream is often sweetened and sometimes flavored with vanilla.",
                RestockLimit = 10
            });

            context.Products.AddOrUpdate(p => p.Name, new Models.Product()
            {
                Name = "Scan Mammas Små Färdigstekta köttbullar 400g",
                Price = 27,
                Category = "Frozen Food",
                Shelf = "Premade foods cooler 2",
                Count = 37,
                Description = "Ground meat rolled into a small ball, sometimes along with other ingredients, such as bread crumbs, minced onion, eggs, butter, and seasoning.",
                RestockLimit = 10
            });

            context.Products.AddOrUpdate(p => p.Name, new Models.Product()
            {
                Name = "Felix Pommes Frites 900g",
                Price = 29,
                Category = "Frozen Food",
                Shelf = "Premade foods cooler 5",
                Count = 3,
                Description = "Pomme frites refers to all dishes of fried elongated pieces of potatoes.",
                RestockLimit = 10
            });

            context.Products.AddOrUpdate(p => p.Name, new Models.Product()
            {
                Name = "Cookies",
                Price = 1,
                Category = "Cookies",
                Shelf = "Main aisle",
                Count = 255,
                Description = "Cookies cookies cookies cookies cookies cookies cookies cookies cookies cookies cookies cookies cookies cookies cookies",
                RestockLimit = 200
            });

            context.Products.AddOrUpdate(p => p.Name, new Models.Product()
            {
                Name = "TV Panaviewic Ultra Color 64",
                Price = 19999,
                Category = "Electronics",
                Shelf = "TV 2",
                Count = 5,
                Description = "It's a TV",
                RestockLimit = 3
            });

            context.Products.AddOrUpdate(p => p.Name, new Models.Product()
            {
                Name = "Expresso Quick Juicer",
                Price = 2399,
                Category = "Electronics",
                Shelf = "Kitchen wares 5",
                Count = 3,
                Description = "Juicer squeeze or press the water out of parts of living organisms only for the enjoyment of posh people who can't bother drinking regular water.",
                RestockLimit = 3
            });

            context.Products.AddOrUpdate(p => p.Name, new Models.Product()
            {
                Name = "Turbo Vacuum something something",
                Price = 5999,
                Category = "Electronics",
                Shelf = "Cleaners storage closet",
                Count = 1,
                Description = "Hey, that is not for sale! Get that back here.",
                RestockLimit = 0
            });

            context.Products.AddOrUpdate(p => p.Name, new Models.Product()
            {
                Name = "IBM XT 286 6MHz",
                Price = 65499,
                Category = "Electronics",
                Shelf = "Computer 15",
                Count = 250,
                Description = "Latest computer based on the new 80268 cpu.",
                RestockLimit = 0
            });

            context.Products.AddOrUpdate(p => p.Name, new Models.Product()
            {
                Name = "Apple, any",
                Price = 65535,
                Category = "Electronic Waste",
                Shelf = "In the Trash",
                Count = 0,
                Description = "Overpriced piece of grabage with no ingenuity of their own.",
                RestockLimit = 0
            });

            //context.Products.AddOrUpdate(p => p.Name, new Models.Product()
            //{
            //    Name = "",
            //    Price = 1,
            //    Category = "",
            //    Shelf = "",
            //    Count = 1,
            //    Description = ""
            //});
        }
    }
}
