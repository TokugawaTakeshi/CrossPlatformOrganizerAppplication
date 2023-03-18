using System.Diagnostics;
using Task = CommonSolution.Entities.Task.Task;


namespace Client.SharedStateManagers;


internal sealed class TasksSharedStateManager
{

  private static Task? _currentlySelectedTask = null;
  public static Task? currentlySelectedTask
  {
    get => TasksSharedStateManager._currentlySelectedTask;
    set
    {
      Debug.WriteLine("CP2");
      TasksSharedStateManager._currentlySelectedTask = value;
      TasksSharedStateManager.NotifyStateChanged();
    }
  }
  
  
  public static event Action onStateChanged;

  private static void NotifyStateChanged() => TasksSharedStateManager.onStateChanged?.Invoke();

}