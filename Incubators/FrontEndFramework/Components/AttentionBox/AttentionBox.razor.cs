using System.Diagnostics;
using FrontEndFramework.Components.Abstractions;
using FrontEndFramework.Exceptions;
using Microsoft.AspNetCore.Components;
using Utils;


namespace FrontEndFramework.Components.AttentionBox;


public partial class AttentionBox : ComponentBase
{
  
  [Parameter] public string? title { get; set; }
  
  /* ─── Theme ────────────────────────────────────────────────────────────────────────────────────────────────────── */
  public enum StandardThemes { regular }
  
  protected internal static Type? CustomThemes;
  
  public static void defineCustomThemes(Type CustomThemes) {
    YDF_ComponentsHelper.ValidateCustomTheme(CustomThemes);
    AttentionBox.CustomThemes = CustomThemes;
  }
  
  protected string _theme = AttentionBox.StandardThemes.regular.ToString();
  
  [Parameter] public object theme
  {
    get => this._theme;
    set
    {

      if (value is AttentionBox.StandardThemes standardTheme)
      {
        this._theme = standardTheme.ToString();
        return;
      }
      
      
      string stringifiedThemeValue = value.ToString() ?? "";

      if (
        AttentionBox.CustomThemes is not null &&
        AttentionBox.CustomThemes.IsEnum &&
        Enum.GetNames(AttentionBox.CustomThemes).Contains(stringifiedThemeValue)
      )
      {
        this._theme = stringifiedThemeValue;
        return;
      }


      throw new InvalidThemeParameterForYDF_ComponentException();

    }
  }
  
  internal static bool mustConsiderThemesCSS_ClassesCommon = false;

  public static void considerThemesAsCommon()
  {
    AttentionBox.mustConsiderThemesCSS_ClassesCommon = true;
  }
  
  [Parameter] public bool areThemesCSS_ClassesCommon { get; set; } = 
      YDF_ComponentsHelper.areThemesCSS_ClassesCommon || AttentionBox.mustConsiderThemesCSS_ClassesCommon;

  
  /* ─── Geometry ─────────────────────────────────────────────────────────────────────────────────────────────────── */
  public enum StandardGeometricVariations
  {
    regular,
    stickyNoteLike
  }

  protected internal static Type? CustomGeometricVariations;

  public static void defineCustomGeometricVariations(Type CustomGeometricVariations)
  {
    YDF_ComponentsHelper.ValidateCustomGeometricVariation(CustomGeometricVariations);
    AttentionBox.CustomGeometricVariations = CustomGeometricVariations;

  }
  
  protected string _geometry = AttentionBox.StandardGeometricVariations.regular.ToString();

  [Parameter] public object geometry
  {
    get => this._geometry;
    set
    {

      if (value is AttentionBox.StandardGeometricVariations standardGeometricVariation)
      {
        this._geometry = standardGeometricVariation.ToString();
        return;
      }
      
      
      string stringifiedGeometricVariation = value.ToString() ?? "";

      if (
        AttentionBox.CustomGeometricVariations is not null &&
        AttentionBox.CustomGeometricVariations.IsEnum &&
        Enum.GetNames(AttentionBox.CustomGeometricVariations).Contains(stringifiedGeometricVariation)
      )
      {
        this._geometry = stringifiedGeometricVariation;
        return;
      }
      
      throw new InvalidGeometricVariationParameterForYDF_ComponentException();

    }
  }

  
  /* ─── Decorative variations ────────────────────────────────────────────────────────────────────────────────────── */
  public enum StandardDecorativeVariations
  {
    notice,
    error,
    warning,
    success,
    guidance,
    question
  }

  protected internal static Type? CustomDecorativeVariations;
  
  public static void defineNewDecorativeVariations(Type CustomDecorativeVariations) {
    YDF_ComponentsHelper.ValidateCustomDecorativeVariation(CustomDecorativeVariations);
    AttentionBox.CustomDecorativeVariations = CustomDecorativeVariations;
  }  

  protected string _decoration;

  [Parameter] public required object decoration
  {
    get => _decoration;
    set
    {

      if (value is AttentionBox.StandardDecorativeVariations standardDecorativeVariation)
      {
        this._decoration = standardDecorativeVariation.ToString();
        return;
      }

      
      string stringifiedDecorativeVariation = value.ToString() ?? "";

      if (
        AttentionBox.CustomDecorativeVariations is not null &&
        AttentionBox.CustomDecorativeVariations.IsEnum &&
        Enum.GetNames(CustomDecorativeVariations).Contains(stringifiedDecorativeVariation)
      ) {
        this._decoration= stringifiedDecorativeVariation;
        return;
      }


      throw new InvalidDecorativeVariationParameterForYDF_ComponentException();

    }
  }
  
  
  /* ─── CSS classes ──────────────────────────────────────────────────────────────────────────────────────────────── */
  [Parameter] public string? spaceSeparatedAdditionalCSS_Classes { get; set; }

  private string rootElementModifierCSS_Classes => new List<string>().
      // TODO カスタム奴を考慮　https://github.com/TokugawaTakeshi/ExperimentalCSharpApplication1/issues/50
      AddElementToEndIf(
        $"AttentionBox--YDF__{ this._theme.ToUpperCamelCase() }Theme",
        _ => Enum.GetNames(typeof(StandardThemes)).Length > 1 && !this.areThemesCSS_ClassesCommon
      ).
      // TODO カスタム奴を考慮　https://github.com/TokugawaTakeshi/ExperimentalCSharpApplication1/issues/50
      AddElementToEndIf(
        $"AttentionBox--YDF__{ this._geometry.ToUpperCamelCase() }Geometry",
        _ => Enum.GetNames(typeof(StandardGeometricVariations)).Length > 1
      ).
      // TODO カスタム奴を考慮　https://github.com/TokugawaTakeshi/ExperimentalCSharpApplication1/issues/50
      AddElementToEndIf(
        $"AttentionBox--YDF__{ this._decoration.ToUpperCamelCase() }Decoration",
        _ => Enum.GetNames(typeof(StandardDecorativeVariations)).Length > 1
      ).
      StringifyEachElementAndJoin(" ");
  
  
  /* --- Prepended SVG Icon ----------------------------------------------------------------------------------------- */
  [Parameter] public bool hasPrependedSVG_Icon { get; set; } = false;
  
  
  /* --- Dismissing button ------------------------------------------------------------------------------------------ */
  [Parameter] public bool hasDismissingButton { get; set; } = false;
  
  private void onClickDismissingButton()
  {
    // TODO 【次のプールリクエスト】 
  }
  
  
  /* --- Other ------------------------------------------------------------------------------------------------------ */
  [Parameter] public RenderFragment ChildContent { get; set; }
  
  
  /* ━━━ Routines ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  protected static uint counterForID_Generating = 0;

  protected static string generateBasicID()
  {
    AttentionBox.counterForID_Generating++;
    return $"ATTENTION_BOX--YDF-${ AttentionBox.counterForID_Generating }";
  }

  protected readonly string BASIC_ID = AttentionBox.generateBasicID();

  protected string TITLE_HTML_ID => $"{ this.BASIC_ID }-TITLE";

}
