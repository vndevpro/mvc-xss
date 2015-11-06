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
            var version = typeof(Configuration).Assembly.GetName().Version.ToString();

            if (!context.Configurations.Any(c => c.Version == version))
            {
                context.Configurations.Add(new Data.Configuration()
                {
                    SetupDate = DateTime.Now,
                    Version = version
                });
            }

            context.SaveChanges();
        }
    }
}
