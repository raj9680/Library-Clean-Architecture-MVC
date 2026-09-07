using Library.Application.DTOs;
using Library.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.UI.ViewComponents
{
    public class CountryDropdownViewComponent: ViewComponent
    {
        private readonly ICountryService _countryService;
        public CountryDropdownViewComponent(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<CountryDto> country =  await _countryService.GetAllCountryAsync();
            return View(country);
        }
    }
}
