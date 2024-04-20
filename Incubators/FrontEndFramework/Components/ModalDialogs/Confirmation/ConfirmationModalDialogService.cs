namespace FrontEndFramework.Components.ModalDialogs.Confirmation;


public class ConfirmationModalDialogService
{
 
  protected static ConfirmationModalDialog? modalDialogInstance = null;
  
  public static void initialize(ConfirmationModalDialog confirmationModalDialogInstance)
  {
    ConfirmationModalDialogService.modalDialogInstance = confirmationModalDialogInstance;
  }
  
  
  public static void displayModalDialog(ConfirmationModalDialog.Options options)
  {
    ConfirmationModalDialogService.modalDialogInstance?.display(options);
  }

  public static void dismissModalDialog()
  {
    ConfirmationModalDialogService.modalDialogInstance?.dismiss();
  }
  
}