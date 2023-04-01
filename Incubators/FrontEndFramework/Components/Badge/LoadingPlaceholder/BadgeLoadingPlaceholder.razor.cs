using Microsoft.AspNetCore.Components;
using Utils;


namespace FrontEndFramework.Components.Badge.LoadingPlaceholder;


public partial class BadgeLoadingPlaceholder : ComponentBase
{

  [Parameter] 
  public string theme { get; set; } = Badge.StandardThemes.regular.ToString(); // TODO ① 正しく文字列と始末する

  [Parameter]
  public bool areThemesExternal { get; set; } = Badge.mustConsiderThemesAsExternal;
  
  
  [Parameter]
  public string geometry { get; set; } = Badge.StandardThemes.regular.ToString(); // TODO ① 正しく文字列と始末する
  
  [Parameter]
  public Badge.GeometricModifiers[] geometricModifiers { get; set; } = Array.Empty<Badge.GeometricModifiers>(); 
  
  [Parameter]
  public string? spaceSeparatedAdditionalCSS_Classes { get; set; }
  
  
  private string rootElementModifierCSS_Classes
  {
    get
    {

      return new List<string>().
          AddElementToEndIf(
            $"Badge--YDF__{ this.theme.ToLowerCamelCase() }Theme",
            _ => Enum.GetNames(typeof(Badge.StandardThemes)).Length > 1 && !this.areThemesExternal
          ).
          AddElementToEndIf(
            $"Badge--YDF__{ this.geometry.ToLowerCamelCase() }Geometry",
            _ => Enum.GetNames(typeof(Badge.StandardGeometricVariations)).Length > 1
          ).
          AddElementToEndIf(
            "Badge--YDF__PllShapeGeometricModifier", 
            _ => this.geometricModifiers.Contains(Badge.GeometricModifiers.pillShape)
          ).
          StringifyEachElementAndJoin("");

    }
  }
  
}