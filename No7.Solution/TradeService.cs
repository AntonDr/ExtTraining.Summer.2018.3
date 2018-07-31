using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No7.Solution
{
    public static class TradeService
    {

        public static string GetFullPath(this string sourceFile)
        {
            return Path.GetFullPath(sourceFile);
        }


        public static void Start(Stream tradeStream)
        {
            FileReader fr = new FileReader();

            fr.ReadFrom(tradeStream);

            DataProcessing dp = new DataProcessing();

            int f = int.Parse(ConfigurationManager.AppSettings.Get("length"));
            int s = int.Parse(ConfigurationManager.AppSettings.Get("alllength"));

            dp.Processing(fr.GetEnumerator(),f,s);

            Repository repository = new Repository();

            repository.Save(dp.GetData());
        }
    }
}
