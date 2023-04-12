using System.Diagnostics;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Utils;


namespace FrontEndFramework.Components.Controls.Buttons.Plain;


public partial class Button : ComponentBase
{

  public enum HTML_Types
  {
    regular,
    submit,
    inputButton,
    inputSubmit,
    inputReset
  }

  [Parameter] 
  public HTML_Types HTML_Type { get; set; } = HTML_Types.regular;
  
  
  [Parameter] 
  public string? label { get; set; }
  
  [Parameter] 
  public string? accessibilityGuidance { get; set; }
  
  [Parameter]
  public string? internalURN { get; set; }

  [Parameter]
  public string? externalURI { get; set; }
  
  [Parameter] 
  public bool disabled { get; set; }
  
  
  [Parameter]
  public RenderFragment? PrependedSVG_Icon { get; set; }
  
  [Parameter]
  public RenderFragment? AppendedSVG_Icon { get; set; }
  
  [Parameter]
  public RenderFragment? LoneSVG_Icon { get; set; }
  
  
  
  // < === TODO テーマ当たり始末方法が分かり次第着手 https://github.com/TokugawaTakeshi/ExperimentalCSharpApplication1/issues/34
  public enum StandardThemes
  {
    regular
  }

  [Parameter] 
  public string theme { get; set; } = Button.StandardThemes.regular.ToString();

  protected static bool mustConsiderThemesAsExternal = false;
  
  public static void ConsiderThemesAsExternal()
  {
    Button.mustConsiderThemesAsExternal = true;
  }
  
  [Parameter]
  public bool areThemesExternal { get; set; }
  
  
  public enum StandardGeometricVariations
  {
    regular,
    small,
    linkLike
  }

  [Parameter] 
  public string geometry { get; set; } = Button.StandardGeometricVariations.regular.ToString();

  
  public enum StandardDecorativeVariations
  {
    regular,
    accented,
    linkLike
  }

  [Parameter] 
  public string decoration { get; set; } = Button.StandardDecorativeVariations.regular.ToString();
  // > =================================================================================================================
  
  [Parameter]
  public string? spaceSeparatedAdditionalCSS_Classes { get; set; }
  
  
  /* === Computing of tag name of root element ====================================================================== */
  private bool isButtonTheTagNameOfRootElement =>
      String.IsNullOrEmpty(this.internalURN) &&
      String.IsNullOrEmpty(this.externalURI) &&
      HTML_Type is HTML_Types.regular or HTML_Types.submit;

  private bool isInputTheTagNameOfRootElement => 
      HTML_Type is HTML_Types.inputButton or HTML_Types.inputSubmit or HTML_Types.inputReset;
  
  private bool isAnchorTheTagNameOfRootElement => !String.IsNullOrEmpty(this.externalURI);
  
  private bool isNavLinkTheRootElement => !String.IsNullOrEmpty(this.internalURN);

  
  /* === Computing of the attributes ================================================================================ */
  private string? typeAttributeValueOfInputOrButtonElement {

    get
    {
      
      if (!this.isButtonTheTagNameOfRootElement && !this.isInputTheTagNameOfRootElement)
      {
        return null;
      }
      

      return this.HTML_Type switch
      {
        HTML_Types.regular => "button",
        HTML_Types.submit => "submit",
        HTML_Types.inputButton => "button",
        HTML_Types.inputSubmit => "submit",
        HTML_Types.inputReset => "reset",
        _ => null
      };
    }

  }

  [Parameter]
  public EventCallback<MouseEventArgs> onClick { get; set; }
  
  
  private string rootElementSpaceSeparatedClasses => new List<string>().
      AddElementsToEnd("Button--YDF").
      AddElementToEndIf(
        "Button--YDF__DisabledState",
        _ => (isAnchorTheTagNameOfRootElement || isNavLinkTheRootElement) && this.disabled
      ).
      AddElementToEndIf(
        $"Button--YDF__{ this.theme.ToUpperCamelCase() }Theme",
        _ => Enum.GetNames(typeof(StandardThemes)).Length > 1 && !this.areThemesExternal
      ).
      AddElementToEndIf(
        $"Button--YDF__{ this.geometry.ToUpperCamelCase() }Geometry",
        _ => Enum.GetNames(typeof(StandardGeometricVariations)).Length > 1
      ).
      AddElementToEndIf(
        $"Button--YDF__{ this.decoration.ToUpperCamelCase() }Decoration",
        _ => Enum.GetNames(typeof(StandardDecorativeVariations)).Length > 1
      ).
      StringifyEachElementAndJoin(" ");

}