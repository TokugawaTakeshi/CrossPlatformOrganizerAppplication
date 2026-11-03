namespace CommonSolution.Gateways.Task;


public abstract class TaskGateway
{
 
  /* ━━━ Retrieving ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public abstract System.Threading.Tasks.Task<SelectionRetrieving.ResponseData> RetrieveSelection(
    SelectionRetrieving.RequestParameters requestParameters
  );
  
  public abstract class SelectionRetrieving
  {

    public record RequestParameters
    {
      
      public required ForcedFiltering forcedFiltering { get; init; }
      
      public record ForcedFiltering
      {

        public required ProgressStatues progressStatus { get; init; }
        
        public enum ProgressStatues
        {
          uncompleted,
          completed
        }
        
      }
      
      public OptionalFiltering? optionalFiltering { get; init; }
      
      public record OptionalFiltering
      {
        public DateOnly? startingDate;
        public DateOnly? endingDate;
        public string? searchingByFullOrPartialTitleOrDescription;
      }
      
    }

    public record ResponseData
    {
      public required uint totalItemsCountWithForcedFiltering { get; init; }
      public required uint totalItemsCountInSelection { get; init; }
      public required CommonSolution.Entities.Task.Task[] items { get; init; }
    }
    
  }

  
  /* ─── Filtering & Arranging ────────────────────────────────────────────────────────────────────────────────────── */
  public static CommonSolution.Entities.Task.Task[] Filter(
    CommonSolution.Entities.Task.Task[] notFilteredYetTasks, 
    SelectionRetrieving.RequestParameters requestParameters
  )
  {

    IEnumerable<CommonSolution.Entities.Task.Task> mutableCollection = notFilteredYetTasks;

    mutableCollection = requestParameters.forcedFiltering.progressStatus switch
    {
      SelectionRetrieving.RequestParameters.ForcedFiltering.ProgressStatues.completed => 
          mutableCollection.Where((CommonSolution.Entities.Task.Task task) => task.isCompleted),
      SelectionRetrieving.RequestParameters.ForcedFiltering.ProgressStatues.uncompleted => 
          mutableCollection.Where((CommonSolution.Entities.Task.Task task) => !task.isCompleted),
      _ => mutableCollection
    };

    if (requestParameters.optionalFiltering?.startingDate != null)
    {
        
      mutableCollection = mutableCollection.Where(
        (CommonSolution.Entities.Task.Task task) => 
            (task.startingDate is not null && task.startingDate >= requestParameters.optionalFiltering.startingDate) || 
            (
              task.startingDateTime is not null && 
              DateOnly.FromDateTime(task.startingDateTime.Value) >= requestParameters.optionalFiltering.startingDate
            )
      );
    }

    if (requestParameters.optionalFiltering?.endingDate != null)
    {
        
      mutableCollection = mutableCollection.
          Where(
            (CommonSolution.Entities.Task.Task task) => 
              (task.endingDate is not null && task.endingDate >= requestParameters.optionalFiltering.endingDate) || 
              (
                task.endingDateTime is not null && 
                DateOnly.FromDateTime(task.endingDateTime.Value) >= requestParameters.optionalFiltering.startingDate
              )
          );
    }

    if (requestParameters.optionalFiltering?.searchingByFullOrPartialTitleOrDescription != null)
    {
      mutableCollection = mutableCollection.
          Where(
            (CommonSolution.Entities.Task.Task task) =>
                task.title.Contains(requestParameters.optionalFiltering.searchingByFullOrPartialTitleOrDescription) ||
                (task.description?.Contains(requestParameters.optionalFiltering.searchingByFullOrPartialTitleOrDescription) ?? false)
      ); 
    }
    
    return mutableCollection.ToArray();

  }

  public static bool IsTaskSatisfyingToFilteringConditions(
    CommonSolution.Entities.Task.Task task, SelectionRetrieving.RequestParameters filtering
  )
  {
    return TaskGateway.Filter([ task ], filtering).Length == 1;
  }
  
  public static CommonSolution.Entities.Task.Task[] Arrange(CommonSolution.Entities.Task.Task[] tasks)
  {
    return tasks.
        OrderBy((CommonSolution.Entities.Task.Task task) => task.isCompleted).
        ThenByDescending((CommonSolution.Entities.Task.Task task) => task.startingDate is not null).
        ThenByDescending((CommonSolution.Entities.Task.Task task) => task.endingDate is not null).
        ThenByDescending((CommonSolution.Entities.Task.Task task) => task.deadlineDate is not null).
        ToArray();
  }
  
  
  /* ━━━ Adding ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public abstract System.Threading.Tasks.Task<CommonSolution.Entities.Task.Task> Add(Adding.RequestData requestData);

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
  public abstract System.Threading.Tasks.Task<CommonSolution.Entities.Task.Task> Update(Updating.RequestData requestData);
  
  public abstract class Updating
  {
    public record RequestData
    {
      public required string ID { get; init; }
      public required string Title { get; init; }
      public string? Description { get; init; }
      public bool IsCompleted { get; init; }
      public string[]? SubtasksIDs { get; init; }
      public CommonSolution.Entities.Location? AssociatedLocation { get; init; }
    }
  }

  public abstract System.Threading.Tasks.Task ToggleCompletion(string targetTaskID);
  

  /* ━━━ Deleting ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public abstract System.Threading.Tasks.Task Delete(string targetTaskID);
  
}
