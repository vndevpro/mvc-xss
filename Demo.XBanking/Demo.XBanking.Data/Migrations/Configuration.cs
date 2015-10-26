using System;
using System.Linq;
using System.Data.Entity.Migrations;

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

            if (!context.Configurations.Any(c => c.Version == "1.1.0"))
            {
                context.Configurations.Add(new Data.Configuration()
                {
                    SetupDate = new DateTime(2015, 10, 20),
                    Version = "1.1.0"
                });
            }

            context.SaveChanges();
        }
    }
}
