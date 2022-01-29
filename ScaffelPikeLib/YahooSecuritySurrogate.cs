using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using YahooFinanceApi;

namespace ScaffelPikeContracts
{
  [DataContract]
  public class YahooSecuritySurrogate
  {
    [DataMember]
    public IReadOnlyDictionary<string, dynamic> Fields {
      get;
      set;
    }
    //[DataMember]
    //public dynamic this[string fieldName] => Fields[fieldName];
    //[DataMember]
    //public dynamic this[Field field] => Fields[field.ToString()];
    //[DataMember]
    //public double Ask => this["Ask"];
    //[DataMember]
    //public long AskSize => this["AskSize"];
    //[DataMember]
    //public long AverageDailyVolume10Day => this["AverageDailyVolume10Day"];
    //[DataMember]
    //public long AverageDailyVolume3Month => this["AverageDailyVolume3Month"];
    //[DataMember]
    //public double Bid => this["Bid"];
    //[DataMember]
    //public long BidSize => this["BidSize"];
    //[DataMember]
    //public double BookValue => this["BookValue"];
    //[DataMember]
    //public string Currency => this["Currency"];
    //[DataMember]
    //public long DividendDate => this["DividendDate"];
    //[DataMember]
    //public long EarningsTimestamp => this["EarningsTimestamp"];
    //[DataMember]
    //public long EarningsTimestampEnd => this["EarningsTimestampEnd"];
    //[DataMember]
    //public long EarningsTimestampStart => this["EarningsTimestampStart"];
    //[DataMember]
    //public double EpsForward => this["EpsForward"];
    //[DataMember]
    //public double EpsTrailingTwelveMonths => this["EpsTrailingTwelveMonths"];
    //[DataMember]
    //public string Exchange => this["Exchange"];
    //[DataMember]
    //public long ExchangeDataDelayedBy => this["ExchangeDataDelayedBy"];
    //[DataMember]
    //public string ExchangeTimezoneName => this["ExchangeTimezoneName"];
    //[DataMember]
    //public string ExchangeTimezoneShortName => this["ExchangeTimezoneShortName"];
    //[DataMember]
    //public double FiftyDayAverage => this["FiftyDayAverage"];
    //[DataMember]
    //public double FiftyDayAverageChange => this["FiftyDayAverageChange"];
    //[DataMember]
    //public double FiftyDayAverageChangePercent => this["FiftyDayAverageChangePercent"];
    //[DataMember]
    //public double FiftyTwoWeekHigh => this["FiftyTwoWeekHigh"];
    //[DataMember]
    //public double FiftyTwoWeekHighChange => this["FiftyTwoWeekHighChange"];
    //[DataMember]
    //public double FiftyTwoWeekHighChangePercent => this["FiftyTwoWeekHighChangePercent"];
    //[DataMember]
    //public double FiftyTwoWeekLow => this["FiftyTwoWeekLow"];
    //[DataMember]
    //public double FiftyTwoWeekLowChange => this["FiftyTwoWeekLowChange"];
    //[DataMember]
    //public double FiftyTwoWeekLowChangePercent => this["FiftyTwoWeekLowChangePercent"];
    //[DataMember]
    //public string FinancialCurrency => this["FinancialCurrency"];
    //[DataMember]
    //public double ForwardPE => this["ForwardPE"];
    //[DataMember]
    //public string FullExchangeName => this["FullExchangeName"];
    //[DataMember]
    //public long GmtOffSetMilliseconds => this["GmtOffSetMilliseconds"];
    //[DataMember]
    //public string Language => this["Language"];
    //[DataMember]
    //public string LongName => this["LongName"];
    //[DataMember]
    //public string Market => this["Market"];
    //[DataMember]
    //public long MarketCap => this["MarketCap"];
    //[DataMember]
    //public string MarketState => this["MarketState"];
    //[DataMember]
    //public string MessageBoardId => this["MessageBoardId"];
    //[DataMember]
    //public long PriceHint => this["PriceHint"];
    //[DataMember]
    //public double PriceToBook => this["PriceToBook"];
    //[DataMember]
    //public string QuoteSourceName => this["QuoteSourceName"];
    //[DataMember]
    //public string QuoteType => this["QuoteType"];
    //[DataMember]
    //public double RegularMarketChange => this["RegularMarketChange"];
    //[DataMember]
    //public double RegularMarketChangePercent => this["RegularMarketChangePercent"];
    //[DataMember]
    //public double RegularMarketDayHigh => this["RegularMarketDayHigh"];
    //[DataMember]
    //public double RegularMarketDayLow => this["RegularMarketDayLow"];
    //[DataMember]
    //public double RegularMarketOpen => this["RegularMarketOpen"];
    //[DataMember]
    //public double RegularMarketPreviousClose => this["RegularMarketPreviousClose"];
    //[DataMember]
    //public double RegularMarketPrice => this["RegularMarketPrice"];
    //[DataMember]
    //public long RegularMarketTime => this["RegularMarketTime"];
    //[DataMember]
    //public long RegularMarketVolume => this["RegularMarketVolume"];
    //[DataMember]
    //public double PostMarketChange => this["PostMarketChange"];
    //[DataMember]
    //public double PostMarketChangePercent => this["PostMarketChangePercent"];
    //[DataMember]
    //public double PostMarketPrice => this["PostMarketPrice"];
    //[DataMember]
    //public long PostMarketTime => this["PostMarketTime"];
    //[DataMember]
    //public long SharesOutstanding => this["SharesOutstanding"];
    //[DataMember]
    //public string ShortName => this["ShortName"];
    //[DataMember]
    //public long SourceInterval => this["SourceInterval"];
    //[DataMember]
    //public string Symbol => this["Symbol"];
    //[DataMember]
    //public bool Tradeable => this["Tradeable"];
    //[DataMember]
    //public double TrailingAnnualDividendRate => this["TrailingAnnualDividendRate"];
    //[DataMember]
    //public double TrailingAnnualDividendYield => this["TrailingAnnualDividendYield"];
    //[DataMember]
    //public double TrailingPE => this["TrailingPE"];
    //[DataMember]
    //public double TwoHundredDayAverage => this["TwoHundredDayAverage"];
    //[DataMember]
    //public double TwoHundredDayAverageChange => this["TwoHundredDayAverageChange"];
    //[DataMember]
    //public double TwoHundredDayAverageChangePercent => this["TwoHundredDayAverageChangePercent"];
    public YahooSecuritySurrogate() { }
    public YahooSecuritySurrogate(IReadOnlyDictionary<string, dynamic> fields)
    {
      Fields = fields;
    }
    public YahooSecuritySurrogate(Security sec)
    {
      Fields = sec.Fields;
    }
  }
}
