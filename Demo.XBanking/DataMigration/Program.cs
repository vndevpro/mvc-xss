using Demo.XBanking.Data;
using Rabbit.DataUp;
using System;
using System.Linq;

namespace DataMigration
{
    class Program
    {
        public static readonly XBankingDbContext Context = new XBankingDbContext();

        static void Main(string[] args)
        {
            try
            {
                var tag = GetTag(args);
                Console.WriteLine("Found tag: {0}" + tag);

                var executedTypes = DataUpExecution.Initialize(tag, typeof(Program).Assembly).PerformUpdate();

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

        static string GetTag(string[] args)
        {
            if (args.Any(x => x.StartsWith("/t:")))
            {
                return args.First(x => x.StartsWith("/t:")).Substring("/t:".Length - 1);
            }
            return string.Empty;
        }
    }
}
