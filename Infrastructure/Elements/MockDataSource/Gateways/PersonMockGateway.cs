using CommonSolution.Entities;
using CommonSolution.Gateways;

using MockDataSource.Utils;
using Utils.Pagination;


namespace MockDataSource.Gateways;


public class PersonMockGateway : IPersonGateway
{

  private readonly MockDataSource mockDataSource = MockDataSource.GetInstance();


  public Task<Person[]> RetrieveAll()
  {
    return MockGatewayHelper.SimulateDataRetrieving<object, Person[]>(
      requestParameters: null,
      getResponseData: mockDataSource.RetrieveAllPeople,
      new MockGatewayHelper.SimulationOptions
      {
        MinimalPendingPeriod__Seconds = 2,
        MaximalPendingPeriod__Seconds = 3,
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
    return MockGatewayHelper.SimulateDataRetrieving(
      requestParameters,
      getResponseData: () => {

        Person[] filteredPeople;

        if (!String.IsNullOrEmpty(requestParameters.SearchingByFullOrPartialName))
        {
          filteredPeople = mockDataSource.People.Where(
            person => person.FamilyName.Contains(requestParameters.SearchingByFullOrPartialName)
          ).ToArray();
        }
        else
        {
          filteredPeople = mockDataSource.People.ToArray();
        }

        List<Person> itemsOfTargetPaginationPage = new PaginationCollection<Person>(
          filteredPeople, requestParameters.ItemsCountPerPaginationPage
        ).GetItemsListOfPageWithNumber(requestParameters.PaginationPageNumber);

        return new IPersonGateway.SelectionRetrieving.ResponseData
        {
          ItemsOfTargetPaginationPage = itemsOfTargetPaginationPage,
          TotalItemsCountInSelection = Convert.ToUInt32(filteredPeople.Count),
          TotalItemsCount = Convert.ToUInt32(mockDataSource.People.Count)
        };
        
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
      getResponseData: () =>
      {
        mockDataSource.UpdatePerson(requestData);
        return null;
      },
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

  public Task Delete(string targetPersonID)
  {
    return MockGatewayHelper.SimulateDataSubmitting<string, object>(
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