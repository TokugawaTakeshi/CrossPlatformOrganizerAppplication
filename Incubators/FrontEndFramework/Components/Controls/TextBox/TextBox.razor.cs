using Microsoft.AspNetCore.Components;


namespace FrontEndFramework.Components.Controls.TextBox;


public partial class TextBox : InputtableControl
{

  /* === Blazor component parameters =============================================================================== */
  [Parameter] public bool multiline { get; set; } = false;
  
  [Parameter]
  public string? spaceSeparatedAdditionalCSS_Classes { get; set; }
  
}