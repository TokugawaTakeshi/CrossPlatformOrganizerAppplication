using System.Diagnostics;


namespace Client.SharedState;


internal abstract class TasksSharedState
{

  public static event Action? onStateChanged;
  private static void NotifyStateChanged() => TasksSharedState.onStateChanged?.Invoke();
  
  
  /* === 取得 ======================================================================================================= */
  public static CommonSolution.Entities.Task[] tasks { get; private set; } = Array.Empty<CommonSolution.Entities.Task>();
  
  public static bool isWaitingForTasksSelectionRetrieving { get; private set; } = true;
  public static bool isTasksSelectionBeingRetrievedNow { get; private set; } = false;
  public static bool hasTasksSelectionRetrievingErrorOccurred { get; private set; } = false;

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
    catch (Exception e)
    {
      TasksSharedState.hasTasksSelectionRetrievingErrorOccurred = true;
      Debug.WriteLine(e);
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
