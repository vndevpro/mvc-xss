using Demo.XBanking.Data;
using Rabbit.DataUp;
using System;

namespace DataMigration
{
    class Program
    {
        public static readonly XBankingDbContext Context = new XBankingDbContext();

        static void Main(string[] args)
        {
            try
            {
                var executedTypes = DataUpExecution.Initialize(typeof(Program).Assembly).PerformUpdate();

                // Save all changes made to the application db context
                Context.SaveChanges();

                Console.WriteLine("{0} revisions have been executed", executedTypes.Count);

                foreach (var type in executedTypes)
                {
                    Console.WriteLine("Executed {0}", type);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex);
            }
        }
    }
}
