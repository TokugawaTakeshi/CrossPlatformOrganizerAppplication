using Client.SharedState;
using System.Diagnostics;
using Microsoft.AspNetCore.Components;


namespace Client.Components.SharedReusable.Managers.People;


public partial class PeopleManager : ComponentBase
{

  [Parameter]
  public string? spaceSeparatedAdditionalCSS_Classes { get; set; }


  protected override async System.Threading.Tasks.Task OnInitializedAsync()
  {
    PeopleSharedState.onStateChanged += base.StateHasChanged;
    await PeopleSharedState.retrievePeople();
  }
  
  
  private void onSelectPerson(CommonSolution.Entities.Person targetPerson)
  {
    Console.WriteLine("CP1");
    PeopleSharedState.currentlySelectedPerson = targetPerson;
  }
  
}
