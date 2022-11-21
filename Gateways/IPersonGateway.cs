using BusinessRules.Enterprise;


namespace Gateways
{
  public interface IPersonGateway
  {

    /* === 取得 ====================================================================================================== */
    Task<List<Person>> RetrieveAll();


    /* --- 標本 ------------------------------------------------------------------------------------------------------ */
    public class SelectionRetrieving
    {

      public class RequestParameters
      {

        public readonly uint PaginationPageNumber;
        public readonly uint ItemsCountPerPaginationPage;
        public readonly string? FilteringByName;

        public RequestParameters(
          uint paginationPageNumber,
          uint itemsCountPerPaginationPage,
          string filteringByName
        )
        {
          PaginationPageNumber = paginationPageNumber;
          ItemsCountPerPaginationPage = itemsCountPerPaginationPage;
          FilteringByName = filteringByName;
        }
      }

      public class ResponseData
      {

        public readonly uint TotalItemsCount;
        public readonly uint TotalItemsCountInSelection;
        public readonly List<Person> SelectionItemsOfSpecifiedPaginationPage;

        public ResponseData(
          uint totalItemsCount,
          uint totalItemsCountInSelection,
          List<Person> selectionItemsOfSpecifiedPaginationPage
        )
        {
          TotalItemsCount = totalItemsCount;
          TotalItemsCountInSelection = totalItemsCountInSelection;
          SelectionItemsOfSpecifiedPaginationPage = selectionItemsOfSpecifiedPaginationPage;
        }
      }
    }

    Task<SelectionRetrieving.ResponseData> RetrieveSelection(SelectionRetrieving.RequestParameters requestParameters);


    /* === 追加 ====================================================================================================== */
    public abstract class Adding
    {

      public class RequestData
      {

        public readonly string Name;
        public readonly string Email;
        public readonly string PhoneNumber;
        public readonly byte? Age;

        public RequestData(
          string name,
          string email,
          string phoneNumber,
          byte? age
        )
        {
          Name = name;
          Age = age;
          Email = email;
          PhoneNumber = phoneNumber;
        }
      }

      public class ResponseData
      {

        public readonly uint AddedPersonID;

        public ResponseData(uint addedPersonID)
        {
          AddedPersonID = addedPersonID;
        }
      }
    }

    Task<Adding.ResponseData> Add(Adding.RequestData requestData);


    /* === 更新 ====================================================================================================== */
    public abstract class Updating
    {

      public class RequestData
      {

        public readonly uint ID;
        public readonly string Name;
        public readonly string Email;
        public readonly string PhoneNumber;
        public readonly byte? Age;

        public RequestData(
          uint ID,
          string name,
          string email,
          string phoneNumber,
          byte? age
        )
        {
          this.ID = ID;
          Name = name;
          Age = age;
          Email = email;
          PhoneNumber = phoneNumber;
        }
      }
    }

    System.Threading.Tasks.Task Update(Updating.RequestData requestData);


    /* === 削除 ====================================================================================================== */
    System.Threading.Tasks.Task Delete(uint targetPersonID);
  }
}
