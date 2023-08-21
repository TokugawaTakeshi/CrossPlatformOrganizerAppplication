using Utils;

namespace FrontEndFramework.Components.Abstractions;


public interface ISupportsFlexibleCustomCSS_ClassesSpecifyingForRootElement : ISupportsCustomCSS_ClassesForRootElement
{
  
  public string? modifierCSS_Class { get; set; }
  
  public string? spaceSeparatedModifierCSS_Classes { get; set; }
  
  public string[]? modifierCSS_Classes { get; set; }

  protected string rootElementSpaceSeparatedModifierCSS_Classes => new List<string>().
        
      AddElementToEndIf(this.modifierCSS_Class!,  !String.IsNullOrEmpty(this.modifierCSS_Class)).
        
      AddElementsToEnd(this.spaceSeparatedModifierCSS_Classes?.Split(" ") ?? Array.Empty<string>()).
        
      AddElementsToEnd(this.modifierCSS_Classes ?? Array.Empty<string>()).
        
      StringifyEachElementAndJoin(" ");
  
}