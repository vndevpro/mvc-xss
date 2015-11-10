using System;
using Demo.XBanking.Data;
using Rabbit.DataUp;

namespace DataMigration.Migrations
{
    public class DataV11 : IDataRevision
    {
        private readonly XBankingDbContext _dbContext = Program.Context;

        public bool Execute()
        {
            _dbContext.Configurations.Add(new Configuration()
            {
                Version = "1.1.0",
                SetupDate = DateTime.Now,
                ReleaseNotes = "Upgrade via DataUp"
            });

            return true;
        }

        public Version VersionNumber
        {
            get { return new Version(1, 1); }
        }
    }
}