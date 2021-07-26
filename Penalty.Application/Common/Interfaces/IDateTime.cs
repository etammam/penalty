using System;
using AspNetCore.ServiceRegistration.Dynamic;

namespace Penalty.Application.Common.Interfaces
{
    public interface IDateTime : ISingletonService
    {
        DateTime Now { get; }
    }
}
