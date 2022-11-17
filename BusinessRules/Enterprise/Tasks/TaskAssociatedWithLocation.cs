namespace BusinessRules.Enterprise.Tasks;


public class TaskAssociatedWithLocation
{

  // TODO required
  public Location AssociatedLocation { get; set; }

  public TaskAssociatedWithLocation(Location associatedLocation)
  {
    AssociatedLocation = associatedLocation;
  }
  
}