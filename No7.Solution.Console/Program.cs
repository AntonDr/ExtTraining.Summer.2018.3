using System.Configuration;
using System.Reflection;
using No7.Solution;

namespace No7.Solution.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            
      
            string file = ConfigurationManager.AppSettings.Get("file");

            var tradeStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(file);

            //var tradeProcessor = new TradeHandler();

            TradeService.Start(tradeStream);

            //tradeProcessor.HandleTrades(tradeStream);
        }
    }
}