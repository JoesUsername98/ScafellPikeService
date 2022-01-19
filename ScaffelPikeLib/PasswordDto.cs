using System.Runtime.Serialization;

namespace ScaffelPikeContracts
{
    [DataContract]
    public class PasswordDto
    {
        [DataMember]
        public bool Success
        { get; set; }

        [DataMember]
        public string OtherData
        { get; set; }
    }
}
