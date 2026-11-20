using System.Diagnostics;
using Client.SharedGUI_Components.Cards.Person.Localizations;
using CommonSolution.Restrictions;
using YamatoDaiwa.Frontend.GUI_Components.Abstractions;

namespace Client.SharedGUI_Components.Cards.Person;


public partial class PersonCard : 
    Microsoft.AspNetCore.Components.ComponentBase, 
    IFlexibleExternalCSS_ClassesSpecifyingForRootElement 
{

  /* ━━━ Component Parameters ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  [Microsoft.AspNetCore.Components.Parameter] 
  public required CommonSolution.Entities.Person targetPerson { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter]
  public Microsoft.AspNetCore.Components.EventCallback<
    CommonSolution.Entities.Person
  > onClickRootElementEventHandler { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter] 
  public string rootElementTag { get; set; } = "div";
  
  [Microsoft.AspNetCore.Components.Parameter]
  public bool disabled { get; set; } = false;
  
  
  /* ━━━ Events Handling ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private async System.Threading.Tasks.Task onClickOutermostElement()
  {
    if (this.onClickRootElementEventHandler.HasDelegate)
    {
      try
      {
        await this.onClickRootElementEventHandler.InvokeAsync(this.targetPerson);
      }
      catch (Exception exception)
      {
        Debug.WriteLine(exception);
        throw;
      }
    }
  }
  
  
  /* ━━━ CSS Classes ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  [Microsoft.AspNetCore.Components.Parameter]
  public string? rootElementModifierCSS_Class { get; set; } = null;

  [Microsoft.AspNetCore.Components.Parameter]
  public string[]? rootElementModifierCSS_Classes { get; set; } = null;

  [Microsoft.AspNetCore.Components.Parameter]
  public string? rootElementSpaceSeparatedModifierCSS_Classes { get; set; } = null;
  
  
  /* ━━━ Localization ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private readonly PersonCardLocalization localization = 
      ClientConfigurationRepresentative.GetBCP_47_Tag_OfSupportedLocale() switch
          {
            SupportedCultures.BCP_47_Tags.JAPANESE => new PersonCardJapaneseLocalization(),
            SupportedCultures.BCP_47_Tags.ENGLISH__UNITED_KINGDOM => new PersonCardEnglishLocalization(),
            _ => throw new ArgumentOutOfRangeException()
          };

}
