namespace MvcRpg.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Common;
    using DAL;
    internal sealed class Configuration : DbMigrationsConfiguration<RpgContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(RpgContext context)
        {
            var monsters = new List<Monster>
            {
                new Monster {Name = "Goblin", stats = new Stats(10, 10, 2), Exp = 5 },
                new Monster {Name = "Rat", stats = new Stats(5, 5, 1), Exp = 5 },
                new Monster {Name = "Chicken", stats = new Stats(5, 5, 1), Exp = 5 },
                new Monster {Name = "Cow", stats = new Stats(15, 10, 2), Exp = 5 }
            };

            monsters.ForEach(m => context.Monsters.AddOrUpdate(m));
            context.SaveChanges();
        }
    }
}
