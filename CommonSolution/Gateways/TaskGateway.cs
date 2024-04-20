namespace CommonSolution.Gateways;


public abstract class TaskGateway
{
 
  /* ━━━ Retrieving ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public abstract System.Threading.Tasks.Task<CommonSolution.Entities.Task[]> RetrieveAll();
  
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
      public required CommonSolution.Entities.Task[] Items { get; init; }
    }
    
  }

  
  /* ─── Filtering & Arranging ────────────────────────────────────────────────────────────────────────────────────── */
  public static CommonSolution.Entities.Task[] Filter(
    CommonSolution.Entities.Task[] tasks, SelectionRetrieving.RequestParameters filtering
  )
  {

    CommonSolution.Entities.Task[] workpiece = tasks;
    
    if (filtering.OnlyTasksWithAssociatedDate == true)
    {
      workpiece = workpiece.Where(
        task => task.associatedDate is not null
      ).ToArray();
    } else if (filtering.OnlyTasksWithAssociatedDateTime == true)
    {
      workpiece = workpiece.Where(
        task => task.associatedDateTime is not null
      ).ToArray();
    }

    if (!String.IsNullOrEmpty(filtering.SearchingByFullOrPartialTitleOrDescription))
    {
      workpiece = workpiece.
          Where(
            (CommonSolution.Entities.Task task) => 
                task.title.Contains(filtering.SearchingByFullOrPartialTitleOrDescription) ||
                (task.description?.Contains(filtering.SearchingByFullOrPartialTitleOrDescription) ?? false)
          ).
          ToArray();
    }

    return workpiece;

  }

  public static bool IsTaskSatisfyingToFilteringConditions(
    CommonSolution.Entities.Task task, SelectionRetrieving.RequestParameters filtering
  )
  {
    return TaskGateway.Filter([ task ], filtering).Length == 1;
  }
  
  public static CommonSolution.Entities.Task[] Arrange(CommonSolution.Entities.Task[] tasks)
  {
    return tasks.
        OrderBy((CommonSolution.Entities.Task task) => task.isComplete).
        ThenByDescending((CommonSolution.Entities.Task task) => task.associatedDateTime is not null).
        ThenByDescending((CommonSolution.Entities.Task task) => task.associatedDate is not null).
        ToArray();
  }
  
  
  /* ━━━ Adding ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public abstract System.Threading.Tasks.Task<CommonSolution.Entities.Task> Add(Adding.RequestData requestData);

  public abstract class Adding
  {
    
    public record RequestData
    {
      public required string Title { get; init; }
      public string? Description { get; init; }
      public bool IsComplete { get; init; }
      public string[]? SubtasksIDs { get; init; }
      public string? AssociatedDateTime__ISO8601 { get; init; }
      public string? AssociatedDate__ISO8601 { get; init; }
      public CommonSolution.Entities.Location? AssociatedLocation { get; init; }
    }

  }
  
  
  /* ━━━ Updating ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public abstract System.Threading.Tasks.Task<CommonSolution.Entities.Task> Update(Updating.RequestData requestData);
  
  public abstract class Updating
  {
    public record RequestData
    {
      public required string ID { get; init; }
      public required string Title { get; init; }
      public string? Description { get; init; }
      public bool IsComplete { get; init; }
      public string[]? SubtasksIDs { get; init; }
      public string? AssociatedDateTime__ISO8601 { get; init; }
      public string? AssociatedDate__ISO8601 { get; init; }
      public CommonSolution.Entities.Location? AssociatedLocation { get; init; }
    }
  }

  public abstract System.Threading.Tasks.Task ToggleCompletion(string targetTaskID);
  

  /* ━━━ Deleting ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public abstract System.Threading.Tasks.Task Delete(string targetTaskID);
  
}
