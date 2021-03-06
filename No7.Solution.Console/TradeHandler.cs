﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;

//Разделил на 3 класса.
//FileReader - получение данных из файла
//DataProcessing - обработка инфрмации(логика)
//Repository - работа с бд
//TradeRecord своеобразный DTO


//namespace No7.Solution.Console
//{
//    public class TradeHandler
//    {
//        private static float LotSize = 100000f;

//        public void HandleTrades(Stream stream)
//        {

//            var lines = new List<string>();
//            using (var reader = new StreamReader(stream))
//            {
//                string line;
//                while((line = reader.ReadLine()) != null)
//                {
//                    lines.Add(line);
//                }
//            }

//            var trades = new List<TradeRecord>();

//            var lineCount = 1;
//            foreach (var line in lines)
//            {
//                var fields = line.Split(new char[] { ',' });

//                if(fields.Length != 3)
//                {
//                    System.Console.WriteLine("WARN: Line {0} malformed. Only {1} field(s) found.", lineCount, fields.Length);
//                    continue;
//                }

//                if(fields[0].Length != 6)
//                {
//                    System.Console.WriteLine("WARN: Trade currencies on line {0} malformed: '{1}'", lineCount, fields[0]);
//                    continue;
//                }

//                if(!int.TryParse(fields[1], out var tradeAmount))
//                {
//                    System.Console.WriteLine("WARN: Trade amount on line {0} not a valid integer: '{1}'", lineCount, fields[1]);
//                }

//                if(!decimal.TryParse(fields[2],out var tradePrice))
//                {
//                    System.Console.WriteLine("WARN: Trade price on line {0} not a valid decimal: '{1}'", lineCount, fields[2]);
//                }

//                var sourceCurrencyCode = fields[0].Substring(0, 3);
//                var destinationCurrencyCode = fields[0].Substring(3, 3);

//                var trade = new TradeRecord
//                {
//                    SourceCurrency = sourceCurrencyCode,
//                    DestinationCurrency = destinationCurrencyCode,
//                    Lots = tradeAmount / LotSize,
//                    Price = tradePrice
//                };

//                trades.Add(trade);

//                lineCount++;
//            }

//            // save into database
//            string connectionString = ConfigurationManager.ConnectionStrings["TradeData"].ConnectionString;
//            using (var connection = new SqlConnection(connectionString))
//            {
//                connection.Open();
//                using(var transaction = connection.BeginTransaction())
//                {
//                    foreach(var trade in trades)
//                    {
//                        var command = connection.CreateCommand();
//                        command.Transaction = transaction;
//                        command.CommandType = System.Data.CommandType.StoredProcedure;
//                        command.CommandText = "dbo.Insert_Trade";
//                        command.Parameters.AddWithValue("@sourceCurrency", trade.SourceCurrency);
//                        command.Parameters.AddWithValue("@destinationCurrency", trade.DestinationCurrency);
//                        command.Parameters.AddWithValue("@lots", trade.Lots);
//                        command.Parameters.AddWithValue("@price", trade.Price);

//                        command.ExecuteNonQuery();
//                    }

//                    transaction.Commit();
//                }
//                connection.Close();
//            }

//            System.Console.WriteLine("INFO: {0} trades processed", trades.Count);
//        }
//    }
//}
