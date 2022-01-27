using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ScaffelPikeLogger;
using YahooFinanceApi;

namespace FinDataApiManager
{
  public class YahooClient
  {
    private readonly ILogger _logger;
    public YahooClient(ILogger logger)
    {
      _logger = logger;
    }
    public async Task<IReadOnlyDictionary<string,Security>> GetSecurityData(params string[] tickers)
    {
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
  }
}
