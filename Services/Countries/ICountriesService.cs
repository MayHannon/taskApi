using System.Threading.Tasks;
using System.Collections.Generic;
using taskApi.Dtos.Countries;
using taskApi.Model;

namespace taskApi.Services.Countries
{
    public interface ICountryService
    {
        Task<List<CountryResource>> GetAllCountries();
        Task<CountryResource> GetCountrieById(int id);
        Task<CountryResource> UpdateCountries(CountryModel UpdateedCountries, int id);

        


        Task<CountryResource> DeletCountries(int id);
        Task<CountryResource> AddCountries(CountryModel AddedCountries);
    }
}