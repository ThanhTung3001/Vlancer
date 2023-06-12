using TSoft.TaskManagement.Application.Common.Interfaces;

namespace TSoft.TaskManagement.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}