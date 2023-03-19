using Task = CommonSolution.Entities.Task.Task;

using System.Diagnostics;


namespace Client.SharedStateManagers;


internal sealed class TasksSharedStateManager
{

  /* === 取得 ======================================================================================================= */
  // TODO リアクティビチを導入
  public static CommonSolution.Entities.Task.Task[] tasks { get; private set; } = Array.Empty<CommonSolution.Entities.Task.Task>();
  
  public static bool isWaitingForTasksSelectionRetrieving { get; private set; } = true;
  public static bool isTasksSelectionBeingRetrievedNow { get; private set; } = false;
  public static bool isTasksSelectionRetrievingErrorOccurred { get; private set; } = false;

  public static bool isTasksRetrievingInProgressOrNotStartedYet => 
      TasksSharedStateManager.isWaitingForTasksSelectionRetrieving || TasksSharedStateManager.isTasksSelectionBeingRetrievedNow;
  
  public static async System.Threading.Tasks.Task retrieveTasks()
  {
    
    TasksSharedStateManager.isWaitingForTasksSelectionRetrieving = false;
    TasksSharedStateManager.isTasksSelectionBeingRetrievedNow = true;
    TasksSharedStateManager.isTasksSelectionRetrievingErrorOccurred = false;
    
    try
    {
      TasksSharedStateManager.tasks = await ClientDependencies.Injector.gateways().Task.RetrieveAll();
    }
    catch (Exception e)
    {
      Debug.WriteLine(e);
      TasksSharedStateManager.isTasksSelectionRetrievingErrorOccurred = true;
    }

    TasksSharedStateManager.isTasksSelectionBeingRetrievedNow = false;
    
  }
  
  
  /* === 選択 ======================================================================================================= */
  private static Task? _currentlySelectedTask = null;
  public static Task? currentlySelectedTask
  {
    get => TasksSharedStateManager._currentlySelectedTask;
    set
    {
      TasksSharedStateManager._currentlySelectedTask = value;
      TasksSharedStateManager.NotifyStateChanged();
    }
  }
  
  
  public static event Action onStateChanged;

  private static void NotifyStateChanged() => TasksSharedStateManager.onStateChanged?.Invoke();

}