using CommonSolution.Entities;


namespace CommonSolution.Gateways;


public interface IPersonGateway
{

  /* === 取得 ======================================================================================================== */
  Task<Person[]> RetrieveAll();
  
  
  /* --- 標本 -------------------------------------------------------------------------------------------------------- */
  Task<SelectionRetrieving.ResponseData> RetrieveSelection(SelectionRetrieving.RequestParameters requestParameters);
  
  public abstract class SelectionRetrieving
  {
    
    public struct RequestParameters
    {
      public required uint PaginationPageNumber { get; init; }
      public required uint ItemsCountPerPaginationPage { get; init; }
      public string? SearchingByFullOrPartialName { get; init; }
    }

    public struct ResponseData
    {
      public required uint TotalItemsCount;
      public required uint TotalItemsCountInSelection;
      public required Person[] ItemsOfTargetPaginationPage;
    }
    
  }

  
  /* === 追加 ======================================================================================================= */
  Task<Adding.ResponseData> Add(Adding.RequestData requestData);

  public abstract class Adding
  {
    
    public struct RequestData
    {
      public required string FamilyName { get; init; }
      public required string GivenName { get; init; }
      public byte? Age { get; set; }
      public string? EmailAddress { get; init; }
      public string? PhoneNumber { get; init; }
    }

    public struct ResponseData
    {
      public required string AddedPersonID { get; init; }
    }
    
  }
  
  
  /* === 更新 ======================================================================================================= */
  Task Update(Updating.RequestData requestData);

  public abstract class Updating
  {
    public struct RequestData
    {
      public required string ID { get; set; }
      public required string FamilyName { get; init; }
      public required string GivenName { get; init; }
      public string? EmailAddress { get; init; }
      public string? PhoneNumber { get; init; }
      public byte? Age { get; init; }
    }
  }
  
  
  /* === 削除 ======================================================================================================== */
  Task Delete(string targetPersonID);
  
}
