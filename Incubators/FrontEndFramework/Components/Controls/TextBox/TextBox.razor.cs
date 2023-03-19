using Microsoft.AspNetCore.Components;


namespace FrontEndFramework.Components.Controls.TextBox;


public partial class TextBox : ComponentBase
// TODO https://github.com/TokugawaTakeshi/ExperimentalCSharpApplication1/issues/36
// public partial class TextBox : InputtableControl
{

  /* === Blazor component parameters =============================================================================== */
  [Parameter]
  public string? label { get; set; }
  
  [Parameter]
  public string? guidance { get; set; }

  [Parameter] public bool multiline { get; set; } = false;
  
  [Parameter]
  public string spaceSeparatedAdditionalCSS_Classes { get; set; }
  
}