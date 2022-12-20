using Task = CommonSolution.Entities.Task.Task;
using CommonSolution.Gateways;

using MockDataSource.Utils;
using Utils.Pagination;


namespace MockDataSource.Gateways;


public class TaskMockGateway : ITaskGateway
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

  public Task<ITaskGateway.SelectionRetrieving.ResponseData> RetrieveSelection(
    ITaskGateway.SelectionRetrieving.RequestParameters requestParameters
  )
  {
    return MockGatewayHelper.SimulateDataRetrieving(
      requestParameters,
      getResponseData: () =>
      {

        Task[] filteredTasks;

        if (!String.IsNullOrEmpty(requestParameters.SearchingByFullOrPartialTitle))
        {
          filteredTasks = mockDataSource.Tasks.Where(
            task => task.Title.Contains(requestParameters.SearchingByFullOrPartialTitle)
          ).ToArray();
        }
        else
        {
          filteredTasks = mockDataSource.Tasks.ToArray();
        }

        Task[] itemsOfTargetPaginationPage = new PaginationCollection<Task>(
          filteredTasks, requestParameters.ItemsCountPerPaginationPage
        ).GetItemsArrayOfPageWithNumber(requestParameters.PaginationPageNumber);

        return new ITaskGateway.SelectionRetrieving.ResponseData
        {
          ItemsOfTargetPaginationPage = itemsOfTargetPaginationPage,
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