using System.Data.Entity.Migrations;
using EfConcurrency.DataLayer.Context;

namespace EfConcurrency.DataLayer.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<EfConcurrencyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(EfConcurrencyContext context)
        {
            context.SaveChanges(false);
        }
    }
}
