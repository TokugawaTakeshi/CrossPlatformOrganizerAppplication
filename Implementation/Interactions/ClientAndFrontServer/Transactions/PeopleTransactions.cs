namespace ClientAndFrontServer.Transactions;


public static class PeopleTransactions
{

  public static class RetrievingOfAll
  {
    public const string URN_PATH = "/api/people/all";
  }
  
  public static class RetrievingOfSelection
  {
    
    public const string URN_PATH = "/api/people/selection";
    
    public static class QueryParameters
    {
      public const string searchingByFullOrPartialNameOrItsSpell = "searching_by_full_or_partial_name_or_its_spell";
    }
  }
  
  public static class Adding
  {
    public const string URN_PATH = "/api/people/";
  }
  
  public static class Updating
  {
    public const string URN_PATH = "/api/people/";
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