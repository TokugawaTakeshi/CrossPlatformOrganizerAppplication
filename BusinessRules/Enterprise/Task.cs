namespace BusinessRules.Enterprise;


public class Task
{

  public string Title { get; set; }
  public string? Description { get; set; }

  public List<Task> Subtasks { get; set; } = new();

  public Task(string title)
  {
    Title = title;
  }
}