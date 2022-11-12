namespace BusinessRules.Enterprise.Tasks;


public class TaskAssociatedWithDateTime : Task
{
 
  public DateTime AssociatedDateTime { get; set; }


  public TaskAssociatedWithDateTime(string title, DateTime associatedDateTime) : base(title)
  {
    AssociatedDateTime = associatedDateTime;
  }
  
}
