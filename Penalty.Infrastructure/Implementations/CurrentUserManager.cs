using System;
using System.Threading.Tasks;
using Penalty.Application.Common.Interfaces;

namespace Penalty.Infrastructure.Implementations
{
    public class CurrentUserManager : ICurrentUser
    {
        public string UserId()
        {
            return Guid.NewGuid().ToString();
        }

        public Task<string> GetUserNameAsync(string userId)
        {
            return Task.FromResult("Eslam M. Tammam");
        }
    }
}
