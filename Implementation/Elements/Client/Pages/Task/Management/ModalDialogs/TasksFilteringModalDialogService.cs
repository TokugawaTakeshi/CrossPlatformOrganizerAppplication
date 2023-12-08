using FrontEndFramework.Components.ModalDialog;

namespace Client.Pages.Task.Management.ModalDialogs;


public class TasksFilteringModalDialogService
{
 
  protected static ModalDialog? modalDialogInstance = null;

  
  public static void initialize(ModalDialog modalDialogInstance)
  {
    TasksFilteringModalDialogService.modalDialogInstance = modalDialogInstance;
  }
  
  public static void displayModalDialog()
  {
    TasksFilteringModalDialogService.modalDialogInstance?.display();
  }

  public static void dismissModalDialog()
  {
    TasksFilteringModalDialogService.modalDialogInstance?.dismiss();
  }
  
}