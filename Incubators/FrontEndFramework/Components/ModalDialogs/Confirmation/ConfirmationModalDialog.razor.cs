using FrontEndFramework.Components.ModalDialogs.Common;

namespace FrontEndFramework.Components.ModalDialogs.Confirmation;


public partial class ConfirmationModalDialog : Microsoft.AspNetCore.Components.ComponentBase
{
  
  /* ━━━ State ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  protected string title = "";
  protected string question = "";
  protected string confirmationButtonLabel = "Yes";
  protected string cancellationButtonLabel = "No";
  protected Action onConfirmationButtonClickedEventHandler = () => {}; 

  protected ModalDialog genericModalDialogInstance = null!; 

  protected override void OnInitialized()
  {
    base.OnInitialized();
    ConfirmationModalDialogService.initialize(this);
  }

  /* ━━━ Public methods ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public record Options
  {
    public required string title;
    public required string question;
    public string? confirmationButtonLabel;
    public string? cancellationButtonLabel;
    public required Action onConfirmationButtonClickedEventHandler;
  }
  
  public void display(ConfirmationModalDialog.Options options)
  {
    
    this.title = options.title;
    this.question = options.question;
    this.confirmationButtonLabel = options.confirmationButtonLabel ?? "Yes";
    this.cancellationButtonLabel = options.cancellationButtonLabel ?? "No";
    
    this.onConfirmationButtonClickedEventHandler = options.onConfirmationButtonClickedEventHandler;
    
    this.genericModalDialogInstance.display();
    
    base.StateHasChanged();
    
  }

  public void dismiss()
  {
    
    this.genericModalDialogInstance.dismiss();

    this.title = "";
    this.question = "";
    this.confirmationButtonLabel = "Yes";
    this.cancellationButtonLabel = "No";
    
    base.StateHasChanged();
    
  }

  
  /* ━━━ Actions handling ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  protected void onConfirmationButtonClicked()
  {
    this.onConfirmationButtonClickedEventHandler();
    this.genericModalDialogInstance.dismiss();
  }
  
  protected void onCancellationButtonClicked()
  {
    this.genericModalDialogInstance.dismiss();
  }
  
}