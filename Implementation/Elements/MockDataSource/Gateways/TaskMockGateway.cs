using CommonSolution.Gateways;
using YamatoDaiwa.CSharpExtensions.DataMocking;


namespace MockDataSource.Gateways;


public class TaskMockGateway : TaskGateway
{
  
  private readonly MockDataSource mockDataSource = MockDataSource.GetInstance();

  /* [ Usage ] Intended to be changed manually for testing purposes. */
  private static readonly bool NO_ITEMS_SIMULATION_MODE = false;
  
  
  public override System.Threading.Tasks.Task<CommonSolution.Entities.Task[]> RetrieveAll()
  {
    return MockGatewayHelper.SimulateDataRetrieving<object?, CommonSolution.Entities.Task[]>(
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

  public override System.Threading.Tasks.Task<TaskGateway.SelectionRetrieving.ResponseData> RetrieveSelection(
    TaskGateway.SelectionRetrieving.RequestParameters requestParameters
  )
  {
    return MockGatewayHelper.SimulateDataRetrieving(
      requestParameters,
      getResponseData: () =>
      {

        if (TaskMockGateway.NO_ITEMS_SIMULATION_MODE)
        {
          return new TaskGateway.SelectionRetrieving.ResponseData
          {
            Items = [],
            TotalItemsCountInSelection = 0,
            TotalItemsCount = 0
          };
        }


        CommonSolution.Entities.Task[] arrangedTasksSelection = TaskGateway.Arrange(
          TaskGateway.Filter(mockDataSource.Tasks.ToArray(), requestParameters)
        ); 
        
        return new TaskGateway.SelectionRetrieving.ResponseData
        {
          Items = arrangedTasksSelection,
          TotalItemsCountInSelection = Convert.ToUInt32(arrangedTasksSelection.Length),
          TotalItemsCount = Convert.ToUInt32(mockDataSource.Tasks.Count)
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
  
  
  /* ━━━ Adding ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public override System.Threading.Tasks.Task<CommonSolution.Entities.Task> Add(
    TaskGateway.Adding.RequestData requestData
  )
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
  
  
  /* ━━━ Updating ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public override System.Threading.Tasks.Task<CommonSolution.Entities.Task> Update(
    TaskGateway.Updating.RequestData requestData
  )
  {
    return MockGatewayHelper.SimulateDataSubmitting(
      requestData,
      getResponseData: () => mockDataSource.UpdateTask(requestData),
      new MockGatewayHelper.SimulationOptions
      {
        MinimalPendingPeriod__Seconds = 1,
        MaximalPendingPeriod__Seconds = 2,
        MustSimulateError = false,
        GatewayName = nameof(TaskMockGateway),
        TransactionName = nameof(TaskGateway.Adding)
      }
    );
  }

  public override System.Threading.Tasks.Task ToggleCompletion(string targetTaskID)
  {
    return MockGatewayHelper.SimulateDataRetrieving<string, object>(
      targetTaskID,
      getResponseData: () =>
      {
        
        CommonSolution.Entities.Task targetTask = this.mockDataSource.
            RetrieveAllTasks().
            Single(task => task.ID == targetTaskID);
        
        targetTask.isComplete = !targetTask.isComplete;
        
        return null;
        
      },
      new MockGatewayHelper.SimulationOptions
      {
        MinimalPendingPeriod__Seconds = 1,
        MaximalPendingPeriod__Seconds = 2,
        MustSimulateError = false,
        GatewayName = nameof(TaskMockGateway),
        TransactionName = nameof(TaskGateway.Adding)
      }
    );
  }

  
  /* ━━━ Deleting ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public override System.Threading.Tasks.Task Delete(string targetTaskID)
  {
    return MockGatewayHelper.SimulateDataSubmitting<string, object>(
      targetTaskID,
      getResponseData: () =>
      {
        this.mockDataSource.DeleteTask(targetTaskID);
        return null;
      },
      new MockGatewayHelper.SimulationOptions
      {
        MinimalPendingPeriod__Seconds = 1,
        MaximalPendingPeriod__Seconds = 2,
        MustSimulateError = false,
        GatewayName = nameof(TaskMockGateway),
        TransactionName = nameof(TaskGateway.Adding)
      }
    );
  }
  
}