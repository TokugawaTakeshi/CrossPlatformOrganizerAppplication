using System.Diagnostics;
using Microsoft.AspNetCore.Components;
using Utils;


namespace FrontEndFramework.Components.AttentionBox;


public partial class AttentionBox : ComponentBase
{
  
  /* --- Theme ------------------------------------------------------------------------------------------------------ */
  public enum StandardThemes { regular }
  
  protected static object? CustomThemes;
  
  public static void defineCustomThemes(Type CustomThemes) {

    if (!CustomThemes.IsEnum)
    {
      throw new System.ArgumentException("The custom themes must the enumeration.");
    }


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
      
      
      // TODO CustomThemes確認 https://github.com/TokugawaTakeshi/ExperimentalCSharpApplication1/issues/34#issuecomment-1500788874
      
      this._theme = value.ToString();

    }
  }
  
  internal static bool mustConsiderThemesAsExternal = false;

  public static void ConsiderThemesAsExternal()
  {
    AttentionBox.mustConsiderThemesAsExternal = true;
  }
  
  [Parameter] public bool areThemesExternal { get; set; } = AttentionBox.mustConsiderThemesAsExternal;

  
  /* --- Geometry --------------------------------------------------------------------------------------------------- */
  public enum StandardGeometricVariations { regular }

  protected static object? CustomGeometricVariations;

  public static void defineCustomGeometricVariations(Type CustomGeometricVariations)
  {

    if (!CustomGeometricVariations.IsEnum)
    {
      throw new System.ArgumentException("The custom geometric variations must the enumeration.");
    }


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
      
      
      // TODO CustomGeometricVariations https://github.com/TokugawaTakeshi/ExperimentalCSharpApplication1/issues/34#issuecomment-1500788874

      this._geometry = value.ToString();

    }
  }

  
  /* --- Decorative variations -------------------------------------------------------------------------------------- */
  public enum StandardDecorativeVariations
  {
    notice,
    error,
    warning,
    success,
    guidance,
    question
  }

  protected static object? CustomDecorativeVariations;
  
  public static void defineNewDecorativeVariations(Type CustomDecorativeVariations) {
    
    if (!CustomDecorativeVariations.IsEnum)
    {
      throw new System.Exception("The custom decorative variations must the enumeration.");
    }
      
        
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

      
      // TODO CustomDecorativeVariations確認 https://github.com/TokugawaTakeshi/ExperimentalCSharpApplication1/issues/34#issuecomment-1500788874
      
      this._decoration = value.ToString();

    }
  }
  
  
  /* --- CSS classes ------------------------------------------------------------------------------------------------ */
  [Parameter] public string? spaceSeparatedAdditionalCSS_Classes { get; set; }

  private string rootElementModifierCSS_Classes => new List<string>().
      AddElementToEndIf(
        $"AttentionBox--YDF__{ this._theme.ToUpperCamelCase() }Theme",
        _ => Enum.GetNames(typeof(StandardThemes)).Length > 1 && !this.areThemesExternal
      ).
      AddElementToEndIf(
        $"AttentionBox--YDF__{ this._geometry.ToUpperCamelCase() }Geometry",
        _ => Enum.GetNames(typeof(StandardGeometricVariations)).Length > 1
      ).
      AddElementToEndIf(
        $"AttentionBox--YDF__{ this._decoration.ToUpperCamelCase() }Decoration",
        _ => Enum.GetNames(typeof(StandardDecorativeVariations)).Length > 1
      ).
      StringifyEachElementAndJoin("");
  
  
  /* --- Prepended SVG Icon ----------------------------------------------------------------------------------------- */
  [Parameter] public bool hasPrependedSVG_Icon { get; set; } = false;
  
  
  /* --- Dismissing button ------------------------------------------------------------------------------------------ */
  [Parameter] public bool hasDismissingButton { get; set; } = false;
  
  private void onClickDismissingButton()
  {
    
  }
  
  
  /* --- Other ------------------------------------------------------------------------------------------------------ */
  [Parameter] public RenderFragment ChildContent { get; set; }
  
}
