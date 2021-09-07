using System.ComponentModel.DataAnnotations;
using taskApi.Model;

namespace taskApi.Dtos.Countries
{
    public class CountryModel
    {
        
[Required(ErrorMessage = "country name is requier")]  
  [StringLength (24)]
        public string name { get; set; }

        //public int flage { get; set; }
       
        public int population { get; set; }

       // public string timeZone { get; set; }
         [Required(ErrorMessage = "currencies is requier")]  
        public string currencies { get; set; }

         [Required(ErrorMessage = "language is requier")]  
        public string language { get; set; }
 
           [Required(ErrorMessage = "CapitalCity is requier")]  
       [MaxLength(24) , MinLength(1)]
        public string capitalCity { get; set; }
       public int borderingCountries { get; set; }
        [Required(ErrorMessage = "Flage is requier")]  
         public int flageId { get; set; }
        
    }
}