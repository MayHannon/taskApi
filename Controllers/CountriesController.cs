using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using taskApi.Dtos.Countries;
using taskApi.Model;
using taskApi.Services.Countries;

namespace taskApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _ICountryService;
        public CountriesController(ICountryService iCountriesService)
        {
            _ICountryService = iCountriesService;

        }
        [HttpGet("(id)")]
        public async Task<ActionResult<ServiceResponse<CountryResource>>> GetByIdAsync(int id)
        {
            return Ok(await _ICountryService.GetCountrieById(id));
            //return Ok();
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<CountryResource>>>> GetAllAsync()
        {

            return Ok(await _ICountryService.GetAllCountries());
        }
        [HttpPost]
        public async Task<ActionResult<List<ServiceResponse<CountryResource>>>> CreateAsync(CountryModel newCharacter)
        {

            return Ok(await _ICountryService.AddCountries(newCharacter));
        }

        /// <summary>
        /// Retrieves a specific product by unique id
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <param>id</param> 
        /// <response code="200">Product created</response>
        /// <response code="400">Product has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your product right now</response>
        [HttpPut("{id}")]
        public async Task<ActionResult<CountryResource>> UpdateAsync(CountryModel UpdateedCountries, [FromRoute] int id)
        {
            return Ok(await _ICountryService.UpdateCountries(UpdateedCountries, id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CountryResource>> DeleteAsync([FromRoute] int id)
        {
            return Ok(await _ICountryService.DeletCountries(id));
        }

    }
}