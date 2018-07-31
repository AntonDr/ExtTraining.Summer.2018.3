using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No7.Solution
{
    public class DataProcessing:IEnumerable<TradeRecord>
    {
        private List<TradeRecord> trades = new List<TradeRecord>();

        private readonly CultureInfo culture;

        private readonly float lotSize = 100000f;

        private NumberStyles numberStyles;

        private IFormatProvider formatProvider;

        public DataProcessing() : this(CultureInfo.InvariantCulture, NumberStyles.Any)
        {
        }

        public DataProcessing(CultureInfo culture, NumberStyles numberStyles)
        {
            this.culture = culture;
            this.numberStyles = numberStyles;
        }

        public void Processing(IEnumerable<string> collection,int flength,int slength)
        {
            int lineCount = 1;

            foreach (var line in collection)
            {
                var fields = line.Split(new char[] {','});

                if (fields.Length != flength)
                {
                    System.Console.WriteLine("WARN: Line {0} malformed. Only {1} field(s) found.", lineCount,
                        fields.Length);
                    continue;
                }

                if (fields[0].Length != slength)
                {
                    System.Console.WriteLine("WARN: Trade currencies on line {0} malformed: '{1}'", lineCount,
                        fields[0]);
                    continue;
                }

                if (!int.TryParse(fields[1], numberStyles, culture, out var tradeAmount))
                {
                    System.Console.WriteLine("WARN: Trade amount on line {0} not a valid integer: '{1}'", lineCount,
                        fields[1]);
                }

                if (!decimal.TryParse(fields[2], numberStyles, culture, out var tradePrice))
                {
                    System.Console.WriteLine("WARN: Trade price on line {0} not a valid decimal: '{1}'", lineCount,
                        fields[2]); 
                }

                string sourceCurrencyCode = fields[0].Substring(0, flength);
                string destinationCurrencyCode = fields[0].Substring(flength, flength);

                var trade = new TradeRecord(destinationCurrencyCode, tradeAmount / lotSize, tradePrice,
                    sourceCurrencyCode);

                trades.Add(trade);

                lineCount++;
            }
        }

        public IEnumerable<TradeRecord> GetData()
        {
            foreach (var itemRecord in trades)
            {
                yield return itemRecord;
            }
        }

        public IEnumerator<TradeRecord> GetEnumerator()
        {
            foreach (var itemRecord in trades)
            {
                yield return itemRecord;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
