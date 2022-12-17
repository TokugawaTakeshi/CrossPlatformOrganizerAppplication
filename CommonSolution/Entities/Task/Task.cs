namespace CommonSolution.Entities.Task;

public class Task
{

  public required string ID { get; init; }

  public required string Title { get; set; }
  
  public string? Description { get; set; }

  public List<Task>? Subtasks { get; set; }

  public bool IsComplete { get; set; } = false;
  
  public DateOnly? AssociatedDate { get; set; }
  // public DateTime? AssociatedDateTime { get; set; }
  
  public Location? Location { get; set; }

}