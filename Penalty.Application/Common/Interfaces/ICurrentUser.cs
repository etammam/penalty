using System.Threading.Tasks;
using AspNetCore.ServiceRegistration.Dynamic;

namespace Penalty.Application.Common.Interfaces
{
    public interface ICurrentUser : IScopedService
    {
        string UserId();
        Task<string> GetUserNameAsync(string userId);
    }
}
