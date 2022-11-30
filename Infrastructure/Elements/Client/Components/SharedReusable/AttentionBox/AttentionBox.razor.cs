using Microsoft.AspNetCore.Components;
using Utils;


namespace Client.Components.SharedReusable.AttentionBox;


public partial class AttentionBox : ComponentBase
{
  [Parameter]
  public string Theme { get; set; }

  [Parameter]
  public bool AreThemesExternal { get; set; }
  
  [Parameter]
  public string Geometry { get; set; }
  
  [Parameter]
  public string Decoration { get; set; }
  
  [Parameter]
  public bool HasPrependedSVG_Icon { get; set; }
  
  [Parameter]
  public bool HasDismissingButton { get; set; }
  
  
  public enum StandardThemes
  {
    regular
  }
  
  public enum StandardGeometricVariations
  {
    regular
  }

  public enum StandardDecorativeVariations
  {
    importantInfo,
    secondaryInfo,
    notice,
    error,
    warning,
    success,
    guidance,
    question
  }


  private string rootElementModifierCSS_Classes
  {
    get
    {

      List<string> rootElementModifierCSS_Classes = new List<string>();

      if (Enum.GetNames(typeof(StandardThemes)).Length > 1 && !AreThemesExternal)
      {
        rootElementModifierCSS_Classes.Add($"AttentionBox--YDF__${ Theme.ToLowerCamel() }Theme");
      }

      if (Enum.GetNames(typeof(StandardGeometricVariations)).Length > 1)
      {
        rootElementModifierCSS_Classes.Add($"AttentionBox--YDF__${ Geometry.ToLowerCamel() }Geometry");
      }
      
      if (Enum.GetNames(typeof(StandardDecorativeVariations)).Length > 1)
      {
        rootElementModifierCSS_Classes.Add($"AttentionBox--YDF__${ Decoration.ToLowerCamel() }Decoration");
      }

      
      return String.Join(" ", rootElementModifierCSS_Classes);

    }
  }
}
