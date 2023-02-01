using Microsoft.AspNetCore.Components;
using UtilsIncubator;


namespace FrontEndFramework.Components.Badge;


public partial class Badge : ComponentBase
{

  [Parameter]
  public string? key { get; set; }
  
  [Parameter]
  public required string value { get; set; }
  
  [Parameter]
  public bool mustForceSingleLine { get; set; }
  
  
  public enum StandardThemes
  {
    regular
  }

  [Parameter] 
  public string theme { get; set; } = Badge.StandardThemes.regular.ToString(); // TODO ① 正しく文字列と始末する

  internal static bool mustConsiderThemesAsExternal = false;

  public void ConsiderThemesAsExternal()
  {
    Badge.mustConsiderThemesAsExternal = true;
  }

  [Parameter]
  public bool areThemesExternal { get; set; } = Badge.mustConsiderThemesAsExternal;
  
  
  public enum StandardGeometricVariations
  {
    regular
  }

  [Parameter]
  public string geometry { get; set; } = Badge.StandardThemes.regular.ToString(); // TODO ① 正しく文字列と始末する
  
  public enum GeometricModifiers
  {
    pillShape
  }

  [Parameter]
  public Badge.GeometricModifiers[] geometricModifiers { get; set; } = Array.Empty<Badge.GeometricModifiers>(); 
  
  
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

  private string[] customDecorativeVariations = Array.Empty<string>();

  public void defineNewDecorativeVariations(string[] newDecorativeVariations)
  {
    customDecorativeVariations = newDecorativeVariations;
  } 

  [Parameter]
  public required string decoration { get; set; }
  
  // [Parameter]
  // public required string decoration
  // {
  //   get => _decoration;
  //   set
  //   {
  //
  //     if (
  //       !value is StandardDecorativeVariations &&
  //       !value is CustomDecorativeVariations
  //     )
  //     {
  //       throw new Exception($"修飾的変形{value}は不明");
  //     }
  //
  //
  //     this._theme = value;
  //
  //   }
  // }
  
  public enum DecorativeModifiers
  {
    bordersDisguising
  }
  
  [Parameter]
  public Badge.DecorativeModifiers[] decorativeModifiers { get; set; } = Array.Empty<Badge.DecorativeModifiers>();


  [Parameter]
  public string? spaceSeparatedAdditionalCSS_Classes { get; set; }


  private string rootElementModifierCSS_Classes
  {
    get
    {

      return new List<string>().
          AddElementToEndIf("Badge--YDF__SingleLineMode", _ => this.mustForceSingleLine).
          AddElementToEndIf(
            $"Badge--YDF__${ this.theme.ToLowerCamelCase() }Theme",
            _ => Enum.GetNames(typeof(Badge.StandardThemes)).Length > 1 && !this.areThemesExternal
          ).
          AddElementToEndIf(
            $"Badge--YDF__${ this.geometry.ToLowerCamelCase() }Geometry",
            _ => Enum.GetNames(typeof(Badge.StandardGeometricVariations)).Length > 1
          ).
          AddElementToEndIf(
            "Badge--YDF__PllShapeGeometricModifier", 
            _ => this.geometricModifiers.Contains(Badge.GeometricModifiers.pillShape)
          ).
          AddElementToEndIf(
            $"AttentionBox--YDF__${ this.decoration.ToLowerCamelCase() }Decoration",
            _ => Enum.GetNames(typeof(Badge.StandardDecorativeVariations)).Length > 1
          ).
          AddElementToEndIf(
            "Badge--YDF__BordersDisguisingDecorativeModifier", 
            _ => this.decorativeModifiers.Contains(Badge.DecorativeModifiers.bordersDisguising)
          ).
          StringifyEachElementAndJoin("");

    }
  }
  
}