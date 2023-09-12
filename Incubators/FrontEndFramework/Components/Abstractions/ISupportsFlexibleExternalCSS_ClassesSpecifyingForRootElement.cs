using YamatoDaiwaCS_Extensions;


namespace FrontEndFramework.Components.Abstractions;


public interface ISupportsFlexibleExternalCSS_ClassesSpecifyingForRootElement : ISupportsExternalCSS_ClassesForRootElement
{
  
  public string? rootElementModifierCSS_Class { get; set; }

  public string[]? rootElementModifierCSS_Classes { get; set; }
  
  public string? rootElementSpaceSeparatedModifierCSS_Classes { get; set; }

  public new string rootElementSpaceSeparatedExternalCSS_Classes => new List<string>().
        
      AddElementToEndIf(this.rootElementModifierCSS_Class!,  !String.IsNullOrEmpty(this.rootElementModifierCSS_Class)).
        
      AddElementsToEnd(this.rootElementSpaceSeparatedModifierCSS_Classes?.Split(" ") ?? Array.Empty<string>()).
        
      AddElementsToEnd(this.rootElementModifierCSS_Classes ?? Array.Empty<string>()).
        
      StringifyEachElementAndJoin(" ");
  
}