using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ScaffelPikeContracts
{
  [DataContract]
  public class QuandlDatabaseResponse
  {
    [DataMember]
    public int Id { get; set; }
    [DataMember]
    public string Name { get; set; }
    [DataMember]
    public string Code { get; set; }
    [DataMember]
    public string Description { get; set; }
    [DataMember]
    public int DatasetCount { get; set; }
  }
}
