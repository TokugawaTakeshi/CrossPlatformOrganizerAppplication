using Microsoft.AspNetCore.Components;
using Utils;


namespace FrontEndFramework.Components.Controls.CompoundControlShell;


public partial class CompoundControlShell : ComponentBase
{

  /* === Blazor component parameters ================================================================================ */
  [Parameter]
  public RenderFragment ChildContent { get; set; }
 
  
  /* --- Textings --------------------------------------------------------------------------------------------------- */
  [Parameter]
  public string? label { get; set; }
  
  [Parameter]
  public string? guidance { get; set; }


  /* --- Inputting requiring ---------------------------------------------------------------------------------------- */
  [Parameter] 
  public bool required { get; set; } = false;
  
  [Parameter] 
  public bool mustDisplayAppropriateBadgeIfInputIsRequired { get; set; } = false;
  
  [Parameter] 
  public bool mustDisplayAppropriateBadgeIfInputIsOptional { get; set; } = false;
  
  [Parameter] 
  public bool mustAddInvisibleBadgeForHeightEqualizingWhenNoBadge { get; set; } = false;
  
  
  /* --- HTML IDs --------------------------------------------------------------------------------------------------- */
  [Parameter]
  public string? coreElementHTML_ID { get; set; }
  
  [Parameter]
  public string? labelElementHTML_ID { get; set; }
  
  
  /* --- CSS -------------------------------------------------------------------------------------------------------- */
  [Parameter]
  public string? spaceSeparatedAdditionalCSS_Classes { get; set; }
  
  [Parameter]
  public string mainSlotSpaceSeparatedAdditionalCSS_Classes { get; set; }
  
  /* --- Inputting validation --------------------------------------------------------------------------------------- */
  [Parameter] 
  public bool invalidInputHighlightingIfAnyValidationErrorsMessages { get; set; } = false;

  [Parameter] 
  public bool validValueHighlightingIfNoValidationErrorsMessages { get; set; } = false;

  [Parameter] 
  public string[] validationErrorsMessages { get; set; } = Array.Empty<string>(); 


  // < === TODO テーマ当たり始末方法が分かり次第着手 https://github.com/TokugawaTakeshi/ExperimentalCSharpApplication1/issues/34
  /* --- Themes ----------------------------------------------------------------------------------------------------- */
  public enum StandardThemes
  {
    regular
  }
  
  [Parameter] 
  public string theme { get; set; } = CompoundControlShell.StandardThemes.regular.ToString();
  
  protected static bool mustConsiderThemesAsExternal = false;
  
  public static void ConsiderThemesAsExternal()
  {
    CompoundControlShell.mustConsiderThemesAsExternal = true;
  }
  
  [Parameter]
  public bool areThemesExternal { get; set; }
  
  
  public enum StandardGeometricVariations
  {
    regular,
    small
  }
  
  [Parameter]
  public string geometry { get; set; } = CompoundControlShell.StandardGeometricVariations.regular.ToString();
  
  
  public enum StandardDecorativeVariations
  {
    regular
  }
  
  [Parameter]
  public string decoration { get; set; } = CompoundControlShell.StandardDecorativeVariations.regular.ToString();
  // > =================================================================================================================

  
  
  /* === Validation errors messages animating ======================================================================== */
  // TODO
  
  
  /* === Auxiliaries ================================================================================================= */
  /* --- CSS --------------------------------------------------------------------------------------------------------- */
  private string rootElementModifierCSS_Classes
  {
    get
    {
      
      return new List<string>().
          AddElementToEndIf(
            $"CompoundControlShell--YDF__{ this.theme.ToUpperCamelCase() }Theme",
            _ => Enum.GetNames(typeof(CompoundControlShell.StandardThemes)).Length > 1 && !this.areThemesExternal
          ).
          AddElementToEndIf(
            $"CompoundControlShell--YDF__{ this.geometry.ToUpperCamelCase() }Geometry",
            _ => Enum.GetNames(typeof(CompoundControlShell.StandardGeometricVariations)).Length > 1
          ).
          AddElementToEndIf(
            $"CompoundControlShell--YDF__{ this.decoration.ToUpperCamelCase() }Decoration",
            _ => Enum.GetNames(typeof(CompoundControlShell.StandardDecorativeVariations)).Length > 1
          ).
          AddElementToEndIf(
            $"CompoundControlShell--YDF__{ this.decoration.ToUpperCamelCase() }__InvalidValueState",
            _ => this.invalidInputHighlightingIfAnyValidationErrorsMessages && this.validationErrorsMessages.Length > 0
          ).
          AddElementToEndIf(
            $"CompoundControlShell--YDF__{ this.decoration.ToUpperCamelCase() }__ValidValueState",
            _ => this.validValueHighlightingIfNoValidationErrorsMessages && this.validationErrorsMessages.Length == 0
          ).
          StringifyEachElementAndJoin("");

    }
  }
  
  /* --- Displaying of elements ------------------------------------------------------------------------------------- */
  protected bool mustDisplayHeader =>
    this.label is not null ||
    this.mustDisplayRequiredInputBadge ||
    this.mustDisplayOptionalInputBadge ||
    this.mustAddInvisibleBadgeForHeightEqualizingWhenNoBadge;

  protected bool mustDisplayRequiredInputBadge => this.required && this.mustDisplayAppropriateBadgeIfInputIsRequired;
  protected bool mustDisplayOptionalInputBadge => !this.required && this.mustDisplayAppropriateBadgeIfInputIsOptional;


}