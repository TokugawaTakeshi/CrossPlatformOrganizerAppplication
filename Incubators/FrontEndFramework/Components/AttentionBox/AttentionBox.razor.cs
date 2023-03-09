using System.Diagnostics;
using Microsoft.AspNetCore.Components;
using Utils;


namespace FrontEndFramework.Components.AttentionBox;


public partial class AttentionBox : ComponentBase
{
  
  public enum StandardThemes
  {
    regular
  }
  
  [Parameter]
  public string theme { get; set; } = AttentionBox.StandardThemes.regular.ToString();

  internal static bool mustConsiderThemesAsExternal = false;
  
  public static void ConsiderThemesAsExternal()
  {
    AttentionBox.mustConsiderThemesAsExternal = true;
  }

  [Parameter]
  public bool areThemesExternal { get; set; } = AttentionBox.mustConsiderThemesAsExternal;
  
  
  public enum StandardGeometricVariations
  {
    regular
  }
  
  [Parameter]
  public string geometry { get; set; } = AttentionBox.StandardGeometricVariations.regular.ToString();
  
  
  public enum StandardDecorativeVariations
  {
    notice,
    error,
    warning,
    success,
    guidance,
    question
  }

  protected string decoration__stringified;

  [Parameter]
  public required object decoration
  {
    get => decoration__stringified;
    set
    {
      
      if (value is AttentionBox.StandardDecorativeVariations standardDecorativeVariation)
      {
        this.decoration__stringified = standardDecorativeVariation.ToString();
        return;
      }
      
      
      throw new Exception($"Invalid decorative variation for the component { nameof(AttentionBox) }.");
      
    }
  }
  
  
  [Parameter]
  public bool hasPrependedSVG_Icon { get; set; }
  
  [Parameter]
  public bool hasDismissingButton { get; set; }

  [Parameter]
  public string spaceSeparatedAdditionalCSS_Classes { get; set; }
  
  [Parameter]
  public RenderFragment ChildContent { get; set; }
  

  private void OnClickDismissingButton()
  {
    
  }
  
  private string rootElementModifierCSS_Classes
  {
    get
    {

      return new List<string>().
          AddElementToEndIf(
            $"AttentionBox--YDF__${ this.theme.ToUpperCamelCase() }Theme",
            _ => Enum.GetNames(typeof(StandardThemes)).Length > 1 && !this.areThemesExternal
          ).
          AddElementToEndIf(
            $"AttentionBox--YDF__${ this.geometry.ToUpperCamelCase() }Geometry",
            _ => Enum.GetNames(typeof(StandardGeometricVariations)).Length > 1
          ).
          AddElementToEndIf(
            $"AttentionBox--YDF__{ this.decoration__stringified.ToUpperCamelCase() }Decoration",
            _ => Enum.GetNames(typeof(StandardDecorativeVariations)).Length > 1
          ).
          StringifyEachElementAndJoin("");

    }
  }
  
}
