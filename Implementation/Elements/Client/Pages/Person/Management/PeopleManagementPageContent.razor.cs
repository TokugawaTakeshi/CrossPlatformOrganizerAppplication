using Client.SharedState;
using Microsoft.AspNetCore.Components;


namespace Client.Pages.Person.Management;


public partial class PeopleManagementPageContent : ComponentBase
{
  
  private readonly string personManagerActivationGuidance = "人の詳細を閲覧する事や編集するにはカードをクリック・タップして下さい。";
  
  private CommonSolution.Entities.Person? activePerson => PeopleSharedState.currentlySelectedPerson;

  
  protected override void OnInitialized()
  {
    PeopleSharedState.onStateChanged += base.StateHasChanged;
  }
  
}