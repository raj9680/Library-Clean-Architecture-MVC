using Library.Application.DTOs;

namespace Library.Application.Interfaces
{
    public interface ICountryService
    {
        Task<List<CountryDto>> GetAllCountryAsync();
    }
}