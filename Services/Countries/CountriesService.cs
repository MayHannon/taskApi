using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using taskApi.Data;
using taskApi.Dtos.Countries;
using taskApi.Model;

namespace taskApi.Services.Countries
{
    public class CountryService : ICountryService
    {
        private readonly DataContext _Context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CountryService(DataContext Context, IHttpContextAccessor httpContextAccessor)
        {

            _httpContextAccessor = httpContextAccessor;
            _Context = Context;


        }




        public async Task<CountryResource> AddCountries(CountryModel AddedCountries)
        {
            var ServiceResponse = new ServiceResponse<List<CountryResource>>();
            var flag = await _Context.Flage.FirstOrDefaultAsync(x => x.id == AddedCountries.flageId);
            if (flag == null)
                throw new Exception($"Flag does not exist");

            var entity = AddedCountries.MapModelToEntity(0);

            _Context.Countries.Add(entity);
            await _Context.SaveChangesAsync();

            var addedEntity = await _Context.Countries
             .Include(c => c.Flage)
            .FirstOrDefaultAsync(c => c.id == entity.id);
            return addedEntity.MapEntityToResource();
        }
        public async Task<CountryResource> DeletCountries(int id)
        {

            var ServiceResponse = new ServiceResponse<CountryResource>();


            var dbCountries = await _Context.Countries.FirstOrDefaultAsync(c => c.id == id);
            if (dbCountries != null)
            {
                _Context.Countries.Remove(dbCountries);
                await _Context.SaveChangesAsync();
                return dbCountries.MapEntityToResource();
            }
            else
            {
                throw new Exception($"Country with id {id} does not exist");
            }




        }

        public async Task<List<CountryResource>> GetAllCountries()

        {
            var dbCountries = await _Context.Countries
              .Include(c => c.Flage).ToListAsync();

            return dbCountries.ToList().Select(item => item.MapEntityToResource()).ToList();
        }

        public async Task<CountryResource> GetCountrieById(int id)
        {
            var ServiceResponse = new ServiceResponse<CountryResource>();


            var dbCountries = await _Context.Countries
             .Include(c => c.Flage)
            .FirstOrDefaultAsync(c => c.id == id);

            return dbCountries.MapEntityToResource();

        }

        public async Task<CountryResource> UpdateCountries(CountryModel UpdateedCountries, int id)
        {

            var dbCountries = await _Context.Countries.Include(c => c.Flage).AsNoTracking().FirstOrDefaultAsync(c => c.id == id);
            
            if (dbCountries == null)
                throw new Exception($"Country with id {id} does not exist");
            dbCountries = UpdateedCountries.MapModelToEntity(id);
            _Context.Update(dbCountries);
            await _Context.SaveChangesAsync();
             dbCountries =await _Context.Countries.Include(c => c.Flage).FirstOrDefaultAsync(c => c.id == id);
            return dbCountries.MapEntityToResource();
        }
    }
}