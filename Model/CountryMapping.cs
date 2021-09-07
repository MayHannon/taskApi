using taskApi.Dtos.Countries;

namespace taskApi.Model
{
    public static class CountryMapping
    {
        public static CountryEntity MapModelToEntity(this CountryModel model, int? id)
        {
            if (model == null)
                return null;
            return new CountryEntity()
            {
                id = id ?? 0,
                borderingCountries = model.borderingCountries,
                capitalCity = model.capitalCity,
                currencies = model.currencies,
                language = model.language,
                name = model.name,
                population = model.population,
                FlageId = model.flageId
            };
        }

        public static CountryResource MapEntityToResource(this CountryEntity entity)
        {
            if (entity == null)
                return null;
            return new CountryResource()
            {
                id = entity.id,
                borderingCountries = entity.borderingCountries,
                capitalCity = entity.capitalCity,
                currencies = entity.currencies,
                language = entity.language,
                name = entity.name,
                population = entity.population,
                Flage= entity.Flage.MapEntityToResourceFlag()
            };
        }
    }
}