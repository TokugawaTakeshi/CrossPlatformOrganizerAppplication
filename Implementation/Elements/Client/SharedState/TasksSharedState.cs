using System.Diagnostics;


namespace Client.SharedState;


internal abstract class TasksSharedState
{

  public static event Action? onStateChanged;
  private static void NotifyStateChanged() => TasksSharedState.onStateChanged?.Invoke();
  
  
  /* === 取得 ======================================================================================================= */
  public static CommonSolution.Entities.Task[] _tasks = Array.Empty<CommonSolution.Entities.Task>();
  public static CommonSolution.Entities.Task[] tasks
  {
    get => TasksSharedState._tasks;
    private set
    {
      TasksSharedState._tasks = value;
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
  
  public static async System.Threading.Tasks.Task retrieveTasks()
  {

    if (TasksSharedState.isTasksSelectionBeingRetrievedNow)
    {
      return;      
    }
    
    
    TasksSharedState.isWaitingForTasksSelectionRetrieving = false;
    TasksSharedState.isTasksSelectionBeingRetrievedNow = true;
    TasksSharedState.hasTasksSelectionRetrievingErrorOccurred = false;
    
    try
    {
      TasksSharedState.tasks = await ClientDependencies.Injector.gateways().Task.RetrieveAll();
    }
    catch (Exception exception)
    {
      TasksSharedState.hasTasksSelectionRetrievingErrorOccurred = true;
      Debug.WriteLine(exception);
    }

    TasksSharedState.isTasksSelectionBeingRetrievedNow = false;
    
  }
  
  
  /* === 選択 ======================================================================================================= */
  private static CommonSolution.Entities.Task? _currentlySelectedTask = null;
  public static CommonSolution.Entities.Task? currentlySelectedTask
  {
    get => TasksSharedState._currentlySelectedTask;
    set
    {
      TasksSharedState._currentlySelectedTask = value;
      TasksSharedState.NotifyStateChanged();
    }
  }

}
