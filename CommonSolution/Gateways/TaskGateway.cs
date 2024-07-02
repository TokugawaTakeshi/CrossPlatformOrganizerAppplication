using Task = CommonSolution.Entities.Task.Task;

namespace CommonSolution.Gateways;


public abstract class TaskGateway
{
 
  /* ━━━ Retrieving ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public abstract System.Threading.Tasks.Task<Task[]> RetrieveAll();
  
  public abstract Task<SelectionRetrieving.ResponseData> RetrieveSelection(
    SelectionRetrieving.RequestParameters requestParameters
  );
  
  public abstract class SelectionRetrieving
  {
    
    public record RequestParameters
    {
      public string? SearchingByFullOrPartialTitleOrDescription { get; init; }
      
      private readonly bool? _onlyTasksWithAssociatedDate = null;
      private readonly bool? _onlyTasksWithAssociatedDateTime = null;
      
      private class IncompatiblePropertiesException : Exception
      {
        public IncompatiblePropertiesException() : base(
          "\"OnlyTasksWithAssociatedDate\" and \"OnlyTasksWithAssociatedDateTime\" are mutually exclusive. " +
          "Only one of them can be initialized with \"true\" value."
        ) { }
      }
      

      public bool? OnlyTasksWithAssociatedDate
      {
        get => this._onlyTasksWithAssociatedDate;
        init
        {

          if (this._onlyTasksWithAssociatedDateTime is true)
          {
            throw new IncompatiblePropertiesException();
          }
          
          
          this._onlyTasksWithAssociatedDate = value;
          
        }
      }

      public bool? OnlyTasksWithAssociatedDateTime
      {
        get => this._onlyTasksWithAssociatedDateTime;
        init
        {

          if (this._onlyTasksWithAssociatedDate is true)
          {
            throw new IncompatiblePropertiesException();
          }


          this._onlyTasksWithAssociatedDateTime = value;

        }
      }
      
    }

    public record ResponseData
    {
      public required uint TotalItemsCount { get; init; }
      public required uint TotalItemsCountInSelection { get; init; }
      public required Task[] Items { get; init; }
    }
    
  }

  
  /* ─── Filtering & Arranging ────────────────────────────────────────────────────────────────────────────────────── */
  public static Task[] Filter(
    Task[] tasks, SelectionRetrieving.RequestParameters filtering
  )
  {

    Task[] workpiece = tasks;
    
    if (filtering.OnlyTasksWithAssociatedDate == true)
    {
      workpiece = workpiece.Where(
        task => task.deadlineDate is not null
      ).ToArray();
    } else if (filtering.OnlyTasksWithAssociatedDateTime == true)
    {
      workpiece = workpiece.Where(
        task => task.deadlineDateTime is not null
      ).ToArray();
    }

    if (!String.IsNullOrEmpty(filtering.SearchingByFullOrPartialTitleOrDescription))
    {
      workpiece = workpiece.
          Where(
            (Task task) => 
                task.title.Contains(filtering.SearchingByFullOrPartialTitleOrDescription) ||
                (task.description?.Contains(filtering.SearchingByFullOrPartialTitleOrDescription) ?? false)
          ).
          ToArray();
    }

    return workpiece;

  }

  public static bool IsTaskSatisfyingToFilteringConditions(
    Task task, SelectionRetrieving.RequestParameters filtering
  )
  {
    return TaskGateway.Filter([ task ], filtering).Length == 1;
  }
  
  public static Task[] Arrange(Task[] tasks)
  {
    return tasks.
        OrderBy((Task task) => task.isComplete).
        ThenByDescending((Task task) => task.deadlineDateTime is not null).
        ThenByDescending((Task task) => task.deadlineDate is not null).
        ToArray();
  }
  
  
  /* ━━━ Adding ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public abstract System.Threading.Tasks.Task<Task> Add(Adding.RequestData requestData);

  public abstract class Adding
  {
    
    public record RequestData
    {
      public required string Title { get; init; }
      public string? Description { get; init; }
      public bool IsComplete { get; init; }
      public string[]? SubtasksIDs { get; init; }
      public CommonSolution.Entities.Location? AssociatedLocation { get; init; }
    }

  }
  
  
  /* ━━━ Updating ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public abstract System.Threading.Tasks.Task<Task> Update(Updating.RequestData requestData);
  
  public abstract class Updating
  {
    public record RequestData
    {
      public required string ID { get; init; }
      public required string Title { get; init; }
      public string? Description { get; init; }
      public bool IsComplete { get; init; }
      public string[]? SubtasksIDs { get; init; }
      public CommonSolution.Entities.Location? AssociatedLocation { get; init; }
    }
  }

  public abstract System.Threading.Tasks.Task ToggleCompletion(string targetTaskID);
  

  /* ━━━ Deleting ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public abstract System.Threading.Tasks.Task Delete(string targetTaskID);
  
}
