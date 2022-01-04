using System.Runtime.Serialization;

namespace ScaffelPikeLib
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
