using System;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Demo.XBanking.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<XBankingDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(XBankingDbContext context)
        {
            if (!context.Configurations.Any())
            {
                context.Configurations.Add(new Data.Configuration()
                {
                    SetupDate = new DateTime(2015, 10, 10),
                    Version = "1.0.0"
                });
            }

            if (!context.Configurations.Any(c => c.Version == "1.1.0"))
            {
                context.Configurations.Add(new Data.Configuration()
                {
                    SetupDate = new DateTime(2015, 10, 20),
                    Version = "1.1.0"
                });
            }

            if (!context.Configurations.Any(c => c.Version == "1.1.1"))
            {
                context.Configurations.Add(new Data.Configuration()
                {
                    SetupDate = new DateTime(2015, 10, 21),
                    Version = "1.1.1"
                });
            }

            if (!context.Configurations.Any(c => c.Version == "1.1.2"))
            {
                context.Configurations.Add(new Data.Configuration()
                {
                    SetupDate = new DateTime(2015, 10, 22),
                    Version = "1.1.2"
                });
            }

            context.SaveChanges();
        }
    }
}
