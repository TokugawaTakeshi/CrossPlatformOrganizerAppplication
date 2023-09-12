using Task = CommonSolution.Entities.Task;
using CommonSolution.Gateways;
using YamatoDaiwaCS_Extensions.DataMocking;


namespace MockDataSource.Gateways;


public class TaskMockGateway : ITaskGateway
{
  
  private readonly MockDataSource mockDataSource = MockDataSource.GetInstance();

  /* 【 用途 】 手動変更専用 */
  private static readonly bool NO_ITEMS_SIMULATION_MODE = false;
  
  
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

  public Task<ITaskGateway.SelectionRetrieving.ResponseData> RetrieveSelection(
    ITaskGateway.SelectionRetrieving.RequestParameters requestParameters
  )
  {
    return MockGatewayHelper.SimulateDataRetrieving(
      requestParameters,
      getResponseData: () =>
      {

        if (TaskMockGateway.NO_ITEMS_SIMULATION_MODE)
        {
          return new ITaskGateway.SelectionRetrieving.ResponseData
          {
            Items = Array.Empty<Task>(),
            TotalItemsCountInSelection = 0,
            TotalItemsCount = 0
          };
        }
        
        
        Task[] filteredTasks = mockDataSource.Tasks.ToArray();

        if (requestParameters.OnlyTasksWithAssociatedDate == true)
        {
          filteredTasks = filteredTasks.Where(
            task => task.associatedDate is not null
          ).ToArray();
        } else if (requestParameters.OnlyTasksWithAssociatedDateTime == true)
        {
          filteredTasks = filteredTasks.Where(
            task => task.associatedDateTime is not null
          ).ToArray();
        }
        

        if (!String.IsNullOrEmpty(requestParameters.SearchingByFullOrPartialTitleOrDescription))
        {
          filteredTasks = filteredTasks.
              Where(
                task => 
                    task.title.Contains(requestParameters.SearchingByFullOrPartialTitleOrDescription) ||
                    (task.description?.Contains(requestParameters.SearchingByFullOrPartialTitleOrDescription) ?? false)
              ).
              ToArray();
        }

        filteredTasks = filteredTasks.
            OrderBy((Task task) => task.associatedDateTime is not null).
            ThenBy((Task task) => task.associatedDate is not null).
            ToArray();
        
        return new ITaskGateway.SelectionRetrieving.ResponseData
        {
          Items = filteredTasks,
          TotalItemsCountInSelection = Convert.ToUInt32(filteredTasks.Length),
          TotalItemsCount = Convert.ToUInt32(mockDataSource.People.Count)
        };
        
      },
      new MockGatewayHelper.SimulationOptions
      {
        MinimalPendingPeriod__Seconds = 1,
        MaximalPendingPeriod__Seconds = 2,
        MustSimulateError = false,
        GatewayName = nameof(TaskMockGateway),
        TransactionName = "RetrievingOfSelection"
      }
    );
    
  }

  public Task<ITaskGateway.Adding.ResponseData> Add(ITaskGateway.Adding.RequestData requestData)
  {
    return MockGatewayHelper.SimulateDataSubmitting(
      requestData,
      getResponseData: () => mockDataSource.AddTask(requestData),
      new MockGatewayHelper.SimulationOptions
      {
        MinimalPendingPeriod__Seconds = 1,
        MaximalPendingPeriod__Seconds = 2,
        MustSimulateError = false,
        GatewayName = nameof(TaskMockGateway),
        TransactionName = "Adding"
      }
    );
  }

  public System.Threading.Tasks.Task Update(ITaskGateway.Updating.RequestData requestData)
  {
    return MockGatewayHelper.SimulateDataSubmitting<ITaskGateway.Updating.RequestData, object>(
      requestData,
      getResponseData: () =>
      {
        mockDataSource.UpdateTask(requestData);
        return null;
      },
      new MockGatewayHelper.SimulationOptions
      {
        MinimalPendingPeriod__Seconds = 1,
        MaximalPendingPeriod__Seconds = 2,
        MustSimulateError = false,
        GatewayName = nameof(TaskMockGateway),
        TransactionName = nameof(ITaskGateway.Adding)
      }
    );
  }

  public System.Threading.Tasks.Task ToggleCompletion(string targetTaskID)
  {
    return MockGatewayHelper.SimulateDataRetrieving<string, object>(
      targetTaskID,
      getResponseData: () =>
      {
        Task targetTask = this.mockDataSource.RetrieveAllTasks().Single(task => task.ID == targetTaskID);
        targetTask.isComplete = !targetTask.isComplete;
        return null;
      },
      new MockGatewayHelper.SimulationOptions
      {
        MinimalPendingPeriod__Seconds = 1,
        MaximalPendingPeriod__Seconds = 2,
        MustSimulateError = false,
        GatewayName = nameof(TaskMockGateway),
        TransactionName = nameof(ITaskGateway.Adding)
      }
    );
  }

  public System.Threading.Tasks.Task Delete(string targetTaskID)
  {
    return MockGatewayHelper.SimulateDataSubmitting<string, object>(
      targetTaskID,
      getResponseData: () => null,
      new MockGatewayHelper.SimulationOptions
      {
        MinimalPendingPeriod__Seconds = 1,
        MaximalPendingPeriod__Seconds = 2,
        MustSimulateError = false,
        GatewayName = nameof(TaskMockGateway),
        TransactionName = nameof(ITaskGateway.Adding)
      }
    );
  }
  
}