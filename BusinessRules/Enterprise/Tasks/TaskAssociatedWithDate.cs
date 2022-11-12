namespace BusinessRules.Enterprise.Tasks;


public class TaskAssociatedWithDate : Task
{
  
  public DateOnly AssociatedDate { get; set; }
  
  public TaskAssociatedWithDate(string title, DateOnly associatedDate) : base(title)
  {
    AssociatedDate = associatedDate;
  }
  
}
