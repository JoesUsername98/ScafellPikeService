using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using YahooFinanceApi;

namespace ScaffelPikeContracts
{
  [DataContract]
  public class YahooSecurityResponse
  {
    public YahooSecurityResponse(IReadOnlyDictionary<string,Security> obj)
    {
      try
      {
        serializedData = JsonConvert.SerializeObject(obj).ToCharArray();
        Array.Reverse(serializedData);
      }catch(Exception ex)
      {
        ;
      }
    }
    [DataMember]
    char[] serializedData { get; set; }

    public IReadOnlyDictionary<string, Security> DeserializeSecurity()
    {
      var temp = serializedData.ToArray();
      Array.Reverse(temp);
      return JsonConvert.DeserializeObject<IReadOnlyDictionary<string, Security>>(temp.ToString());
    }
  }
}
