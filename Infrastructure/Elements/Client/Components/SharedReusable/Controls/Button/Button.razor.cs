using Microsoft.AspNetCore.Components;
using Utils;


namespace Client.Components.SharedReusable.Controls.Button;


public partial class Button : ComponentBase
{

  public enum HTML_Types
  {
    regular,
    submit,
    inputButton,
    inputSubmit,
    inputReset
  }
  
  [Parameter] 
  public HTML_Types HTML_Type { get; set; } = HTML_Types.regular;
  
  [Parameter] 
  public string? Label { get; set; }
  
  [Parameter] 
  public string? AccessibilityGuidance { get; set; }
  
  [Parameter]
  public string? InternalURN { get; set; }

  [Parameter]
  public string? ExternalLinkURI { get; set; }
  
  [Parameter] 
  public bool Disabled { get; set; }
  
  
  public enum StandardThemes
  {
    regular
  }
  
  [Parameter]
  public string Theme { get; set; }

  [Parameter]
  public bool AreThemesExternal { get; set; }
  
  
  public enum StandardGeometricVariations
  {
    regular,
    small,
    linkLike
  }
  
  [Parameter]
  public string Geometry { get; set; }

  [Parameter]
  public string Decoration { get; set; }
  
  public enum StandardDecorativeVariations
  {
    regular,
    accented,
    linkLike
  }
  
  [Parameter]
  public string SpaceSeparatedAdditionalCSS_Classes { get; set; }


  private bool isButtonTheTagNameOfRootElement =>
      String.IsNullOrEmpty(InternalURN) &&
      String.IsNullOrEmpty(ExternalLinkURI) &&
      HTML_Type is HTML_Types.regular or HTML_Types.submit;

  private bool isInputTheTagNameOfRootElement => 
      HTML_Type is HTML_Types.inputButton or HTML_Types.inputSubmit or HTML_Types.inputReset;
  
  private bool isAnchorTheTagNameOfRootElement => !String.IsNullOrEmpty(ExternalLinkURI);
  
  private bool isNavLinkTheRootElement => !String.IsNullOrEmpty(InternalURN);

  private string? typeAttributeValueOfInputOrButtonElement {

    get
    {
      if (String.IsNullOrEmpty(InternalURN))
      {
        return null;
      }

      return HTML_Type switch
      {
        HTML_Types.regular => "button",
        HTML_Types.submit => "submit",
        HTML_Types.inputButton => "button",
        HTML_Types.inputSubmit => "submit",
        HTML_Types.inputReset => "reset",
        _ => null
      };
    }

  }

  private void onClick()
  {
    
  }
  
  private string rootElementSpaceSeparatedClasses => new List<string>().
      AddElementsToEnd("Button--YDF").
      AddElementToEndIf(
        "Button--YDF__DisabledState",
        _ => (isAnchorTheTagNameOfRootElement || isNavLinkTheRootElement) && Disabled
      ).
      AddElementToEndIf(
        $"Button--YDF__${ Theme.ToLowerCamel() }Theme",
        _ => Enum.GetNames(typeof(StandardThemes)).Length > 1 && !AreThemesExternal
      ).
      AddElementToEndIf(
        $"Button--YDF__${ Geometry.ToLowerCamel() }Geometry",
        _ => Enum.GetNames(typeof(StandardGeometricVariations)).Length > 1
      ).
      AddElementToEndIf(
        $"Button--YDF__${ Decoration.ToLowerCamel() }Decoration",
        _ => Enum.GetNames(typeof(StandardDecorativeVariations)).Length > 1
      ).
      StringifyEachElementAndJoin(" ");

}