namespace CommonSolution.Entities.Task;


public class TaskCustomFolder
{
  
  public required string ID { get; init; }
  public required string title { get; init; }
  public TaskCustomFolder? parent { get; init; }
  public List<TaskCustomFolder> children { get; init; } = [];
  public required uint order { get; init; }

  public string path
  {
    get
    {

      TaskCustomFolder currentDepthLevel = this;
      List<string> pathSegments = [ currentDepthLevel.title ];

      while (currentDepthLevel.parent is not null)
      {
        currentDepthLevel = currentDepthLevel.parent;
        pathSegments.Add(currentDepthLevel.title);
      }

      return String.Join("/", pathSegments);

    }
  }
  
}
