using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ScaffelPikeContracts.LogIn
{
  [DataContract]
  public class LogInResponse
  {
    [DataMember]
    public Guid ServerGuid { get; set; }
    [DataMember]
    public bool SuccesfulRequest { get; set; }
    [DataMember]
    public string FirstName { get; set; }
    [DataMember]
    public string Surname { get; set; }
    [DataMember]
    public Boolean Admin { get; set; }
  }
}
