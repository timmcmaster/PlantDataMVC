using System.Runtime.Serialization;

namespace Interfaces.Service
{
    public enum ServiceActionStatus
    {
        Ok,
        Created,
        Updated,
        NotFound,
        Deleted,
        NothingModified,
        Error
    }
}