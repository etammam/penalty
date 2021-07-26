using System;
using Penalty.Application.Common.Interfaces;

namespace Penalty.Infrastructure.Implementations
{
    public class DateTimeManager : IDateTime
    {
        public DateTime Now { get; } = DateTime.UtcNow;
    }
}
