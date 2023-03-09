using Microsoft.AspNetCore.Components;
using Utils;

namespace Client.Components.SharedReusable.Controls.CompoundControlShell;


public partial class CompoundControlShell : ComponentBase
{

  [Parameter]
  public string SpaceSeparatedAdditionalCSS_Classes { get; set; }
  
  [Parameter]
  public RenderFragment ChildContent { get; set; }
 
  [Parameter]
  public string? Label { get; set; }
  
  [Parameter]
  public string? Guidance { get; set; }


  [Parameter] 
  public bool Required { get; set; }
  
  [Parameter] 
  public bool DisplayAppropriateBadgeIfInputIsRequired { get; set; }
  
  [Parameter] 
  public bool DisplayAppropriateBadgeIfInputIsOptional { get; set; }
  
  
  [Parameter]
  public string? CoreElementHTML_ID { get; set; }
  
  [Parameter]
  public string? LabelElementHTML_ID { get; set; }
  
  
  [Parameter]
  public string MainSlotSpaceSeparatedAdditionalCSS_Classes { get; set; }
  
  
  [Parameter]
  public bool MustActivateAppropriateHighlightIfAnyErrorsMessages { get; set; }

  [Parameter]
  public IEnumerable<string> errorsMessages { get; set; } = Array.Empty<string>();


  public enum StandardThemes
  {
    regular
  }
  
  [Parameter]
  public string Theme { get; set; }

  [Parameter]
  public bool AreThemesExternal { get; set; }
  
  
  public enum StandardGeometricVariations
  {
    regular
  }
  
  [Parameter]
  public string Geometry { get; set; }
  
  
  public enum StandardDecorativeVariations
  {
    notice,
    error,
    warning,
    success,
    guidance,
    question
  }
  
  [Parameter]
  public string Decoration { get; set; }

  
  private string rootElementModifierCSS_Classes
  {
    get
    {
      
      return new List<string>().
          AddElementToEndIf(
            $"AttentionBox--YDF__${ Theme.ToUpperCamelCase() }Theme",
            _ => Enum.GetNames(typeof(StandardThemes)).Length > 1 && !AreThemesExternal
          ).
          AddElementToEndIf(
            $"AttentionBox--YDF__${ Geometry.ToUpperCamelCase() }Geometry",
            _ => Enum.GetNames(typeof(StandardGeometricVariations)).Length > 1
          ).
          AddElementToEndIf(
            $"AttentionBox--YDF__${ Decoration.ToUpperCamelCase() }Decoration",
            _ => Enum.GetNames(typeof(StandardDecorativeVariations)).Length > 1
          ).
          StringifyEachElementAndJoin("");

    }
  }

}