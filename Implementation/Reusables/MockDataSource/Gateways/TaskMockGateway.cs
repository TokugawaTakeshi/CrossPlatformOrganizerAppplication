using CommonSolution.Gateways.Task;
using YamatoDaiwa.CSharpExtensions.DataMocking;
using Task = CommonSolution.Entities.Task.Task;


namespace MockDataSource.Gateways;


public class TaskMockGateway : TaskGateway
{

  /* [ Usage ] Intended to be changed manually for testing purposes. */
  private static readonly bool NO_ITEMS_SIMULATION_MODE = false;
  
  
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
            items = [],
            totalItemsCountInSelection = 0,
            totalItemsCountWithForcedFiltering = 0
          };
        }


        Task[] arrangedTasksSelection = TaskGateway.Arrange(
          TaskGateway.Filter(MockDataSource.Tasks.ToArray(), requestParameters)
        ); 
        
        return new TaskGateway.SelectionRetrieving.ResponseData
        {
          items = arrangedTasksSelection,
          totalItemsCountInSelection = Convert.ToUInt32(arrangedTasksSelection.Length),
          totalItemsCountWithForcedFiltering = Convert.ToUInt32(MockDataSource.Tasks.Count)
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
  public override System.Threading.Tasks.Task<Task> Add(
    TaskGateway.Adding.RequestData requestData
  )
  {
    return MockGatewayHelper.SimulateDataSubmitting(
      requestData,
      getResponseData: () => MockDataSource.AddTask(requestData),
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
  public override System.Threading.Tasks.Task<Task> Update(
    TaskGateway.Updating.RequestData requestData
  )
  {
    return MockGatewayHelper.SimulateDataSubmitting(
      requestData,
      getResponseData: () => MockDataSource.UpdateTask(requestData),
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
        
        Task targetTask = MockDataSource.
            RetrieveAllTasks().
            Single(task => task.ID == targetTaskID);
        
        targetTask.isCompleted = !targetTask.isCompleted;
        
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
        MockDataSource.DeleteTask(targetTaskID);
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