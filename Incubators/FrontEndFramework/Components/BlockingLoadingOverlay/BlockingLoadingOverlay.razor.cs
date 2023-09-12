namespace FrontEndFramework.Components.BlockingLoadingOverlay;


using LoadingIndicator = LoadingIndicator.LoadingIndicator; 


public partial class BlockingLoadingOverlay : Microsoft.AspNetCore.Components.ComponentBase 
{

  protected override void OnInitialized()
  {
    BlockingLoadingOverlayService.onStateChanged += base.StateHasChanged;
  }
  
  
  [Microsoft.AspNetCore.Components.Parameter] 
  public LoadingIndicator.Types loadingIndicatorType { get; set; }
  
}
