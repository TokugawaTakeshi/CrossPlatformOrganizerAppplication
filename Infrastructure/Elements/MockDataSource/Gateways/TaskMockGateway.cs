using Task = BusinessRules.Enterprise.Tasks.Task;
using Gateways;
using MockDataSource.Utils;


namespace MockDataSource.Gateways;


public class TaskMockGateway : ITasksGateway
{
  
  private readonly MockDataSource mockDataSource = MockDataSource.GetInstance();

  
  public Task<Task[]> RetrieveAll()
  {
    return MockGatewayHelper.SimulateDataRetrieving<object, Task[]>(
      requestParameters: null,
      getResponseData: mockDataSource.RetrieveAllTasks,
      new MockGatewayHelper.SimulationOptions
      {
        MinimalPendingPeriod__Seconds = 1,
        MaximalPendingPeriod__Seconds = 2,
        MustSimulateError = false,
        GatewayName = nameof(TaskMockGateway),
        TransactionName = "RetrievingOfAll"
      }
    );
  }
}