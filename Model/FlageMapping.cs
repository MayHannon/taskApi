using taskApi.Dtos.Countries;

namespace taskApi.Model
{
    public static class FlageMapping
    {
          public static FlageResource MapEntityToResourceFlag(this FalgeEntity entity){
               if (entity == null)
                return null;
            return new FlageResource()
            {
                id = entity.id,
                FlagFileName = entity.FlagFileName,
                
             
                
            };


          }

           public static FalgeEntity MapModelToEntityFlage(this FlageModel model, int? id)
        {
               if (model == null)
                return null;
            return new FalgeEntity()
            {
                 //id=model.flageId
            };

        }
    }
}