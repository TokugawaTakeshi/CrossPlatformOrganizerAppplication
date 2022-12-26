using Microsoft.AspNetCore.Components;
using Utils;


namespace Client.Components.SharedReusable.Badge;


public partial class Badge : ComponentBase
{

  [Parameter]
  public string Key { get; set; }
  
  [Parameter]
  public string Value { get; set; }
  
  [Parameter]
  public bool ForbidMultiLine { get; set; }
  
  [Parameter]
  public string Theme { get; set; }

  [Parameter]
  public bool AreThemesExternal { get; set; }
  
  [Parameter]
  public string Geometry { get; set; }
  
  [Parameter]
  public GeometricModifiers[] geometricModifiers { get; set; }
  
  [Parameter]
  public string Decoration { get; set; }
  
  [Parameter]
  public DecorativeModifiers[] decorativeModifiers { get; set; }
  
  [Parameter]
  public string SpaceSeparatedAdditionalCSS_Classes { get; set; }


  public enum StandardThemes
  {
    regular
  }
  
  public enum StandardGeometricVariations
  {
    regular
  }
  
  public enum GeometricModifiers
  {
    pillShape
  }

  public enum StandardDecorativeVariations
  {
    veryCatchyBright,
    catchyBright,
    modestlyCatchyBright,
    neutralBright,
    modestlyCalmingBright,
    calmingBright,
    achromaticBright,
    veryCatchyPastel,
    catchyPastel,
    modestlyCatchyPastel,
    neutralPastel,
    modestlyCalmingPastel,
    calmingPastel,
    achromaticPastel
  }
  
  public enum DecorativeModifiers
  {
    bordersDisguising
  }

  
  private string rootElementModifierCSS_Classes
  {
    get
    {

      return new List<string>().
            AddElementToEndIf("Badge--YDF__SingleLineMode", _ => ForbidMultiLine).
            AddElementToEndIf(
              $"Badge--YDF__${ Theme.ToLowerCamel() }Theme",
              _ => Enum.GetNames(typeof(StandardThemes)).Length > 1 && !AreThemesExternal
            ).
            AddElementToEndIf(
              $"Badge--YDF__${ Geometry.ToLowerCamel() }Geometry",
              _ => Enum.GetNames(typeof(StandardGeometricVariations)).Length > 1
            ).
            AddElementToEndIf(
              "Badge--YDF__PllShapeGeometricModifier", 
              _ => geometricModifiers.Contains(GeometricModifiers.pillShape)
            ).
            AddElementToEndIf(
              $"AttentionBox--YDF__${ Decoration.ToLowerCamel() }Decoration",
              _ => Enum.GetNames(typeof(StandardDecorativeVariations)).Length > 1
            ).
            AddElementToEndIf(
              "Badge--YDF__BordersDisguisingDecorativeModifier", 
              _ => decorativeModifiers.Contains(DecorativeModifiers.bordersDisguising)
            ).
            StringifyEachElementAndJoin("");

    }
  }
  
}