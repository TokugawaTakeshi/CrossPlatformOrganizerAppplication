using Microsoft.AspNetCore.Components;
using Utils;


namespace FrontEndFramework.Components.Controls.CompoundControlShell;


public partial class CompoundControlShell : ComponentBase
{
  
  /* === Textings =================================================================================================== */
  [Parameter] public string? label { get; set; }
  
  [Parameter] public string? guidance { get; set; }


  /* === Inputting requiring ======================================================================================== */
  [Parameter] public bool required { get; set; } = false;
  
  [Parameter] public bool mustDisplayAppropriateBadgeIfInputIsRequired { get; set; } = false;
  
  [Parameter] public bool mustDisplayAppropriateBadgeIfInputIsOptional { get; set; } = false;
  
  [Parameter] public bool mustAddInvisibleBadgeForHeightEqualizingWhenNoBadge { get; set; } = false;
  
  
  /* === HTML IDs =================================================================================================== */
  [Parameter] public string? coreElementHTML_ID { get; set; }
  
  [Parameter] public string? labelElementHTML_ID { get; set; }
  

  /* === Inputting validation ======================================================================================= */
  [Parameter] public bool invalidInputHighlightingIfAnyValidationErrorsMessages { get; set; } = false;

  [Parameter] public bool validValueHighlightingIfNoValidationErrorsMessages { get; set; } = false;

  [Parameter] public string[] validationErrorsMessages { get; set; } = Array.Empty<string>(); 


  /* === Theme ====================================================================================================== */
  public enum StandardThemes { regular }

  protected static object? CustomThemes;
  
  public static void defineCustomThemes(Type CustomThemes) {

    if (!CustomThemes.IsEnum)
    {
      throw new System.ArgumentException("The custom themes must the enumeration.");
    }


    CompoundControlShell.CustomThemes = CustomThemes;

  }
  
  protected string _theme = CompoundControlShell.StandardThemes.regular.ToString();
  
  [Parameter] public object theme
  {
    get => this._theme;
    set
    {

      if (value is CompoundControlShell.StandardThemes standardTheme)
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
    CompoundControlShell.mustConsiderThemesAsExternal = true;
  }
  
  [Parameter] public bool areThemesExternal { get; set; } = CompoundControlShell.mustConsiderThemesAsExternal;
  
  
  /* === Geometry =================================================================================================== */
  public enum StandardGeometricVariations
  {
    regular,
    small
  }

  protected static object? CustomGeometricVariations;
  
  public static void defineCustomGeometricVariations(Type CustomGeometricVariations)
  {

    if (!CustomGeometricVariations.IsEnum)
    {
      throw new System.ArgumentException("The custom geometric variations must the enumeration.");
    }


    CompoundControlShell.CustomGeometricVariations = CustomGeometricVariations;

  }
  
  protected string _geometry = CompoundControlShell.StandardGeometricVariations.regular.ToString();
  
  [Parameter] public object geometry
  {
    get => this._geometry;
    set
    {

      if (value is CompoundControlShell.StandardGeometricVariations standardGeometricVariation)
      {
        this._geometry = standardGeometricVariation.ToString();
        return;
      }
      
      
      // TODO CustomGeometricVariations https://github.com/TokugawaTakeshi/ExperimentalCSharpApplication1/issues/34#issuecomment-1500788874

      this._geometry = value.ToString();

    }
  }
  
  
  /* === Decoration ================================================================================================= */
  public enum StandardDecorativeVariations { regular }

  protected static object? CustomDecorativeVariations;
  
  public static void defineNewDecorativeVariations(Type CustomDecorativeVariations) {
    
    if (!CustomDecorativeVariations.IsEnum)
    {
      throw new System.Exception("The custom decorative variations must the enumeration.");
    }
      
        
    CompoundControlShell.CustomDecorativeVariations = CustomDecorativeVariations;
      
  }  
  
  protected string _decoration = CompoundControlShell.StandardDecorativeVariations.regular.ToString();

  [Parameter] public required object decoration
  {
    get => _decoration;
    set
    {

      if (value is CompoundControlShell.StandardDecorativeVariations standardDecorativeVariation)
      {
        this._decoration = standardDecorativeVariation.ToString();
        return;
      }

      
      // TODO CustomDecorativeVariations確認 https://github.com/TokugawaTakeshi/ExperimentalCSharpApplication1/issues/34#issuecomment-1500788874
      
      this._decoration = value.ToString();

    }
  }
  
  
  /* === CSS ======================================================================================================== */
  [Parameter] public string? spaceSeparatedAdditionalCSS_Classes { get; set; }
  
  [Parameter] public string mainSlotSpaceSeparatedAdditionalCSS_Classes { get; set; }
  
  private string rootElementModifierCSS_Classes => new List<string>().
      AddElementToEndIf(
        $"CompoundControlShell--YDF__{ this._theme.ToUpperCamelCase() }Theme",
        Enum.GetNames(typeof(CompoundControlShell.StandardThemes)).Length > 1 && !this.areThemesExternal
      ).
      AddElementToEndIf(
        $"CompoundControlShell--YDF__{ this._geometry.ToUpperCamelCase() }Geometry",
        Enum.GetNames(typeof(CompoundControlShell.StandardGeometricVariations)).Length > 1
      ).
      AddElementToEndIf(
        $"CompoundControlShell--YDF__{ this._decoration.ToUpperCamelCase() }Decoration",
        Enum.GetNames(typeof(CompoundControlShell.StandardDecorativeVariations)).Length > 1
      ).
      AddElementToEndIf(
        $"CompoundControlShell--YDF__{ this._decoration.ToUpperCamelCase() }__InvalidValueState",
        this.invalidInputHighlightingIfAnyValidationErrorsMessages && this.validationErrorsMessages.Length > 0
      ).
      AddElementToEndIf(
        $"CompoundControlShell--YDF__{ this._decoration.ToUpperCamelCase() }__ValidValueState",
        this.validValueHighlightingIfNoValidationErrorsMessages && this.validationErrorsMessages.Length == 0
      ).
      StringifyEachElementAndJoin(" ");

  
  /* === Localization =============================================================================================== */
  // TODO
  
  
  /* === Validation errors messages animating ======================================================================= */
  // TODO
  
  
  /* === Displaying of elements ===================================================================================== */
  protected bool mustDisplayHeader =>
    this.label is not null ||
    this.mustDisplayRequiredInputBadge ||
    this.mustDisplayOptionalInputBadge ||
    this.mustAddInvisibleBadgeForHeightEqualizingWhenNoBadge;

  protected bool mustDisplayRequiredInputBadge => this.required && this.mustDisplayAppropriateBadgeIfInputIsRequired;
  protected bool mustDisplayOptionalInputBadge => !this.required && this.mustDisplayAppropriateBadgeIfInputIsOptional;

  
  /* === Children content =========================================================================================== */
  [Parameter]
  public RenderFragment ChildContent { get; set; }

}