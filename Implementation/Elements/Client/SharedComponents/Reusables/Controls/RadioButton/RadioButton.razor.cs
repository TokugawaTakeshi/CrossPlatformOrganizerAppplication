using FrontEndFramework.Components;
using Utils;

namespace Client.SharedComponents.Reusables.Controls.RadioButton;


public partial class RadioButton : Microsoft.AspNetCore.Components.ComponentBase
// public partial class RadioButton : YDF_Component
{
  
  [Microsoft.AspNetCore.Components.Parameter] 
  public string? spaceSeparatedAdditionalCSS_Classes { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter]
  public required string label { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter]
  public string? HTML_Name { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter]
  public string? HTML_Value { get; set; }

  [Microsoft.AspNetCore.Components.Parameter]
  public bool isChecked { get; set; } = false;
  
  [Microsoft.AspNetCore.Components.Parameter]
  public bool disabled { get; set; } = false;


  /* ━━━ HTML IDs ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  protected static uint counterForInputElementHTML_ID_Generating = 0;
  
  protected static string generateInputElementHTML_ID() {
    RadioButton.counterForInputElementHTML_ID_Generating++;
    return $"RADIO_BUTTON--YDF-${ RadioButton.counterForInputElementHTML_ID_Generating }";
  }

  protected readonly string INPUT_ELEMENT_HTML_ID = RadioButton.generateInputElementHTML_ID();

  
  /* ━━━ CSS Classes ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private string rootElementModifierSpaceSeparatedClasses => new List<string>().
      AddElementToEndIf("SearchBox--YDF__CheckedState", this.isChecked).
      AddElementToEndIf("SearchBox--YDF__UncheckedState", !this.isChecked).
      AddElementToEndIf("SearchBox--YDF__DisabledState", !this.disabled).
      StringifyEachElementAndJoin(" ");
  
}