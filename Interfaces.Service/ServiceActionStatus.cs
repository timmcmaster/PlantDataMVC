using System.Runtime.Serialization;

namespace Interfaces.Service
{
    [DataContract]
    public enum ServiceActionStatus
    {
        [EnumMember]
        Ok,
        [EnumMember]
        Created,
        [EnumMember]
        Updated,
        [EnumMember]
        NotFound,
        [EnumMember]
        Deleted,
        [EnumMember]
        NothingModified,
        [EnumMember]
        Error
    }
}