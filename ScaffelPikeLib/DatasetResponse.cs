using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ScaffelPikeContracts
{
  [DataContract]
  public class DatasetResponse
  {
    [DataMember]
    public int Id { get; set; }
    [DataMember]
    public string Code { get; set; }
    [DataMember]
    public string DatabaseCode { get; set; }
    [DataMember]
    public string DatabaseId { get; set; }
    [DataMember]
    public string Name { get; set; }
    [DataMember]
    public string Description { get; set; }
    [DataMember]
    public DateTime RefreshedAt { get; set; }
    [DataMember]
    public List<string> ColumnName { get; set; }
    [DataMember]
    public string Frequency { get; set; }//change to enum?
    [DataMember]
    public string Type { get; set; }//change to enum?
  }
}
