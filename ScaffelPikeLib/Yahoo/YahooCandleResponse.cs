using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using YahooFinanceApi;

namespace ScaffelPikeContracts.Yahoo
{
  [DataContract]
  public class YahooCandleResponse : ITick
  {
    public YahooCandleResponse(Candle input)
    {
      DateTime = input.DateTime;
      Open = input.Open;
      High = input.High;
      Low = input.Low;
      Close = input.Close;
      Volume = input.Volume;
      AdjustedClose = input.AdjustedClose;
    }
    [DataMember]
    public DateTime DateTime {
      get;
      internal set;
    }
    [DataMember]
    public decimal Open {
      get;
      internal set;
    }
    [DataMember]
    public decimal High {
      get;
      internal set;
    }
    [DataMember]
    public decimal Low {
      get;
      internal set;
    }
    [DataMember]
    public decimal Close {
      get;
      internal set;
    }
    [DataMember]
    public long Volume {
      get;
      internal set;
    }
    [DataMember]
    public decimal AdjustedClose {
      get;
      internal set;
    }
  }
}
