﻿using Task = CommonSolution.Entities.Task;


namespace CommonSolution.Gateways;


public interface ITaskGateway
{
 
  /* ━━━ 取得 ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  Task<Task[]> RetrieveAll();
  
  Task<SelectionRetrieving.ResponseData> RetrieveSelection(SelectionRetrieving.RequestParameters requestParameters);
  
  public abstract class SelectionRetrieving
  {
    
    public struct RequestParameters
    {
      public string? SearchingByFullOrPartialTitleOrDescription { get; init; }
      public bool? OnlyTasksWithAssociatedDate { get; init; }
      public bool? OnlyTasksWithAssociatedDateTime { get; init; }
    }

    public struct ResponseData
    {
      public required uint TotalItemsCount;
      public required uint TotalItemsCountInSelection;
      public required Task[] Items;
    }
    
  }

  
  /* ━━━ 追加 ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  Task<Adding.ResponseData> Add(Adding.RequestData requestData);

  public abstract class Adding
  {
    
    public struct RequestData
    {
      public required string Title { get; init; }
      public string? Description { get; init; }
      public bool IsComplete { get; init; }
      public string[]? SubtasksIDs { get; init; }
      public string? AssociatedDateTime__ISO8601 { get; init; }
      public string? AssociatedDate__ISO8601 { get; init; }
      public CommonSolution.Entities.Location? AssociatedLocation { get; init; }
    }

    public struct ResponseData
    {
      public required string AddedTaskID { get; init; }
    }
    
  }
  
  
  /* ━━━ 更新 ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  System.Threading.Tasks.Task Update(Updating.RequestData requestData);
  
  public abstract class Updating
  {
    public struct RequestData
    {
      public required string ID { get; init; }
      public string Title { get; init; }
      public string? Description { get; init; }
      public bool IsComplete { get; init; }
      public string[]? SubtasksIDs { get; init; }
      public string? AssociatedDateTime__ISO8601 { get; init; }
      public string? AssociatedDate__ISO8601 { get; init; }
      public CommonSolution.Entities.Location? AssociatedLocation { get; init; }
    }
  }

  
  System.Threading.Tasks.Task ToggleCompletion(string targetTaskID);
  

  /* ━━━ 削除 ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  System.Threading.Tasks.Task Delete(string targetTaskID);
  
}
