using YamatoDaiwa.Frontend.Helpers;

namespace FrontEndFramework.Components.Controls.MenuList;


public partial class MenuList : Microsoft.AspNetCore.Components.ComponentBase 
{

  [Microsoft.AspNetCore.Components.Parameter(CaptureUnmatchedValues = true)]
  public Dictionary<string, object>? rootElementHTML_Attributes { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter]
  public Microsoft.AspNetCore.Components.RenderFragment? ChildContent { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter]
  public bool mustDisplay { get; set; } = false;
  
  private string getClassAttributeValueForRootElement(string CSS_Namespace)
  {
    return YDF_ComponentsHelper.GenerateClassAttributeValueForRootElement(
      new YDF_ComponentsHelper.SettingsForGeneratingOfClassAttributeValueForRootElement
      {
        CSS_Namespace = CSS_Namespace,
        rootElementHTML_Attributes = this.rootElementHTML_Attributes
      }
    );
  }
}
