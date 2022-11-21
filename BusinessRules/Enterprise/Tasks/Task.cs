namespace BusinessRules.Enterprise.Tasks;


public class Task
{

  public uint ID { get; init; }

  // TODO required
  public string Title { get; set; }
  
  public string? Description { get; set; }

  public List<Task> Subtasks { get; set; } = new();

}