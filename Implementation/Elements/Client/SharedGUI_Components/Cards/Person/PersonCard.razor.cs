using Client.SharedGUI_Components.Cards.Person.Localizations;
using CommonSolution.Restrictions;
using YamatoDaiwa.CSharpExtensions;

namespace Client.SharedGUI_Components.Cards.Person;


public partial class PersonCard : 
    Microsoft.AspNetCore.Components.ComponentBase, 
    YamatoDaiwa.Frontend.GUI_Components.Abstractions.IHTML_AttributesFallthrough 
{

  /* ━━━ Component Parameters ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  [Microsoft.AspNetCore.Components.Parameter] 
  public required CommonSolution.Entities.Person targetPerson { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter]
  public Microsoft.AspNetCore.Components.EventCallback<
    CommonSolution.Entities.Person
  > onRootElementClickedEventHandler { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter] 
  public string rootElementTag { get; set; } = "div";
  
  [Microsoft.AspNetCore.Components.Parameter]
  public bool disabled { get; set; } = false;
  
  [Microsoft.AspNetCore.Components.Parameter(CaptureUnmatchedValues = true)]
  public Dictionary<string, object>? rootElementHTML_Attributes { get; set; }
  
  
  /* ━━━ Localization ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private readonly PersonCardLocalization localization = 
      ClientConfigurationRepresentative.GetBCP_47_Tag_OfSupportedLocale() switch
          {
            SupportedCultures.BCP_47_Tags.JAPANESE => new PersonCardJapaneseLocalization(),
            SupportedCultures.BCP_47_Tags.ENGLISH__UNITED_KINGDOM => new PersonCardEnglishLocalization(),
            _ => throw new ArgumentOutOfRangeException()
          };
  
  
  /* ━━━ Events Handling ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private async System.Threading.Tasks.Task onClickRootElement()
  {
    if (this.onRootElementClickedEventHandler.HasDelegate)
    {
      try
      {
        await this.onRootElementClickedEventHandler.InvokeAsync(this.targetPerson);
      }
      catch (Exception exception)
      {
        
        #if DEBUG
          System.Diagnostics.Debug.WriteLine(exception);
        #endif
        
        throw;
        
      }
    }
  }
  
  
  /* ━━━ CSS Classes ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private string composeClassAttributeValueForRootElement(string namespaceCSS_Class) => 
    
      new List<string?> { namespaceCSS_Class }.

          AddElementToEndIfNotNull(
            this.rootElementHTML_Attributes?.TryGetValue("class", out object? CSS_Class) == true ? CSS_Class.ToString() : null
          ).
    
          AddElementToEndIf("PersonCard__DisabledState", this.disabled).

          StringifyEachElementAndJoin(" ");

}
