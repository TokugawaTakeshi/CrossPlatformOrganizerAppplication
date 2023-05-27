using Microsoft.AspNetCore.Components;
using Utils;


namespace FrontEndFramework.Components.Badge.LoadingPlaceholder;


public partial class BadgeLoadingPlaceholder : ComponentBase
{

  /* --- Theme ------------------------------------------------------------------------------------------------------ */
  protected string _theme = Badge.StandardThemes.regular.ToString();
  
  [Parameter] public object theme
  {
    get => this._theme;
    set
    {

      if (value is Badge.StandardThemes standardTheme)
      {
        this._theme = standardTheme.ToString();
        return;
      }
      
      
      // TODO CustomThemes確認 https://github.com/TokugawaTakeshi/ExperimentalCSharpApplication1/issues/34#issuecomment-1500788874
      
      this._theme = value.ToString();

    }
  }

  [Parameter]
  public bool areThemesExternal { get; set; } = Badge.mustConsiderThemesAsExternal;
  
  
  /* --- Geometry --------------------------------------------------------------------------------------------------- */
  protected string _geometry = Badge.StandardGeometricVariations.regular.ToString();

  [Parameter] public object geometry
  {
    get => this._geometry;
    set
    {

      if (value is Badge.StandardGeometricVariations standardGeometricVariation)
      {
        this._geometry = standardGeometricVariation.ToString();
        return;
      }
      
      
      // TODO CustomGeometricVariations https://github.com/TokugawaTakeshi/ExperimentalCSharpApplication1/issues/34#issuecomment-1500788874

      this._geometry = value.ToString();

    }
  }
  
  [Parameter]
  public Badge.GeometricModifiers[] geometricModifiers { get; set; } = Array.Empty<Badge.GeometricModifiers>(); 
  
  
  /* --- CSS classes ------------------------------------------------------------------------------------------------ */
  [Parameter]
  public string? spaceSeparatedAdditionalCSS_Classes { get; set; }
  
  // TODO カスタムを考慮 https://github.com/TokugawaTakeshi/ExperimentalCSharpApplication1/issues/34#issuecomment-1500788874
  private string rootElementModifierCSS_Classes => new List<string>().
      AddElementToEndIf(
        $"Badge--YDF__{ this._theme.ToLowerCamelCase() }Theme",
        _ => Enum.GetNames(typeof(Badge.StandardThemes)).Length > 1 && !this.areThemesExternal
      ).
      AddElementToEndIf(
        $"Badge--YDF__{ this._geometry.ToLowerCamelCase() }Geometry",
        _ => Enum.GetNames(typeof(Badge.StandardGeometricVariations)).Length > 1
      ).
      AddElementToEndIf(
        "Badge--YDF__PllShapeGeometricModifier", 
        _ => this.geometricModifiers.Contains(Badge.GeometricModifiers.pillShape)
      ).
      StringifyEachElementAndJoin("");
  
}