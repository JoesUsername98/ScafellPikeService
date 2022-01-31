using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using FinDataApiManager.TransferObjects;
using Newtonsoft.Json;
using ScaffelPikeLogger;
using YahooFinanceApi;

namespace FinDataApiManager
{
  public class YahooClient
  {
    private readonly ILogger _logger;
    public List<string> Tickers { get; set; }
    public YahooClient(ILogger logger)
    {
      _logger = logger;
      Tickers = new List<string>();

      using (StreamReader r = new StreamReader("YahooTickers.json"))
      {
        string json = r.ReadToEnd();
        var dataObject= JsonConvert.DeserializeObject<YahooTickers>(json);
        Tickers = dataObject.Tickers;
      }
    }
    public async Task<IReadOnlyDictionary<string, Security>> YahooQuery(Field[] fields = null, params string[] tickers)
    {
      fields = fields ?? new Field[] { Field.Symbol, Field.RegularMarketPrice, Field.FiftyTwoWeekHigh };
      _logger.Information("GetSecurityData", $"API call start");
      try
      {
        return await Yahoo.Symbols(tickers).Fields(Field.Symbol, Field.RegularMarketPrice, Field.FiftyTwoWeekHigh).QueryAsync();
      }
      catch (Exception ex)
      {
        _logger.Error("GetSecurityData", ex);
        return null;
      }
    }

    public async Task<IReadOnlyList<Candle>> GetYahooHistoricalData(string symbol, DateTime? startTime, DateTime? endTime, Period period)
    {
      _logger.Information("YahooData", $"API call start");
      try
      {
          return await Yahoo.GetHistoricalAsync(symbol, startTime, endTime, period);
      }
      catch (Exception ex)
      {
        _logger.Error("YahooData", ex);
        return null;
      }
    }
  }
}
