using Demo.XBanking.Data;
using Rabbit.DataUp;
using System;

namespace DataMigration.Migrations
{
    public class DataV1 : IDataRevision
    {
        private readonly XBankingDbContext _dbContext = Program.Context;

        public bool Execute()
        {
            _dbContext.Configurations.Add(new Configuration()
            {
                Version = "V1",
                SetupDate = DateTime.Now,
                ReleaseNotes = "Upgrade via DataUp"
            });

            return true;
        }

        public Version VersionNumber
        {
            get { return new Version(1, 0); }
        }
    }
}
