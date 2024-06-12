using Person = CommonSolution.Entities.Person;
using CommonSolution.Gateways;
using YamatoDaiwa.CSharpExtensions.DataMocking;


namespace MockDataSource.Gateways;


public class PersonMockGateway : PersonGateway
{

  private readonly MockDataSource mockDataSource = MockDataSource.GetInstance();
  
  /* [ Usage ] Must be prenamed manually for testing purposes. */
  private static readonly bool NO_ITEMS_SIMULATION_MODE = false;


  public override Task<Person[]> RetrieveAll()
  {
    return MockGatewayHelper.SimulateDataRetrieving<object, Person[]>(
      requestParameters: null,
      getResponseData: PersonMockGateway.NO_ITEMS_SIMULATION_MODE ? Array.Empty<Person> : mockDataSource.RetrieveAllPeople,
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

  public override Task<PersonGateway.SelectionRetrieving.ResponseData> RetrieveSelection(
    PersonGateway.SelectionRetrieving.RequestParameters? requestParameters
  )
  {

    string? searchingByFullOrPartialNameOrItsSpell = requestParameters?.SearchingByFullOrPartialNameOrItsSpell; 
    
    return MockGatewayHelper.SimulateDataRetrieving(
      requestParameters,
      getResponseData: () => {

        if (PersonMockGateway.NO_ITEMS_SIMULATION_MODE)
        {
          return new PersonGateway.SelectionRetrieving.ResponseData
          {
            Items = [],
            TotalItemsCountInSelection = 0,
            TotalItemsCount = 0
          }; 
        }
        
        
        Person[] filteredPeople;
        
        if (!String.IsNullOrEmpty(searchingByFullOrPartialNameOrItsSpell))
        {

          filteredPeople = mockDataSource.People.
              Where(
                person => 
                    person.familyName.Contains(searchingByFullOrPartialNameOrItsSpell) ||
                    (person.givenName?.Contains(searchingByFullOrPartialNameOrItsSpell) ?? false) ||
                    (person.familyNameSpell?.Contains(searchingByFullOrPartialNameOrItsSpell) ?? false) ||
                    (person.givenNameSpell?.Contains(searchingByFullOrPartialNameOrItsSpell) ?? false)
              ).
              ToArray();

        }
        else
        {
          filteredPeople = mockDataSource.People.ToArray();
        }

        return new PersonGateway.SelectionRetrieving.ResponseData
        {
          Items = filteredPeople,
          TotalItemsCountInSelection = Convert.ToUInt32(filteredPeople.Length),
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

  public override Task<Person> Add(PersonGateway.Adding.RequestData requestData)
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

  public override Task<Person> Update(PersonGateway.Updating.RequestData requestData)
  {
    return MockGatewayHelper.SimulateDataSubmitting(
      requestData,
      getResponseData: () => mockDataSource.UpdatePerson(requestData),
      new MockGatewayHelper.SimulationOptions
      {
        MinimalPendingPeriod__Seconds = 1,
        MaximalPendingPeriod__Seconds = 2,
        MustSimulateError = false,
        GatewayName = nameof(PersonMockGateway),
        TransactionName = nameof(PersonGateway.Adding)
      }
    );
  }

  public override Task Delete(string targetPersonID)
  {
    return MockGatewayHelper.SimulateDataSubmitting<string, object>(
      targetPersonID,
      getResponseData: () =>
      {
        this.mockDataSource.DeleteTask(targetPersonID);
        return null;
      },
      new MockGatewayHelper.SimulationOptions
      {
        MinimalPendingPeriod__Seconds = 1,
        MaximalPendingPeriod__Seconds = 2,
        MustSimulateError = false,
        GatewayName = nameof(PersonMockGateway),
        TransactionName = nameof(PersonGateway.Adding)
      }
    );
  }
  
}