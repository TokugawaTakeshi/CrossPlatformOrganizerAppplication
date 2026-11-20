using CommonSolution.Entities.Task;
using CommonSolution.Gateways.Task;
using YamatoDaiwa.CSharpExtensions.DataMocking;

namespace MockDataSource.Gateways ;


public class TaskCustomFolderMockGateway : TaskCustomFolderGateway
{
  
  /* [ Usage ] Must be prenamed manually for testing purposes. */
  private static readonly bool NO_ITEMS_SIMULATION_MODE = false;
  
  public Task<TaskCustomFolder[]> RetrieveTreeOfAll()
  {
    return MockGatewayHelper.SimulateDataRetrieving<object, TaskCustomFolder[]>(
      requestParameters: null,
      getResponseData: 
          TaskCustomFolderMockGateway.NO_ITEMS_SIMULATION_MODE ? 
              Array.Empty<TaskCustomFolder> : MockDataSource.TaskCustomFolders.ToArray,
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
  
}