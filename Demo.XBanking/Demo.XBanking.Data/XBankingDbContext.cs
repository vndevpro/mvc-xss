using System.Data.Entity;

namespace Demo.XBanking.Data
{
    public class XBankingDbContext : DbContext
    {
        public XBankingDbContext()
            : base("name=XBankingDatabase")
        {
        }

        public IDbSet<Configuration> Configurations { get; set; }
    }
}