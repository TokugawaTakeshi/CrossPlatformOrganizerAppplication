using Microsoft.AspNetCore.Components;
using Utils;


namespace Client.Components.SharedReusable.Badge.LoadingPlaceholder;


public partial class BadgeLoadingPlaceholder : ComponentBase
{

  [Parameter]
  public string Geometry { get; set; }
  
  [Parameter]
  public Badge.GeometricModifiers[] geometricModifiers { get; set; }
  
  [Parameter]
  public string SpaceSeparatedAdditionalCSS_Classes { get; set; }
  
  
  private string rootElementModifierCSS_Classes
  {
    get
    {

      return new List<string>().
          AddElementToEndIf(
            $"Badge--YDF__${ Geometry.ToLowerCamel() }Geometry",
            _ => Enum.GetNames(typeof(Badge.StandardGeometricVariations)).Length > 1
          ).
          AddElementToEndIf(
            "Badge--YDF__PllShapeGeometricModifier", 
            _ => geometricModifiers.Contains(Badge.GeometricModifiers.pillShape)
          ).
          StringifyEachElementAndJoin(" ");

    }
  }
  
}