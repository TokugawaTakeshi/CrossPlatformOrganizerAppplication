using System.Diagnostics;
using CommonSolution.Gateways;
using YamatoDaiwa.CSharpExtensions;
using YamatoDaiwa.CSharpExtensions.Exceptions;


namespace Client.SharedState;


internal abstract class TasksSharedState
{

  public static event Action? onStateChanged;
  private static void NotifyStateChanged() => TasksSharedState.onStateChanged?.Invoke();

  private static TaskGateway? _taskGateway;
  private static TaskGateway taskGateway => 
      TasksSharedState._taskGateway ??= 
      ClientDependencies.Injector.gateways().Task;


  /* ━━━ Selecting ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private static CommonSolution.Entities.Task? _currentlySelectedTask = null;
  
  public delegate void OnSelectedTaskHasChanged(CommonSolution.Entities.Task newTask);
  public static OnSelectedTaskHasChanged? onSelectedTaskHasChanged;
  
  public static CommonSolution.Entities.Task? currentlySelectedTask
  {
    get => TasksSharedState._currentlySelectedTask;
    set
    {
      
      TasksSharedState._currentlySelectedTask = value;

      if (value is not null)
      {
        TasksSharedState.onSelectedTaskHasChanged?.Invoke(value);
      }
      
      TasksSharedState.NotifyStateChanged();
      
    }
  }
  
  
  /* ━━━ Retrieving ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private static List<CommonSolution.Entities.Task> _tasksSelection = [];
  public static List<CommonSolution.Entities.Task> tasksSelection
  {
    get => TasksSharedState._tasksSelection;
    private set
    {
      TasksSharedState._tasksSelection = value;
      TasksSharedState.NotifyStateChanged();
    }
  }

  
  private static uint _totalTasksCountInDataSource = 0;
  public static uint totalTasksCountInDataSource
  {
    get => TasksSharedState._totalTasksCountInDataSource;
    private set
    {
      TasksSharedState._totalTasksCountInDataSource = value;
      TasksSharedState.NotifyStateChanged();
    }
  }
  
  private static uint _totalTasksCountInSelection = 0;
  public static uint totalTasksCountInSelection
  {
    get => TasksSharedState._totalTasksCountInSelection;
    private set
    {
      TasksSharedState._totalTasksCountInSelection = value;
      TasksSharedState.NotifyStateChanged();
    }
  }
  
  private static string? _searchingByFullOrPartialTitleOrDescription = null;
  public static string? searchingByFullOrPartialTitleOrDescription
  {
    get => TasksSharedState._searchingByFullOrPartialTitleOrDescription;
    private set
    {
      TasksSharedState._searchingByFullOrPartialTitleOrDescription = value;
      TasksSharedState.NotifyStateChanged();
    }
  }

  public static bool _onlyTasksWithAssociatedDate = false;
  public static bool onlyTasksWithAssociatedDate
  {
    get => TasksSharedState._onlyTasksWithAssociatedDate;
    private set
    {
      TasksSharedState._onlyTasksWithAssociatedDate = value;
      TasksSharedState.NotifyStateChanged();
    }
  }
  
  public static bool _onlyTasksWithAssociatedDateTime = false;
  public static bool onlyTasksWithAssociatedDateTime
  {
    get => TasksSharedState._onlyTasksWithAssociatedDateTime;
    private set
    {
      TasksSharedState._onlyTasksWithAssociatedDateTime = value;
      TasksSharedState.NotifyStateChanged();
    }
  }
  

  private static bool _isWaitingForTasksSelectionRetrieving = true;
  public static bool isWaitingForTasksSelectionRetrieving
  {
    get => TasksSharedState._isWaitingForTasksSelectionRetrieving;
    private set
    {
      TasksSharedState._isWaitingForTasksSelectionRetrieving = value;
      TasksSharedState.NotifyStateChanged();
    }
  }
  
  private static bool _isTasksSelectionBeingRetrievedNow = false;
  public static bool isTasksSelectionBeingRetrievedNow
  {
    get => TasksSharedState._isTasksSelectionBeingRetrievedNow;
    private set
    {
      TasksSharedState._isTasksSelectionBeingRetrievedNow = value;
      TasksSharedState.NotifyStateChanged();
    }
  }
  
  private static bool _hasTasksSelectionRetrievingErrorOccurred = false;
  public static bool hasTasksSelectionRetrievingErrorOccurred
  {
    get => TasksSharedState._hasTasksSelectionRetrievingErrorOccurred;
    private set
    {
      TasksSharedState._hasTasksSelectionRetrievingErrorOccurred = value;
      TasksSharedState.NotifyStateChanged();
    }
  }

  public static bool isTasksRetrievingInProgressOrNotStartedYet => 
      TasksSharedState.isWaitingForTasksSelectionRetrieving || TasksSharedState.isTasksSelectionBeingRetrievedNow;
  
  public static async System.Threading.Tasks.Task retrieveTasksSelection(
    TaskGateway.SelectionRetrieving.RequestParameters? requestParameters = null,
    bool mustResetSearchingByFullOrPartialTitleOrDescription = false,
    bool mustResetFilteringByAssociatedDate = false,
    bool mustResetFilteringByAssociatedDateTime = false
  )
  {

    if (TasksSharedState.isTasksSelectionBeingRetrievedNow)
    {
      return;      
    }


    TasksSharedState.currentlySelectedTask = null;
    TasksSharedState.isWaitingForTasksSelectionRetrieving = false;
    TasksSharedState.isTasksSelectionBeingRetrievedNow = true;
    TasksSharedState.hasTasksSelectionRetrievingErrorOccurred = false;

    if (mustResetSearchingByFullOrPartialTitleOrDescription)
    {
      TasksSharedState.searchingByFullOrPartialTitleOrDescription = null;
    }
    else
    {
      TasksSharedState.searchingByFullOrPartialTitleOrDescription =
          requestParameters?.SearchingByFullOrPartialTitleOrDescription ??
          TasksSharedState.searchingByFullOrPartialTitleOrDescription;
    }

    if (mustResetFilteringByAssociatedDate)
    {
      TasksSharedState.onlyTasksWithAssociatedDate = false;
    }
    else if (requestParameters?.OnlyTasksWithAssociatedDate == true)
    {
      TasksSharedState.onlyTasksWithAssociatedDate = true;
      TasksSharedState.onlyTasksWithAssociatedDateTime = false;
    }

    if (mustResetFilteringByAssociatedDateTime)
    {
      TasksSharedState.onlyTasksWithAssociatedDateTime = false;
    }
    else if (requestParameters?.OnlyTasksWithAssociatedDateTime == true)
    {
      TasksSharedState.onlyTasksWithAssociatedDateTime = true;
      TasksSharedState.onlyTasksWithAssociatedDate = false;
    }

    
    TaskGateway.SelectionRetrieving.ResponseData responseData;
    
    try
    {

      responseData = await TasksSharedState.taskGateway.RetrieveSelection(
        new TaskGateway.SelectionRetrieving.RequestParameters
        {
          SearchingByFullOrPartialTitleOrDescription = TasksSharedState.searchingByFullOrPartialTitleOrDescription,
          OnlyTasksWithAssociatedDate = TasksSharedState.onlyTasksWithAssociatedDate,
          OnlyTasksWithAssociatedDateTime = TasksSharedState.onlyTasksWithAssociatedDateTime
        }
      );

    }
    catch (Exception exception)
    {
      
      TasksSharedState.hasTasksSelectionRetrievingErrorOccurred = true;
      TasksSharedState.isTasksSelectionBeingRetrievedNow = false;
      
      Debug.WriteLine(exception);
      
      return;
      
    }


    TasksSharedState.tasksSelection = responseData.Items.ToList();
    TasksSharedState.totalTasksCountInSelection = responseData.TotalItemsCountInSelection;
    TasksSharedState.totalTasksCountInDataSource = responseData.TotalItemsCount;
    
    TasksSharedState.isTasksSelectionBeingRetrievedNow = false;

  }
  
  
  /* ━━━ Adding ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public static async System.Threading.Tasks.Task<CommonSolution.Entities.Task> addTask(
    CommonSolution.Gateways.TaskGateway.Adding.RequestData requestData,
    bool mustRetrieveUnfilteredTasksIfNewOneDoesNotSatisfyingTheCurrentFilteringConditions
  )
  {

    CommonSolution.Entities.Task newTask;
    
    try
    {
      newTask = await TasksSharedState.taskGateway.Add(requestData);
    }
    catch (Exception exception)
    {
      throw new DataSubmittingFailedException("Failed to add the new task.", exception);
    }


    TaskGateway.SelectionRetrieving.RequestParameters currentFiltering = new()
    {
      SearchingByFullOrPartialTitleOrDescription = TasksSharedState.searchingByFullOrPartialTitleOrDescription,
      OnlyTasksWithAssociatedDate = TasksSharedState.onlyTasksWithAssociatedDate,
      OnlyTasksWithAssociatedDateTime = TasksSharedState.onlyTasksWithAssociatedDateTime
    };

    
    TasksSharedState.totalTasksCountInDataSource++;
    
    if (TaskGateway.IsTaskSatisfyingToFilteringConditions(newTask, currentFiltering))
    {
      
      TasksSharedState.tasksSelection = TaskGateway.Arrange(
        TaskGateway.Filter(
          TasksSharedState.tasksSelection.AddElementsToStart(newTask).ToArray(), currentFiltering
        ) 
      ).ToList();
      
      TasksSharedState.totalTasksCountInSelection++;

      return newTask;

    }


    if (mustRetrieveUnfilteredTasksIfNewOneDoesNotSatisfyingTheCurrentFilteringConditions)
    {
      _ = TasksSharedState.retrieveTasksSelection(
        new TaskGateway.SelectionRetrieving.RequestParameters
        {
          SearchingByFullOrPartialTitleOrDescription = null,
          OnlyTasksWithAssociatedDate = null,
          OnlyTasksWithAssociatedDateTime = null
        }
      );
    }

    return newTask;

  }
  
  
  /* ━━━ Updating ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private static bool _isTaskBeingUpdatedNow = false;
  public static bool isTaskBeingUpdatedNow
  {
    get => TasksSharedState._isTaskBeingUpdatedNow;
    private set
    {
      TasksSharedState._isTaskBeingUpdatedNow = value;
      TasksSharedState.NotifyStateChanged();
    }
  }
  
  public static async System.Threading.Tasks.Task updateTask(
    CommonSolution.Gateways.TaskGateway.Updating.RequestData requestData
  )
  {

    TasksSharedState.isTaskBeingUpdatedNow = true;

    try
    {
      await ClientDependencies.Injector.gateways().Task.Update(requestData);
    }
    catch (Exception exception)
    {
      throw new DataSubmittingFailedException(
        $"The error has occurred during the updating of task with ID \"{ requestData.ID }\"", exception
      );
    }
    finally
    {
      TasksSharedState.isTaskBeingUpdatedNow = false;
    }
    
    
    CommonSolution.Entities.Task targetTask = TasksSharedState.tasksSelection.Single(task => task.ID == requestData.ID);

    targetTask.title = requestData.Title;
    targetTask.description = requestData.Description;
    targetTask.isComplete = requestData.IsComplete;
    
    TasksSharedState.NotifyStateChanged();

  }

  public static async System.Threading.Tasks.Task toggleTaskCompletion(string targetTaskID)
  {

    try
    {
      await ClientDependencies.Injector.gateways().Task.ToggleCompletion(targetTaskID);
    }
    catch (Exception exception)
    {
      throw new DataRetrievingFailedException(
        $"The error has occurred during the updating of task with ID \"{ targetTaskID }\"",  exception
      );
    }
    

    CommonSolution.Entities.Task targetTask = TasksSharedState.tasksSelection.Single(task => task.ID == targetTaskID);
    targetTask.isComplete = !targetTask.isComplete; 
    
    TasksSharedState.NotifyStateChanged();

  } 
  
  
  /* ━━━ Deleting ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public static async System.Threading.Tasks.Task deleteTask(string targetTaskID)
  {

    try
    {
      await TasksSharedState.taskGateway.Delete(targetTaskID);  
    } catch (Exception exception)
    {
      throw new DataSubmittingFailedException($"Failed to delete the task with ID \"{ targetTaskID }\"", exception);
    }


    if (targetTaskID == TasksSharedState.currentlySelectedTask?.ID)
    {
      TasksSharedState.currentlySelectedTask = null;
    }

    TasksSharedState.totalTasksCountInDataSource--;

    if (TasksSharedState.tasksSelection.Any(task => task.ID == targetTaskID))
    {
      TasksSharedState.totalTasksCountInSelection--;
    }
    
    TasksSharedState.tasksSelection.RemoveAll(task => task.ID == targetTaskID);

  }
  
}
