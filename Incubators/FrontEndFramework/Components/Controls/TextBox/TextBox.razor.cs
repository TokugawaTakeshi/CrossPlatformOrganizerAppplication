using System.Runtime.CompilerServices;
using System.Transactions;
using Microsoft.AspNetCore.Components;
using Utils;


namespace FrontEndFramework.Components.Controls.TextBox;


public partial class TextBox : InputtableControl
{

  /* === HTML type ================================================================================================== */
  public enum HTML_Types
  {
    regular,
    email,
    number,
    password,
    phoneNumber,
    URI,
    hidden
  }

  [Parameter] public HTML_Types HTML_Type { get; set; } = HTML_Types.regular;
  

  /* === Textings =================================================================================================== */
  [Parameter] public string? placeholder { get; set; }

  
  /* === Preventing of inputting of invalid value =================================================================== */
  protected ulong? minimalCharactersCount { get; set; }
  protected ulong? maximalCharactersCount { get; set; }
  
  protected ulong? minimalNumericValue { get; set; }
  protected ulong? maximalNumericValue { get; set; }
  
  protected bool valueMustBeTheNonNegativeIntegerOfRegularNotation { get; set; } = false; 

  protected bool valueMustBeTheDigitsSequence { get; set; } = false; 
  
  
  /* === HTML IDs =================================================================================================== */
  /* --- Input or text area ----------------------------------------------------------------------------------------- */
  protected static uint counterForInputOrTextAreaElementHTML_ID_Generating = 0;
  
  protected static string generateInputOrTextAreaElementHTML_ID() {
    TextBox.counterForInputOrTextAreaElementHTML_ID_Generating++;
    return $"TEXT_BOX-INPUT_OR_TEXT_AREA_ELEMENT-${ TextBox.counterForInputOrTextAreaElementHTML_ID_Generating }";
  }

  protected readonly string INPUT_OR_TEXT_AREA_ELEMENT_HTML_ID;
  
  /* --- Label ------------------------------------------------------------------------------------------------------ */
  [Parameter] public string? labelElementHTML_ID { get; set; }

  
  /* === Other flags ================================================================================================ */
  [Parameter] public bool multiline { get; set; } = false;
  [Parameter] public bool isReadonly { get; set; } = false;
  
  
  /* === Theme ====================================================================================================== */
  public enum StandardThemes { regular }

  protected static object? CustomThemes;
  
  public static void defineCustomThemes(Type CustomThemes) {

    if (!CustomThemes.IsEnum)
    {
      throw new System.ArgumentException("The custom themes must the enumeration.");
    }


    TextBox.CustomThemes = CustomThemes;

  }
  
  protected string _theme = TextBox.StandardThemes.regular.ToString();
  
  [Parameter] public object theme
  {
    get => this._theme;
    set
    {

      if (value is TextBox.StandardThemes standardTheme)
      {
        this._theme = standardTheme.ToString();
        return;
      }
      
      
      // TODO CustomThemes確認 https://github.com/TokugawaTakeshi/ExperimentalCSharpApplication1/issues/34#issuecomment-1500788874
      
      this._theme = value.ToString();

    }
  }
  
  internal static bool mustConsiderThemesAsExternal = false;

  public static void ConsiderThemesAsExternal()
  {
    TextBox.mustConsiderThemesAsExternal = true;
  }
  
  [Parameter] public bool areThemesExternal { get; set; } = TextBox.mustConsiderThemesAsExternal;
  
  
  /* === Geometry =================================================================================================== */
  public enum StandardGeometricVariations
  {
    regular,
    small
  }

  protected static object? CustomGeometricVariations;
  
  public static void defineCustomGeometricVariations(Type CustomGeometricVariations)
  {

    if (!CustomGeometricVariations.IsEnum)
    {
      throw new System.ArgumentException("The custom geometric variations must the enumeration.");
    }


    TextBox.CustomGeometricVariations = CustomGeometricVariations;

  }
  
  protected string _geometry = TextBox.StandardGeometricVariations.regular.ToString();
  
  [Parameter] public object geometry
  {
    get => this._geometry;
    set
    {

      if (value is TextBox.StandardGeometricVariations standardGeometricVariation)
      {
        this._geometry = standardGeometricVariation.ToString();
        return;
      }
      
      
      // TODO CustomGeometricVariations https://github.com/TokugawaTakeshi/ExperimentalCSharpApplication1/issues/34#issuecomment-1500788874

      this._geometry = value.ToString();

    }
  }
  
  
  /* === Decoration ================================================================================================= */
  public enum StandardDecorativeVariations { regular }

  protected static object? CustomDecorativeVariations;
  
  public static void defineNewDecorativeVariations(Type CustomDecorativeVariations) {
    
    if (!CustomDecorativeVariations.IsEnum)
    {
      throw new System.Exception("The custom decorative variations must the enumeration.");
    }
      
        
    TextBox.CustomDecorativeVariations = CustomDecorativeVariations;
      
  }  
  
  protected string _decoration = TextBox.StandardDecorativeVariations.regular.ToString();

  [Parameter] public required object decoration
  {
    get => _decoration;
    set
    {

      if (value is TextBox.StandardDecorativeVariations standardDecorativeVariation)
      {
        this._decoration = standardDecorativeVariation.ToString();
        return;
      }

      
      // TODO CustomDecorativeVariations確認 https://github.com/TokugawaTakeshi/ExperimentalCSharpApplication1/issues/34#issuecomment-1500788874
      
      this._decoration = value.ToString();

    }
  }
  
  
  /* === CSS classes ================================================================================================ */
  [Parameter] public string? spaceSeparatedAdditionalCSS_Classes { get; set; }
  
  private string rootElementModifierCSS_Classes => new List<string>().
      /*
       * ...this.multiline ? [ "TextBox--YDF__Multiline" ] : [],
        ...this.disabled ? [ "TextBox--YDF__DisabledState" ] : [],
       */
      
      AddElementToEndIf("TextBox--YDF__Multiline", _ => this.multiline).
      AddElementToEndIf("TextBox--YDF__DisabledState", _ => this.disabled).
    
      AddElementToEndIf(
        $"TextBox--YDF__{ this._theme.ToUpperCamelCase() }Theme",
        _ => Enum.GetNames(typeof(TextBox.StandardThemes)).Length > 1 && !this.areThemesExternal
      ).
      AddElementToEndIf(
        $"TextBox--YDF__{ this._geometry.ToUpperCamelCase() }Geometry",
        _ => Enum.GetNames(typeof(TextBox.StandardGeometricVariations)).Length > 1
      ).
      AddElementToEndIf(
        $"TextBox--YDF__{ this._decoration.ToUpperCamelCase() }Decoration",
        _ => Enum.GetNames(typeof(TextBox.StandardDecorativeVariations)).Length > 1
      ).
      StringifyEachElementAndJoin("");
   
  
  /* === Constructor ================================================================================================ */
  public TextBox()
  {
    
    this.INPUT_OR_TEXT_AREA_ELEMENT_HTML_ID = 
        base.coreElementHTML_ID ?? 
        TextBox.generateInputOrTextAreaElementHTML_ID();
    
  }
  
}