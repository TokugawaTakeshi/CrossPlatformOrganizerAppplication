namespace Client.Pages.Task.Management.ModalDialogs;


public class TasksFilteringModalDialogService
{
 
  public static event Action? onStateChanged;
  protected static void NotifyStateChanged() => TasksFilteringModalDialogService.onStateChanged?.Invoke();
  
  protected static bool _isModalDialogDisplaying = false;
  public static bool isModalDialogDisplaying
  {
    get => TasksFilteringModalDialogService._isModalDialogDisplaying;
    protected set
    {
      TasksFilteringModalDialogService._isModalDialogDisplaying = value;
      TasksFilteringModalDialogService.NotifyStateChanged();
    }
  }


  public static void openModalDialog()
  {
    TasksFilteringModalDialogService.isModalDialogDisplaying = true;
  }
  
}