using Microsoft.AspNetCore.Components;


namespace FrontEndFramework.Components.Controls;


public abstract class InputtableControl : ComponentBase
{
    
  /* === Blazor component parameters ================================================================================ */
  [Parameter] public string? label { get; set; }
  
  [Parameter] public string? accessibilityGuidance { get; set; }
  
  [Parameter] public string? externalLabelHTML_ID { get; set; }
  
  [Parameter] public string? guidance { get; set; }
  
  
  [Parameter] public bool required { get; set; } = false;

  [Parameter] public bool mustDisplayAppropriateBadgeIfInputIsRequired { get; set; } = false;

  [Parameter] public bool mustDisplayAppropriateBadgeIfInputIsOptional { get; set; } = false;
 
  
  [Parameter] public string? coreElementHTML_ID { get; set; }
  
  
  [Parameter] public bool disabled { get; set; } = false;
  
  
  /* === State ====================================================================================================== */
  protected bool invalidInputHighlightingIfAnyValidationErrorsMessages = false;
  protected bool validInputHighlightingIfAnyErrorsMessages = false;
  
  
  /* === Methods ==================================================================================================== */
  public InputtableControl HighlightInvalidInput()
  {
    this.invalidInputHighlightingIfAnyValidationErrorsMessages = true;
    return this;
  }
  
}