using FrontEndFramework.Components.Abstractions;
using FrontEndFramework.ValidatableControl;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Utils;


namespace FrontEndFramework.Components.Controls.TextBox;


public partial class TextBox : InputtableControl, IValidatableControl
{

  /* ━━━ Payload ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  protected string rawValue = "";
  protected ValidatableControl.Payload _payload;
  
  [Microsoft.AspNetCore.Components.Parameter]
  public required ValidatableControl.Payload payload
  {
    get => _payload;
    set
    {
      this._payload = value;
      this.synchronizeRawValueWithPayloadValue();
    }
  }
  
  private void onInputEventHandler(Microsoft.AspNetCore.Components.ChangeEventArgs inputtingEvent)
  {
    this._payload.Value = inputtingEvent.Value?.ToString() ?? "";
  }
  
  
  /* ━━━ HTML type ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
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

  [Microsoft.AspNetCore.Components.Parameter]
  public HTML_Types HTML_Type { get; set; } = HTML_Types.regular;
  

  
  /* ━━━ Textings ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  [Microsoft.AspNetCore.Components.Parameter]
  public string? placeholder { get; set; }

  
  /* ━━━ Preventing of inputting of invalid value ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  [Microsoft.AspNetCore.Components.Parameter]  
  public ulong? minimalCharactersCount { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter]  
  public ulong? maximalCharactersCount { get; set; }
  
  
  [Microsoft.AspNetCore.Components.Parameter]  
  public ulong? minimalNumericValue { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter]  
  public ulong? maximalNumericValue { get; set; }
  
  
  [Microsoft.AspNetCore.Components.Parameter]  
  public bool valueMustBeTheNonNegativeIntegerOfRegularNotation { get; set; } = false;
   
  [Microsoft.AspNetCore.Components.Parameter]  
  public bool valueMustBeTheDigitsSequence { get; set; } = false;
  
  
  /* ━━━ Raw value transformations ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  [Microsoft.AspNetCore.Components.Parameter] 
  public bool mustConvertEmptyStringToNull { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter] 
  public bool mustConvertEmptyStringToZero { get; set; }
  
  
  /* ━━━ HTML IDs ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  /* ─── Input or text area ──────────────────────────────────────────────────────────────────────────────────────── */
  protected static uint counterForInputOrTextAreaElementHTML_ID_Generating = 0;
  
  protected static string generateInputOrTextAreaElementHTML_ID() {
    TextBox.counterForInputOrTextAreaElementHTML_ID_Generating++;
    return $"TEXT_BOX--YDF-INPUT_OR_TEXT_AREA_ELEMENT-${ TextBox.counterForInputOrTextAreaElementHTML_ID_Generating }";
  }

  protected readonly string INPUT_OR_TEXT_AREA_ELEMENT_HTML_ID;
  
  /* ─── Label ───────────────────────────────────────────────────────────────────────────────────────────────────── */
  [Microsoft.AspNetCore.Components.Parameter] 
  public string? labelElementHTML_ID { get; set; }

  
  /* ━━━ Other flags ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  [Microsoft.AspNetCore.Components.Parameter]  
  public bool multiline { get; set; } = false;
  
  [Microsoft.AspNetCore.Components.Parameter]  
  public bool @readonly { get; set; } = false;
  
  
  /* ━━━ Children components/elements ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  protected Microsoft.AspNetCore.Components.ElementReference nativeInputAcceptingElement;

  
  /* ━━━ Public methods ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public new IValidatableControl HighlightInvalidInput()
  {
    base.HighlightInvalidInput();
    return this;
  }
  
  // TODO 変化検討中
  public Microsoft.AspNetCore.Components.ElementReference GetRootElement()
  {
    throw new NotImplementedException();
  }
  
  public IValidatableControl Focus()
  {
    // TODO 非同期呼び出し始末
    JSRuntime.InvokeVoidAsync("putFocusOnElement", this.nativeInputAcceptingElement);
    return this;
  }

  public void ResetStateToInitial()
  {
  }
  

  /* ━━━ Theming ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public enum StandardThemes { regular }
  
  protected internal static Type? CustomThemes;

  public static void defineCustomThemes(Type CustomThemes)
  {
    YDF_ComponentsHelper.ValidateCustomTheme(CustomThemes);
    TextBox.CustomThemes = CustomThemes;
  }

  protected string _theme = TextBox.StandardThemes.regular.ToString();
  
  [Microsoft.AspNetCore.Components.Parameter]
  public object theme
  {
    get => this._theme;
    set => YDF_ComponentsHelper.AssignThemeIfItIsValid<TextBox.StandardThemes>(
      value, TextBox.CustomThemes, ref this._theme
    );
  }

  protected internal static bool mustConsiderThemesCSS_ClassesAsCommon = YDF_ComponentsHelper.areThemesCSS_ClassesCommon;

  public static void considerThemesAsCommon()
  {
    TextBox.mustConsiderThemesCSS_ClassesAsCommon = true;
  }
  
  [Microsoft.AspNetCore.Components.Parameter]
  public bool areThemesCSS_ClassesCommon { get; set; } = 
      YDF_ComponentsHelper.areThemesCSS_ClassesCommon || TextBox.mustConsiderThemesCSS_ClassesAsCommon;
  
  
  /* ─── Geometry ─────────────────────────────────────────────────────────────────────────────────────────────────── */
  public enum StandardGeometricVariations
  {
    regular, 
    small
  }

  protected internal static Type? CustomGeometricVariations;
  
  public static void defineCustomGeometricVariations(Type CustomGeometricVariations)
  {
    YDF_ComponentsHelper.ValidateCustomGeometricVariation(CustomGeometricVariations);
    TextBox.CustomGeometricVariations = CustomGeometricVariations;
  }

  protected string _geometry = TextBox.StandardGeometricVariations.regular.ToString();

  [Microsoft.AspNetCore.Components.Parameter]
  public object geometry
  {
    get => this._geometry;
    set => YDF_ComponentsHelper.AssignGeometricVariationIfItIsValid<TextBox.StandardGeometricVariations>(
    value, TextBox.CustomGeometricVariations, ref this._geometry
    );
  }
  
  
  /* ─── Decorative variations ────────────────────────────────────────────────────────────────────────────────────── */
  public enum StandardDecorativeVariations { regular }

  protected internal static Type? CustomDecorativeVariations;

  public static void defineCustomDecorativeVariations(Type CustomDecorativeVariations) {
    YDF_ComponentsHelper.ValidateCustomDecorativeVariation(CustomDecorativeVariations);
    TextBox.CustomDecorativeVariations = CustomDecorativeVariations;
  }

  protected string _decoration = TextBox.StandardDecorativeVariations.regular.ToString();

  [Microsoft.AspNetCore.Components.Parameter]
  public required object decoration
  {
    get => _decoration;
    set => YDF_ComponentsHelper.AssignDecorativeVariationIfItIsValid<TextBox.StandardDecorativeVariations>(
      value, TextBox.CustomDecorativeVariations, ref this._decoration
    );
  }
  
  
  /* ━━━ CSS classes ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  [Microsoft.AspNetCore.Components.Parameter]
  public string? spaceSeparatedAdditionalCSS_Classes { get; set; }
  
  private string rootElementModifierCSS_Classes => new List<string>().
      
      AddElementToEndIf("TextBox--YDF__Multiline", this.multiline).
      AddElementToEndIf("TextBox--YDF__DisabledState", this.disabled).
      AddElementToEndIf("TextBox--YDF__ReadonlyState", this.@readonly).
    
      AddElementToEndIf(
        $"TextBox--YDF__{ this._theme.ToUpperCamelCase() }Theme",
        YDF_ComponentsHelper.MustApplyThemeCSS_Class(
          typeof(TextBox.StandardThemes), TextBox.CustomThemes, this.areThemesCSS_ClassesCommon
        )
      ).
      
      AddElementToEndIf(
        $"Badge--YDF__{ this._geometry.ToUpperCamelCase() }Geometry",
        YDF_ComponentsHelper.MustApplyGeometricVariationModifierCSS_Class(
          typeof(TextBox.StandardGeometricVariations), TextBox.CustomGeometricVariations
        )
      ).
      
      AddElementToEndIf(
        $"Badge--YDF__{ this._decoration.ToUpperCamelCase() }Decoration",
        YDF_ComponentsHelper.MustApplyDecorativeVariationModifierCSS_Class(
          typeof(TextBox.StandardDecorativeVariations), TextBox.CustomDecorativeVariations
        )
      ).
      
      StringifyEachElementAndJoin(" ");
   
  
  /* ━━━  Constructor ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public TextBox()
  {
    this.INPUT_OR_TEXT_AREA_ELEMENT_HTML_ID = base.coreElementHTML_ID ?? TextBox.generateInputOrTextAreaElementHTML_ID();
  }
  
  
  /* ━━━ Other ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  protected void synchronizeRawValueWithPayloadValue()
  {
    this.rawValue = (string)this.payload.Value;
  }
  
  protected bool mustHighlightInvalidInputIfAnyValidationErrorsMessages = true;
  
  
  [Microsoft.AspNetCore.Components.Inject] 
  protected IJSRuntime JSRuntime { get; set; } = null!;
  
}