using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;


namespace FrontEndFramework.Helpers;


public class DynamicTag : ComponentBase
{
 
  [Parameter]
  public required string name { get; set; }

  [Parameter]
  public Dictionary<string, object>? attributes { get; set; }

  [Parameter]
  public RenderFragment? childContent { get; set; }

  protected override void BuildRenderTree(RenderTreeBuilder builder)
  {

    if (string.IsNullOrWhiteSpace(this.name))
    {
      throw new ArgumentNullException(nameof(this.name));
    }

    builder.OpenElement(0, this.name);

    if (this.attributes?.Any() == true)
    {
      builder.AddMultipleAttributes(1, this.attributes);
    }

    if (this.childContent != null)
    {
      builder.AddContent(2, this.childContent);
    }
      
    
    builder.CloseElement();
    
  }
  
}
