using Task = CommonSolution.Entities.Task;


namespace CommonSolution.Gateways;


public interface ITaskGateway
{
 
  /* === 取得 ======================================================================================================== */
  Task<Task[]> RetrieveAll();
  
  
  /* --- 標本 -------------------------------------------------------------------------------------------------------- */
  Task<SelectionRetrieving.ResponseData> RetrieveSelection(SelectionRetrieving.RequestParameters requestParameters);
  
  public abstract class SelectionRetrieving
  {
    
    public struct RequestParameters
    {
      public required uint PaginationPageNumber { get; init; }
      public required uint ItemsCountPerPaginationPage { get; init; }
      public string? SearchingByFullOrPartialTitle { get; init; }
    }

    public struct ResponseData
    {
      public required uint TotalItemsCount;
      public required uint TotalItemsCountInSelection;
      public required Task[] ItemsOfTargetPaginationPage;
    }
    
  }

  
  /* === 追加 ======================================================================================================= */
  Task<Adding.ResponseData> Add(Adding.RequestData requestData);

  public abstract class Adding
  {
    
    public struct RequestData
    {
      public required string Title { get; init; }
      public string? Description { get; init; }
      public string[]? SubtasksIDs { get; init; }
    }

    public struct ResponseData
    {
      public required string AddedTaskID { get; init; }
    }
    
  }
  
  
  /* === 更新 ======================================================================================================= */
  System.Threading.Tasks.Task Update(Updating.RequestData requestData);
  
  public abstract class Updating
  {
    public struct RequestData
    {
      public required string ID { get; init; }
      public required string Title { get; init; }
      public string? Description { get; init; }
      public string[]? SubtasksIDs { get; init; }
      public bool IsComplete { get; init; }
    }
  }
  
  
  /* === 削除 ======================================================================================================== */
  System.Threading.Tasks.Task Delete(string targetTaskID);
  
}
