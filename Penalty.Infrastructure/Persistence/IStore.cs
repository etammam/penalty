using AspNetCore.ServiceRegistration.Dynamic;

namespace Penalty.Infrastructure.Persistence
{
    public interface IStore : ISingletonService
    {
        object Read<T>(string dataSetName);
        bool SaveChanges(object model, string dataSetName);
    }
}
