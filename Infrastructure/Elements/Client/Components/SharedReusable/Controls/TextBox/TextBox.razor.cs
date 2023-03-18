using Microsoft.AspNetCore.Components;


namespace Client.Components.SharedReusable.Controls.TextBox;


public partial class TextBox : ComponentBase
{

  [Parameter]
  public string spaceSeparatedAdditionalCSS_Classes { get; set; }
  
}