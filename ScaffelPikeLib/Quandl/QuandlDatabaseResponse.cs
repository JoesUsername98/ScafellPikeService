using System.Runtime.Serialization;

namespace ScafellPikeContracts.Quandl
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
