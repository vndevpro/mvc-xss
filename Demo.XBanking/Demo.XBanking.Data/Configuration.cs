using System;

namespace Demo.XBanking.Data
{
    public class Configuration
    {
        public Configuration()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }

        public string Version { get; set; }

        public string ReleaseNotes { get; set; }

        public DateTime SetupDate { get; set; }
    }
}
