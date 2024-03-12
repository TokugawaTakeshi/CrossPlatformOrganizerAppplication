namespace ClientAndFrontServer;


public record TasksTransactions
{

  public record RetrievingOfAll
  {
    public const string URN_PATH = "/api/tasks/all";
  }
  
  public record RetrievingOfSelection
  {
    
    public const string URN_PATH = "/api/tasks/selection";

    public record QueryParameters
    {
      public const string onlyTasksWithAssociatedDate = "only_tasks_with_associated_date";
      public const string onlyTasksWithAssociatedDateTime = "only_tasks_with_associated_date_time";
      public const string searchingByFullOrPartialTitleOrDescription = "searching_by_full_or_partial_title";
    }

  }

  public record Adding
  {
    public const string URN_PATH = "/api/tasks/";
  }
  
  public record Updating
  {
    public const string URN_PATH = "/api/tasks/";
  }

  public record TogglingCompletion
  {
    
    public const string URN_PATH_TEMPLATE = "/api/tasks/toggle_completion/{targetTaskID}";

    public static string buildURN(string targetTaskID)
    {
      return $"/api/tasks/toggle_completion/{ targetTaskID }";
    }
    
  }
  
  public abstract class Deleting
  {
    
    public const string URN_PATH_TEMPLATE = "/api/tasks/{targetTaskID}";

    public static string buildURN(string targetTaskID)
    {
      return $"/api/tasks/{ targetTaskID }";
    }
    
  }
  
}
