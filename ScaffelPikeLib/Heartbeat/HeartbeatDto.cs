using System;
using System.Runtime.Serialization;

namespace ScaffelPikeContracts.Heartbeat
{
  [DataContract]
  public class HeartbeatDto
  {
    [DataMember]
    public Guid Guid { get; set; }
    [DataMember]
    public DateTime SentAt { get; set; }
    [DataMember]
    public TimeSpan Interval { get; set; }
    [DataMember]
    public HeartbeatType HeartbeatType { get; set; }
  }
}
