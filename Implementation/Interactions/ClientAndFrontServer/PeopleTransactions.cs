namespace ClientAndFrontServer;


public record PeopleTransactions
{

  public record RetrievingOfAll
  {
    public const string URN_PATH = "/api/people/all";
  }
  
  public record RetrievingOfSelection
  {
    
    public const string URN_PATH = "/api/people/selection";
    
    public record QueryParameters
    {
      public const string searchingByFullOrPartialNameOrItsSpell = "searching_by_full_or_partial_name_or_its_spell";
    }
  }
  
  public record Adding
  {
    public const string URN_PATH = "/api/people/";
  }
  
  public record Updating
  {
    public const string URN_PATH = "/api/people/";
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