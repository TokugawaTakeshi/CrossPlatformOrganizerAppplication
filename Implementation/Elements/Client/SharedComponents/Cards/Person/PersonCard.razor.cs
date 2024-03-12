using System.Diagnostics;
using System.Globalization;
using Client.SharedComponents.Cards.Person.Localization;
using YamatoDaiwa.Frontend.Components.Abstractions;


namespace Client.SharedComponents.Cards.Person;


public partial class PersonCard : 
    Microsoft.AspNetCore.Components.ComponentBase, 
    ISupportsFlexibleExternalCSS_ClassesSpecifyingForRootElement 
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
      ClientConfigurationRepresentative.MustForceDefaultLocalization ?
          new PersonCardEnglishLocalization() :
          CultureInfo.CurrentCulture.Name switch
          {
            SupportedCultures.JAPANESE => new PersonCardJapaneseLocalization(),
            _ => new PersonCardEnglishLocalization()
          };

}
