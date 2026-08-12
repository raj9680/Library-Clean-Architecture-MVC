using Library.Application.DTOs;

namespace Library.Application.Interfaces
{
    public interface IDashboardService
    {
        Task<DashboardDto> GetDashboardInfoAsync();
    }
}