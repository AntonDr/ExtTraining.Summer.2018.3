using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No7.Solution
{
    public class TradeRecord
    {
        private string destinationCurrency;
        private float lots;
        private decimal price;
        private string sourceCurrency;

        public TradeRecord(string destinationCurrency,float lots,decimal price,string sourceCurrency)
        {
            DestinationCurrency = destinationCurrency;
            Lots = lots;
            Price = price;
            SourceCurrency = sourceCurrency;
        }

        public string DestinationCurrency
        {
            get => destinationCurrency;
            
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }

                destinationCurrency = value;
            }
        }

        public float Lots
        {
            get => lots;

            private set
            {
                if (value<0)
                {
                    throw new ArgumentException();
                }

                lots = value;
            }
        }

        public decimal Price
        {
            get => price;
            private  set
            {
                if (value<0)
                {
                    throw new ArgumentException();
                }

                price = value;
            }
        }

        public string SourceCurrency
        {
            get => sourceCurrency;

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }

                sourceCurrency = value;
            }
        }
    }
}
