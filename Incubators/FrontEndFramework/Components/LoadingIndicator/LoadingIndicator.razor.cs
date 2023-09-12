using FrontEndFramework.Components.Abstractions;
using YamatoDaiwaCS_Extensions;
using Utils;


namespace FrontEndFramework.Components.LoadingIndicator;


public partial class LoadingIndicator : Microsoft.AspNetCore.Components.ComponentBase 
{

  public enum Types
  {
    variableWidthArcSpinner,
    twoConstantWidthArcsSpinner 
  }
  
  [Microsoft.AspNetCore.Components.Parameter]
  public required LoadingIndicator.Types type { get; set; }
  
  
  /* ━━━ Theming ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public enum StandardThemes { regular }
  
  protected internal static Type? CustomThemes;

  public static void defineCustomThemes(Type CustomThemes)
  {
    YDF_ComponentsHelper.ValidateCustomTheme(CustomThemes);
    LoadingIndicator.CustomThemes = CustomThemes;
  }

  protected string _theme = LoadingIndicator.StandardThemes.regular.ToString();
  
  [Microsoft.AspNetCore.Components.Parameter]
  public object theme
  {
    get => this._theme;
    set => YDF_ComponentsHelper.AssignThemeIfItIsValid<LoadingIndicator.StandardThemes>(
      value, LoadingIndicator.CustomThemes, ref this._theme
    );
  }

  protected internal static bool mustConsiderThemesCSS_ClassesAsCommon = YDF_ComponentsHelper.areThemesCSS_ClassesCommon;

  public static void considerThemesAsCommon()
  {
    LoadingIndicator.mustConsiderThemesCSS_ClassesAsCommon = true;
  }
  
  [Microsoft.AspNetCore.Components.Parameter]
  public bool areThemesCSS_ClassesCommon { get; set; } = 
      YDF_ComponentsHelper.areThemesCSS_ClassesCommon || LoadingIndicator.mustConsiderThemesCSS_ClassesAsCommon;
  
  
  /* ─── Geometry ─────────────────────────────────────────────────────────────────────────────────────────────────── */
  public enum StandardGeometricVariations { regular, small }

  protected internal static Type? CustomGeometricVariations;
  
  public static void defineCustomGeometricVariations(Type CustomGeometricVariations)
  {
    YDF_ComponentsHelper.ValidateCustomGeometricVariation(CustomGeometricVariations);
    LoadingIndicator.CustomGeometricVariations = CustomGeometricVariations;
  }

  protected string _geometry = LoadingIndicator.StandardGeometricVariations.regular.ToString();

  [Microsoft.AspNetCore.Components.Parameter]
  public object geometry
  {
    get => this._geometry;
    set => YDF_ComponentsHelper.AssignGeometricVariationIfItIsValid<LoadingIndicator.StandardGeometricVariations>(
      value, LoadingIndicator.CustomGeometricVariations, ref this._geometry
    );
  }

  /* ─── Decoration ───────────────────────────────────────────────────────────────────────────────────────────────── */
  public enum StandardDecorativeVariations { regular }

  protected internal static Type? CustomDecorativeVariations;

  public static void defineCustomDecorativeVariations(Type CustomDecorativeVariations) {
    YDF_ComponentsHelper.ValidateCustomDecorativeVariation(CustomDecorativeVariations);
    LoadingIndicator.CustomDecorativeVariations = CustomDecorativeVariations;
  }

  protected string _decoration = LoadingIndicator.StandardDecorativeVariations.regular.ToString();

  [Microsoft.AspNetCore.Components.Parameter]
  public required object decoration
  {
    get => _decoration;
    set => YDF_ComponentsHelper.AssignDecorativeVariationIfItIsValid<LoadingIndicator.StandardDecorativeVariations>(
      value, LoadingIndicator.CustomDecorativeVariations, ref this._decoration
    );
  }
  
  public enum DecorativeModifiers { bordersDisguising }
  
  [Microsoft.AspNetCore.Components.Parameter]
  public LoadingIndicator.DecorativeModifiers[] decorativeModifiers { get; set; } = Array.Empty<LoadingIndicator.DecorativeModifiers>();


  /* ━━━ CSS classes ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  [Microsoft.AspNetCore.Components.Parameter]
  public string? rootElementModifierCSS_Class { get; set; }

  private string rootElementModifierCSS_Classes => new List<string>().
    
      AddElementToEndIf(
        $"LoadingIndicator--YDF__{ this._theme.ToUpperCamelCase() }Theme",
        YDF_ComponentsHelper.MustApplyThemeCSS_Class(
          typeof(LoadingIndicator.StandardThemes), LoadingIndicator.CustomThemes, this.areThemesCSS_ClassesCommon
        )
      ).
      
      AddElementToEndIf(
        $"LoadingIndicator--YDF__{ this._geometry.ToUpperCamelCase() }Geometry",
        YDF_ComponentsHelper.MustApplyGeometricVariationModifierCSS_Class(
          typeof(LoadingIndicator.StandardGeometricVariations), LoadingIndicator.CustomGeometricVariations
        )
      ).
          
      AddElementToEndIf(
        $"LoadingIndicator--YDF__{ this._decoration.ToUpperCamelCase() }Decoration",
        YDF_ComponentsHelper.MustApplyDecorativeVariationModifierCSS_Class(
          typeof(LoadingIndicator.StandardDecorativeVariations), LoadingIndicator.CustomDecorativeVariations
        )
      ).

      AddElementToEndIf(
        this.rootElementModifierCSS_Class ?? "", String.IsNullOrEmpty(this.rootElementModifierCSS_Class)
      ).
      
      StringifyEachElementAndJoin(" ");

}
