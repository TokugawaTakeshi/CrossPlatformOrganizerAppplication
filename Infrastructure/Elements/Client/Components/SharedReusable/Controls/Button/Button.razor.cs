using Microsoft.AspNetCore.Components;
using Utils;


namespace Client.Components.SharedReusable.Controls.Button;


public partial class Button : ComponentBase
{

  [Parameter]
  public string Theme { get; set; }

  [Parameter]
  public bool AreThemesExternal { get; set; }
  
  [Parameter]
  public string SpaceSeparatedAdditionalCSS_Classes { get; set; }

  
  public enum HTML_Types
  {
    regular,
    submit,
    inputButton,
    inputSubmit,
    inputReset
  }
  
  public enum StandardThemes
  {
    regular
  }
  
  
  

  private bool isButtonTheTagNameOfRootElement => true;
  private bool isInputTheTagNameOfRootElement => false;
  private bool isAnchorTheTagNameOfRootElement => false;
  
  private string rootElementSpaceSeparatedClasses => new List<string>().
      AddElementsToEnd("Button--YDF").
      AddElementToEndIf(
        $"AttentionBox--YDF__${ Theme.ToLowerCamel() }Theme",
        _ => Enum.GetNames(typeof(StandardThemes)).Length > 1 && !AreThemesExternal
      ).
      StringifyEachElementAndJoin(" ");

}