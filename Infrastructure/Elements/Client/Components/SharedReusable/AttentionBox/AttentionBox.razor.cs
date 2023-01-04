using Microsoft.AspNetCore.Components;
using Utils;


namespace Client.Components.SharedReusable.AttentionBox;


public partial class AttentionBox : ComponentBase
{
  
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
    regular
  }
  
  [Parameter]
  public string Geometry { get; set; }
  
  
  public enum StandardDecorativeVariations
  {
    notice,
    error,
    warning,
    success,
    guidance,
    question
  }
  
  [Parameter]
  public string Decoration { get; set; }
  
  
  [Parameter]
  public bool HasPrependedSVG_Icon { get; set; }
  
  [Parameter]
  public bool HasDismissingButton { get; set; }
  
  [Parameter]
  public string SpaceSeparatedAdditionalCSS_Classes { get; set; }
  

  private void OnClickDismissingButton()
  {
    
  }
  
  private string rootElementModifierCSS_Classes
  {
    get
    {

      return new List<string>().
          AddElementToEndIf(
            $"AttentionBox--YDF__${ Theme.ToLowerCamel() }Theme",
            _ => Enum.GetNames(typeof(StandardThemes)).Length > 1 && !AreThemesExternal
          ).
          AddElementToEndIf(
            $"AttentionBox--YDF__${ Geometry.ToLowerCamel() }Geometry",
            _ => Enum.GetNames(typeof(StandardGeometricVariations)).Length > 1
          ).
          AddElementToEndIf(
            $"AttentionBox--YDF__${ Decoration.ToLowerCamel() }Decoration",
            _ => Enum.GetNames(typeof(StandardDecorativeVariations)).Length > 1
          ).
          StringifyEachElementAndJoin("");

    }
  }
  
}
