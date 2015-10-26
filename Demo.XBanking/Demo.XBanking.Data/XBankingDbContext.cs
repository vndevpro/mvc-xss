using System.Data.Entity;

namespace Demo.XBanking.Data
{
    public class XBankingDbContext : DbContext
    {
        public IDbSet<Configuration> Configurations { get; set; }
    }
}