using System.Data.Entity;

namespace Demo.XBanking.Data.DatabaseUp
{
    public class XBankingDbContext : DbContext
    {
        public XBankingDbContext()
            : base("name=XBankingDatabase")
        {
        }
    }
}