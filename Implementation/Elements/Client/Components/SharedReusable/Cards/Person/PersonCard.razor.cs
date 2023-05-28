using System.Diagnostics;
using Microsoft.AspNetCore.Components;


namespace Client.Components.SharedReusable.Cards.Person;


public partial class PersonCard : ComponentBase
{

  [Parameter] public required CommonSolution.Entities.Person targetPerson { get; set; }
  
  [Parameter] public EventCallback<CommonSolution.Entities.Person> onClick { get; set; }

  [Parameter] public string rootElementTag { get; set; } = "div";
  
  [Parameter] public string? spaceSeparatedAdditionalCSS_Classes { get; set; }
  
  
  private async System.Threading.Tasks.Task onClickOutermostElement()
  {
    await this.onClick.InvokeAsync(this.targetPerson);
  }

}
