using Microsoft.AspNetCore.Components;


namespace FrontEndFramework.Components.Controls.TextBox;


public partial class TextBox : InputtableControl
{

  public enum HTML_Types
  {
    regular,
    email,
    number,
    password,
    phoneNumber,
    URI,
    hidden
  }

  [Parameter] 
  public HTML_Types HTML_Type { get; set; } = HTML_Types.regular;
  
  
  /* === Blazor component parameters =============================================================================== */
  [Parameter] public bool multiline { get; set; } = false;
  
  [Parameter]
  public string? spaceSeparatedAdditionalCSS_Classes { get; set; }
  
}