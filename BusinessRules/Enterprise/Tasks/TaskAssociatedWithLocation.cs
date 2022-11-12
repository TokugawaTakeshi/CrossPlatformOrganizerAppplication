namespace BusinessRules.Enterprise.Tasks;


public class TaskAssociatedWithLocation
{

  public Location AssociatedLocation { get; set; }

  public TaskAssociatedWithLocation(Location associatedLocation)
  {
    AssociatedLocation = associatedLocation;
  }
  
}