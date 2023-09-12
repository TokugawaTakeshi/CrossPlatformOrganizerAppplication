using Utils;
using YamatoDaiwaCS_Extensions;


namespace FrontEndFramework.Components.ModalDialog;


public partial class ModalDialog : Microsoft.AspNetCore.Components.ComponentBase
{

  [Microsoft.AspNetCore.Components.Parameter]
  public string? title { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter]
  public required bool mustDisplay { get; set; }

  [Microsoft.AspNetCore.Components.Parameter]
  public bool noDismissingButton { get; set; } = false;
  
  [Microsoft.AspNetCore.Components.Parameter]
  public required Microsoft.AspNetCore.Components.EventCallback onPressDismissingButtonEventCallback { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter]
  public required Microsoft.AspNetCore.Components.RenderFragment ChildContent { get; set; }
  
  
  /* ━━━ Actions handing ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  protected async void onPressDismissingButton()
  {
    await this.onPressDismissingButtonEventCallback.InvokeAsync();
  }
  
  
  /* ━━━ CSS classes ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  [Microsoft.AspNetCore.Components.Parameter]
  public string? rootElementModifierCSS_Class { get; set; }

  private string rootElementModifierCSS_Classes => new List<string>().
    
      AddElementToEndIf(
        this.rootElementModifierCSS_Class ?? "", String.IsNullOrEmpty(this.rootElementModifierCSS_Class)
      ).
          
      StringifyEachElementAndJoin(" ");

}
