using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using YahooFinanceApi;

namespace ScafellPikeContracts.Yahoo
{
  [DataContract]
  public class YahooSecuritySurrogate
  {
    [DataMember]
    public Dictionary<string, dynamic> Fields { get; private set; }
    public YahooSecuritySurrogate() { }
    public YahooSecuritySurrogate(IReadOnlyDictionary<string, dynamic> fields)
    {
      Fields = fields.ToDictionary(kvp => kvp.Key, kvp => kvp.Value); 
    }
    public YahooSecuritySurrogate(Security sec)
    {
      Fields = sec.Fields.ToDictionary(kvp => kvp.Key, kvp => kvp.Value); 
    }
  }
}
