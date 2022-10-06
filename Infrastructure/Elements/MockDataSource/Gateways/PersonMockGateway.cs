using BusinessRules.Enterprise;
using Gateways;
using MockDataSource.Utils;
using Utils.Pagination;


namespace MockDataSource.Gateways;


public class PersonMockGateway : IPersonGateway
{

  private readonly MockDataSource mockDataSource = MockDataSource.getInstance();


  public Task<List<Person>> RetrieveAll()
  {
    return MockGatewayHelper.SimulateDataRetrieving<object, List<Person>>(
      requestParameters: null,
      getResponseData: mockDataSource.RetrieveAllPeople,
      new MockGatewayHelper.SimulationOptions
      {
        MinimalPendingPeriod__Seconds = 1,
        MaximalPendingPeriod__Seconds = 2,
        MustSimulateError = false,
        GatewayName = nameof(PersonMockGateway),
        TransactionName = "RetrievingOfAll"
      }
    );
  }

  public Task<IPersonGateway.SelectionRetrieving.ResponseData> RetrieveSelection(
    IPersonGateway.SelectionRetrieving.RequestParameters requestParameters
  )
  {

    return MockGatewayHelper.SimulateDataRetrieving<
      IPersonGateway.SelectionRetrieving.RequestParameters,
      IPersonGateway.SelectionRetrieving.ResponseData
    >(
      requestParameters: null,
      getResponseData: () => {

        List<Person> filteredItems;

        if (!String.IsNullOrEmpty(requestParameters.FilteringByName))
        {
          filteredItems = mockDataSource.People.Where(
            Person => Person.Name.Contains(requestParameters.FilteringByName)
          ).ToList();
        }
        else
        {
          filteredItems = mockDataSource.People;
        }

        List<Person> itemsActualForRequestedPaginationPage = PaginationHelper.SplitListToPaginationCollection(
          filteredItems, requestParameters.ItemsCountPerPaginationPage
        ).PagesContent[(int)requestParameters.PaginationPageNumber];

        return new IPersonGateway.SelectionRetrieving.ResponseData(
          totalItemsCount: Convert.ToUInt32(mockDataSource.People.Count),
          totalItemsCountInSelection: Convert.ToUInt32(filteredItems.Count),
          selectionItemsOfSpecifiedPaginationPage: itemsActualForRequestedPaginationPage
        );
      },
      new MockGatewayHelper.SimulationOptions
      {
        MinimalPendingPeriod__Seconds = 1,
        MaximalPendingPeriod__Seconds = 2,
        MustSimulateError = false,
        GatewayName = nameof(PersonMockGateway),
        TransactionName = "RetrievingOfSelection"
      }
    );
  }

  public Task<IPersonGateway.Adding.ResponseData> Add(IPersonGateway.Adding.RequestData requestData)
  {
    return MockGatewayHelper.SimulateDataSubmitting(
      requestData,
      getResponseData: () => mockDataSource.AddPerson(requestData),
      new MockGatewayHelper.SimulationOptions
      {
        MinimalPendingPeriod__Seconds = 1,
        MaximalPendingPeriod__Seconds = 2,
        MustSimulateError = false,
        GatewayName = nameof(PersonMockGateway),
        TransactionName = "Adding"
      }
    );
  }

  public Task Update(IPersonGateway.Updating.RequestData requestData)
  {
    return MockGatewayHelper.SimulateDataSubmitting<IPersonGateway.Updating.RequestData, object>(
      requestData,
      getResponseData: () => null,
      new MockGatewayHelper.SimulationOptions
      {
        MinimalPendingPeriod__Seconds = 1,
        MaximalPendingPeriod__Seconds = 2,
        MustSimulateError = false,
        GatewayName = nameof(PersonMockGateway),
        TransactionName = nameof(IPersonGateway.Adding)
      }
    );
  }

  public Task Delete(uint targetPersonID)
  {
    return MockGatewayHelper.SimulateDataSubmitting<uint, object>(
      targetPersonID,
      getResponseData: () => null,
      new MockGatewayHelper.SimulationOptions
      {
        MinimalPendingPeriod__Seconds = 1,
        MaximalPendingPeriod__Seconds = 2,
        MustSimulateError = false,
        GatewayName = nameof(PersonMockGateway),
        TransactionName = nameof(IPersonGateway.Adding)
      }
    );
  }
}