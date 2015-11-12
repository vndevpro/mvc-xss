using Demo.XBanking.Data;
using Rabbit.DataUp;
using System;
using System.Collections.Generic;

namespace DataMigration.Migrations
{
    public class DataV12 : IDataRevision
    {
        private readonly XBankingDbContext _dbContext = Program.Context;

        public bool Execute()
        {
            _dbContext.Configurations.Add(new Configuration()
            {
                Version = "1.2.0",
                SetupDate = DateTime.Now,
                ReleaseNotes = "Upgrade via DataUp"
            });

            return true;
        }

        public Version VersionNumber
        {
            get { return new Version(1, 2); }
        }

        public IEnumerable<string> Tags
        {
            get
            {
                return new List<string>()
                {
                    "",
                    "Demo2",
                    "Dev",
                };
            }
        }
    }
}