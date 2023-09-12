using Microsoft.AspNetCore.Components;
using FrontEndFramework.Components.Abstractions;
using FrontEndFramework.Exceptions;

using System.Diagnostics;
using System.Runtime.CompilerServices;
using YamatoDaiwaCS_Extensions;
using Utils;


namespace FrontEndFramework.Components.Badge.LoadingPlaceholder;


public partial class BadgeLoadingPlaceholder : ComponentBase
{

  /* ━━━ Theming ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  protected string _theme = Badge.StandardThemes.regular.ToString();
  
  [Parameter] public object theme
  {
    get => this._theme;
    set => YDF_ComponentsHelper.AssignThemeIfItIsValid<Badge.StandardThemes>(value, Badge.CustomThemes, ref this._theme);
  }

  [Parameter]
  public bool areThemesCSS_ClassesCommon { get; set; } = 
      YDF_ComponentsHelper.areThemesCSS_ClassesCommon || Badge.mustConsiderThemesCSS_ClassesAsCommon;
  
  
  /* ─── Geometry ─────────────────────────────────────────────────────────────────────────────────────────────────── */
  protected string _geometry = Badge.StandardGeometricVariations.regular.ToString();

  [Parameter] public object geometry
  {
    get => this._geometry;
    set => YDF_ComponentsHelper.AssignGeometricVariationIfItIsValid<Badge.StandardGeometricVariations>(
      value, Badge.CustomGeometricVariations, ref this._geometry
    );
  }
  
  [Parameter]
  public Badge.GeometricModifiers[] geometricModifiers { get; set; } = Array.Empty<Badge.GeometricModifiers>(); 
  
  
  /* ━━━ CSS classes ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  [Parameter]
  public string? spaceSeparatedAdditionalCSS_Classes { get; set; }
  
  private string rootElementModifierCSS_Classes => new List<string>().
      
      AddElementToEndIf(
        $"Badge--YDF__{ this._theme.ToLowerCamelCase() }Theme",
        YDF_ComponentsHelper.MustApplyThemeCSS_Class(
          typeof(Badge.StandardThemes), Badge.CustomThemes, this.areThemesCSS_ClassesCommon
        )
      ).
      AddElementToEndIf(
        $"Badge--YDF__{ this._geometry.ToUpperCamelCase() }Geometry",
        YDF_ComponentsHelper.MustApplyThemeCSS_Class(
          typeof(Badge.StandardGeometricVariations), Badge.CustomGeometricVariations
        )
      ).
      AddElementToEndIf(
        "Badge--YDF__PllShapeGeometricModifier", 
        this.geometricModifiers.Contains(Badge.GeometricModifiers.pillShape)
      ).
      StringifyEachElementAndJoin("");
  
}