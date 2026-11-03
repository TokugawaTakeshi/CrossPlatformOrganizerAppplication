namespace ClientAndFrontServer.Transactions.Task;


public static class TasksTransactions
{

  public static class RetrievingOfSelection
  {
    
    public const string URN_PATH = "/api/tasks/selection";

    public static class QueryParameters
    {
      
      public const string forcedFiltering = "ff";
      
      public static class ForcedFiltering
      {
    
        public static class ProgressStatus
        {
          public const string SPECIFIC_PART = "ps";
          public const string FULL_QUALIFIED_NAME = $"{ QueryParameters.forcedFiltering }.{ ProgressStatus.SPECIFIC_PART }";
        }
        
      }
      
      public const string optionalFiltering = "of";
      
      public static class OptionalFiltering
      {
        
        public static class StartingDate
        {
          public const string SPECIFIC_PART = "sd";
          public const string FULL_QUALIFIED_NAME = $"{ QueryParameters.optionalFiltering }.{ StartingDate.SPECIFIC_PART }";
        } 
        
        public static class EndingDate
        {
          public const string SPECIFIC_PART = "ed";
          public const string FULL_QUALIFIED_NAME = $"{ QueryParameters.optionalFiltering }.{ EndingDate.SPECIFIC_PART }";
        }
        
        public static class SearchingByFullOrPartialTitleOrDescription
        {
          public const string SPECIFIC_PART = "sr";
          public const string FULL_QUALIFIED_NAME = 
              $"{ QueryParameters.optionalFiltering }.{ SearchingByFullOrPartialTitleOrDescription.SPECIFIC_PART }";
        }
        
      }
            
    }
  
  }

  public static class Adding
  {
    public const string URN_PATH = "/api/tasks/";
  }
  
  public static class Updating
  {
    public const string URN_PATH = "/api/tasks/";
  }

  public static class TogglingCompletion
  {
    
    public const string URN_PATH_TEMPLATE = "/api/tasks/toggle_completion/{targetTaskID}";

    public static string buildURN(string targetTaskID)
    {
      return $"/api/tasks/toggle_completion/{ targetTaskID }";
    }
    
  }
  
  public static class Deleting
  {
    
    public const string URN_PATH_TEMPLATE = "/api/tasks/{targetTaskID}";

    public static string buildURN(string targetTaskID)
    {
      return $"/api/tasks/{ targetTaskID }";
    }
    
  }
  
}
