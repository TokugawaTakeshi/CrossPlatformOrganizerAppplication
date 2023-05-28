using Microsoft.AspNetCore.Components;
using FrontEndFramework.Components.Abstractions;
using FrontEndFramework.Exceptions;

using System.Diagnostics;
using System.Runtime.CompilerServices;
using Utils;


namespace FrontEndFramework.Components.Badge;


public partial class Badge : ComponentBase
{

  [Parameter] public string? key { get; set; }
  
  [Parameter] public required string value { get; set; }
  
  [Parameter] public RenderFragment? PrependedSVG_Icon { get; set; }
  
  
  /* ━━━ Theming ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public enum StandardThemes { regular }
  
  protected internal static Type? CustomThemes;

  public static void defineCustomThemes(Type CustomThemes)
  {
    YDF_ComponentsHelper.ValidateCustomTheme(CustomThemes);
    Badge.CustomThemes = CustomThemes;
  }

  protected string _theme = Badge.StandardThemes.regular.ToString();
  
  [Parameter] public object theme
  {
    get => this._theme;
    set => YDF_ComponentsHelper.AssignThemeIfItIsValid<Badge.StandardThemes>(
      value, Badge.CustomThemes, ref this._theme
    );
  }

  protected internal static bool mustConsiderThemesCSS_ClassesAsCommon = YDF_ComponentsHelper.areThemesCSS_ClassesCommon;

  public static void considerThemesAsCommon()
  {
    Badge.mustConsiderThemesCSS_ClassesAsCommon = true;
  }
  
  [Parameter] public bool areThemesCSS_ClassesCommon { get; set; } = 
      YDF_ComponentsHelper.areThemesCSS_ClassesCommon || Badge.mustConsiderThemesCSS_ClassesAsCommon;
  
  
  /* ─── Geometry ─────────────────────────────────────────────────────────────────────────────────────────────────── */
  public enum StandardGeometricVariations { regular }

  protected internal static Type? CustomGeometricVariations;
  
  public static void defineCustomGeometricVariations(Type CustomGeometricVariations)
  {
    YDF_ComponentsHelper.ValidateCustomGeometricVariation(CustomGeometricVariations);
    Badge.CustomGeometricVariations = CustomGeometricVariations;
  }

  protected string _geometry = Badge.StandardGeometricVariations.regular.ToString();

  [Parameter] public object geometry
  {
    get => this._geometry;
    set => YDF_ComponentsHelper.AssignGeometricVariationIfItIsValid<Badge.StandardGeometricVariations>(
    value, Badge.CustomGeometricVariations, ref this._geometry
    );
  }
  
  public enum GeometricModifiers
  {
    pillShape,
    singleLine
  }

  [Parameter] public Badge.GeometricModifiers[] geometricModifiers { get; set; } = Array.Empty<Badge.GeometricModifiers>(); 
  
  
  /* ─── Decorative variations ────────────────────────────────────────────────────────────────────────────────────── */
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

  protected internal static Type? CustomDecorativeVariations;

  public static void defineCustomDecorativeVariations(Type CustomDecorativeVariations) {
    YDF_ComponentsHelper.ValidateCustomDecorativeVariation(CustomDecorativeVariations);
    Badge.CustomDecorativeVariations = CustomDecorativeVariations;
  }

  protected string _decoration;

  [Parameter] public required object decoration
  {
    get => _decoration;
    set => YDF_ComponentsHelper.AssignDecorativeVariationIfItIsValid<Badge.StandardDecorativeVariations>(
      value, Badge.CustomDecorativeVariations, ref this._decoration
    );
  }
  
  public enum DecorativeModifiers { bordersDisguising }
  
  [Parameter] public Badge.DecorativeModifiers[] decorativeModifiers { get; set; } = Array.Empty<Badge.DecorativeModifiers>();


  /* ━━━ CSS classes ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  [Parameter] public string? spaceSeparatedAdditionalCSS_Classes { get; set; }

  private string rootElementModifierCSS_Classes => new List<string>().
    
      AddElementToEndIf(
        $"Badge--YDF__{ this._theme.ToUpperCamelCase() }Theme",
        YDF_ComponentsHelper.MustApplyThemeCSS_Class(
          typeof(Badge.StandardThemes), Badge.CustomThemes, this.areThemesCSS_ClassesCommon
        )
      ).
      
      AddElementToEndIf(
        $"Badge--YDF__{ this._geometry.ToUpperCamelCase() }Geometry",
        YDF_ComponentsHelper.MustApplyGeometricVariationModifierCSS_Class(
          typeof(Badge.StandardGeometricVariations), Badge.CustomGeometricVariations
        )
      ).
      AddElementToEndIf(
        "Badge--YDF__PllShapeGeometricModifier", 
        this.geometricModifiers.Contains(Badge.GeometricModifiers.pillShape)
      ).
      AddElementToEndIf(
        "Badge--YDF__SingleLineGeometricModifier", 
        this.geometricModifiers.Contains(Badge.GeometricModifiers.singleLine)
      ).
          
      AddElementToEndIf(
        $"Badge--YDF__{ this._decoration.ToUpperCamelCase() }Decoration",
        YDF_ComponentsHelper.MustApplyDecorativeVariationModifierCSS_Class(
          typeof(Badge.StandardDecorativeVariations), Badge.CustomDecorativeVariations
        )
      ).
      AddElementToEndIf(
        "Badge--YDF__BordersDisguisingDecorativeModifier", 
        this.decorativeModifiers.Contains(Badge.DecorativeModifiers.bordersDisguising)
      ).
          
      StringifyEachElementAndJoin("");
  
}