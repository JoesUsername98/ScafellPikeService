using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using YahooFinanceApi;

namespace ScaffelPikeContracts.Yahoo
{
  [DataContract]
  public class YahooSecurityResponse
  {
    public YahooSecurityResponse() { }
    public YahooSecurityResponse(IReadOnlyDictionary<string, Security> dict)
    {
      SecurityData = new Dictionary<string, YahooSecuritySurrogate>();

      foreach (KeyValuePair<string, Security> entry in dict)
        SecurityData.Add(entry.Key, new YahooSecuritySurrogate(entry.Value));
    }

    [DataMember]
    public Dictionary<string, YahooSecuritySurrogate> SecurityData { get; private set; }

  }
}
