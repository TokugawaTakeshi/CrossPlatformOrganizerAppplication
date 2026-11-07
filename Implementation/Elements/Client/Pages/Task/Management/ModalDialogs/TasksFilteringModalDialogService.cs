using FrontEndFramework.Components.ModalDialogs.Common;

namespace Client.Pages.Task.Management.ModalDialogs;


public static class TasksFilteringModalDialogService
{
 
  private static ModalDialog? _modalDialogInstance = null;

  
  public static void initialize(ModalDialog modalDialogInstance)
  {
    TasksFilteringModalDialogService._modalDialogInstance = modalDialogInstance;
  }
  
  public static void displayModalDialog()
  {
    TasksFilteringModalDialogService._modalDialogInstance?.display();
  }

  public static void dismissModalDialog()
  {
    TasksFilteringModalDialogService._modalDialogInstance?.dismiss();
  }
  
}
