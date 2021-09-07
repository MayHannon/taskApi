
namespace taskApi.Model
{
    public class CountryEntity
    {
        public int id { get; set; }

        public string name { get; set; }

        //public int flage { get; set; }

        public int population { get; set; }

       // public string timeZone { get; set; }
        public string currencies { get; set; }

        public string language { get; set; }

        public string capitalCity { get; set; }

        public int borderingCountries { get; set; }
       //  [ForeignKey("Flage ")]
         
       public FalgeEntity Flage { get; set; }
       public int FlageId { get; set; }
    }
}