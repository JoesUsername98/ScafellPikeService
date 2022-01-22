using System;
using System.Runtime.Serialization;

namespace ScaffelPikeContracts
{
  [DataContract]
  public class LogInRequest
  {
    [DataMember]
    public Guid ClientGuid { get; set; }
    [DataMember]
    public string Username { get; set; }
    [DataMember]
    public string Password { get; set; }
  }
}
