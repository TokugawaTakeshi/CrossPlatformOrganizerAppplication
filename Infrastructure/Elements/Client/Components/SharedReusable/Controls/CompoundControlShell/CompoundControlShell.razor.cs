using Microsoft.AspNetCore.Components;


namespace Client.Components.SharedReusable.Controls.CompoundControlShell;


public partial class CompoundControlShell : ComponentBase
{

  [Parameter]
  public string SpaceSeparatedAdditionalCSS_Classes { get; set; }
  
}