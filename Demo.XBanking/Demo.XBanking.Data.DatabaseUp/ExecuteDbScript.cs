using DbUp.Engine;
using System;
using System.Data;
using System.IO;

namespace Demo.XBanking.Data.DatabaseUp
{
    public class ExecuteDbScript : IScript
    {
        public string ProvideScript(Func<IDbCommand> dbCommandFactory)
        {
            var asm = this.GetType().Assembly;
            const string script = "Demo.XBanking.Data.DatabaseUp.Scripts.DbFullScript.sql";

            using (var stream = asm.GetManifestResourceStream(script))
            {
                if (stream == null)
                {
                    throw new FileNotFoundException("Cannot find script: " + script);
                }

                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}