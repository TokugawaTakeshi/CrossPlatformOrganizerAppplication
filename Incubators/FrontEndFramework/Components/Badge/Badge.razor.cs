using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Components;
using Utils;


namespace FrontEndFramework.Components.Badge;


public partial class Badge : ComponentBase
{

  [Parameter] public string? key { get; set; }
  
  [Parameter] public required string value { get; set; }

  [Parameter] public bool mustForceSingleLine { get; set; } = false;
  
  
  /* --- Theme ------------------------------------------------------------------------------------------------------ */
  public enum StandardThemes
  {
    regular
  }
  
  protected static object? CustomThemes;

  public static void defineCustomThemes(Type CustomThemes) {

    if (!CustomThemes.IsEnum)
    {
      throw new System.ArgumentException("The custom themes must the enumeration.");
    }


    Badge.CustomThemes = CustomThemes;

  }

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

  internal static bool mustConsiderThemesAsExternal = false;

  public static void ConsiderThemesAsExternal()
  {
    Badge.mustConsiderThemesAsExternal = true;
  }
  
  [Parameter] public bool areThemesExternal { get; set; } = Badge.mustConsiderThemesAsExternal;
  
  
  /* --- Geometry --------------------------------------------------------------------------------------------------- */
  public enum StandardGeometricVariations
  {
    regular
  }

  protected static object? CustomGeometricVariations;
  
  public static void defineCustomGeometricVariations(Type CustomGeometricVariations)
  {

    if (!CustomGeometricVariations.IsEnum)
    {
      throw new System.ArgumentException("The custom geometric variations must the enumeration.");
    }


    Badge.CustomGeometricVariations = CustomGeometricVariations;

  }

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
  
  public enum GeometricModifiers
  {
    pillShape
  }

  [Parameter] public Badge.GeometricModifiers[] geometricModifiers { get; set; } = Array.Empty<Badge.GeometricModifiers>(); 
  
  
  /* --- Decorative variations -------------------------------------------------------------------------------------- */
  public enum StandardDecorativeVariations
  {
    veryCatchyBright,
    catchyBright,
    modestlyCatchyBright,
    neutralBright,
    modestlyCalmingBright,
    calmingBright,
    achromaticBright,
    veryCatchyPastel,
    catchyPastel,
    modestlyCatchyPastel,
    neutralPastel,
    modestlyCalmingPastel,
    calmingPastel,
    achromaticPastel
  }

  protected static Type? CustomDecorativeVariations;

  public static void defineNewDecorativeVariations(Type CustomDecorativeVariations) {
    
    if (!CustomDecorativeVariations.IsEnum)
    {
      throw new System.Exception("The custom decorative variations must the enumeration.");
    }
    
    
    Badge.CustomDecorativeVariations = CustomDecorativeVariations;
    
  }

  protected string _decoration;

  [Parameter] public required object decoration
  {
    get => _decoration;
    set
    {

      if (value is Badge.StandardDecorativeVariations standardDecorativeVariation)
      {
        this._decoration = standardDecorativeVariation.ToString();
        return;
      }


      string stringifiedValue = value.ToString() ?? "";
      
      if (
        Badge.CustomDecorativeVariations != null &&
        Enum.GetNames(CustomDecorativeVariations).Contains(stringifiedValue)
      ) {
        
        this._decoration= stringifiedValue;
        return;
        
      }

      
      throw new ArgumentException(
        "The decorative variation must be either one of \"StandardDecorativeVariations\" or custom one of declared " +
        "via \"defineNewDecorativeVariations\" while specified value is neither of."
      );
      
    }
  }
  
  public enum DecorativeModifiers
  {
    bordersDisguising
  }
  
  [Parameter] public Badge.DecorativeModifiers[] decorativeModifiers { get; set; } = Array.Empty<Badge.DecorativeModifiers>();


  
  /* --- CSS classes ------------------------------------------------------------------------------------------------ */
  [Parameter] public string? spaceSeparatedAdditionalCSS_Classes { get; set; }

  private string rootElementModifierCSS_Classes
  {
    get
    {

      // TODO カスタムを考慮 https://github.com/TokugawaTakeshi/ExperimentalCSharpApplication1/issues/34#issuecomment-1500788874
      return new List<string>().
          AddElementToEndIf("Badge--YDF__SingleLineMode", _ => this.mustForceSingleLine).
          AddElementToEndIf(
            $"Badge--YDF__{ this._theme.ToUpperCamelCase() }Theme",
            _ => Enum.GetNames(typeof(Badge.StandardThemes)).Length > 1 && !this.areThemesExternal
          ).
          AddElementToEndIf(
            $"Badge--YDF__{ this._geometry.ToUpperCamelCase() }Geometry",
            _ => Enum.GetNames(typeof(Badge.StandardGeometricVariations)).Length > 1
          ).
          AddElementToEndIf(
            "Badge--YDF__PllShapeGeometricModifier", 
            _ => this.geometricModifiers.Contains(Badge.GeometricModifiers.pillShape)
          ).
          AddElementToEndIf(
            $"Badge--YDF__{ this._decoration.ToUpperCamelCase() }Decoration",
            _ => Enum.GetNames(typeof(Badge.StandardDecorativeVariations)).Length > 1
          ).
          AddElementToEndIf(
            "Badge--YDF__BordersDisguisingDecorativeModifier", 
            _ => this.decorativeModifiers.Contains(Badge.DecorativeModifiers.bordersDisguising)
          ).
          StringifyEachElementAndJoin("");

    }
  }
  
  
  /* --- Other ------------------------------------------------------------------------------------------------------ */
  [Parameter] public RenderFragment? PrependedSVG_Icon { get; set; }
  
}