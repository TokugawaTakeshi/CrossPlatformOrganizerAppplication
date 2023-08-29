namespace Client.SharedComponents.OnePerPage.Header;


public partial class Header : Microsoft.AspNetCore.Components.ComponentBase
{

  [Microsoft.AspNetCore.Components.Parameter]
  public string? spaceSeparatedAdditionalCSS_Classes { get; set; } = null;
  
  [Microsoft.AspNetCore.Components.Parameter]
  public string? hamburgerMenuButtonAdditionalCSS_Class { get; set; } = null;

}