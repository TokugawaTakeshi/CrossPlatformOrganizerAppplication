using System.Diagnostics;
using Microsoft.AspNetCore.Components;


namespace Client.Components.SharedReusable.Managers.People;


public partial class PeopleManager : ComponentBase
{

  [Parameter]
  public string? spaceSeparatedAdditionalCSS_Classes { get; set; }


  private CommonSolution.Entities.Person[] people = Array.Empty<CommonSolution.Entities.Person>();
  
  private bool isWaitingForPeopleSelectionRetrieving = true;
  private bool isPeopleSelectionBeingRetrievedNow = false;
  private bool isPeopleSelectionRetrievingErrorOccurred = false;
  
  private bool isPeopleSelectionRetrievingInProgressOrHasNotStartedYet => 
      isWaitingForPeopleSelectionRetrieving || isPeopleSelectionBeingRetrievedNow;

  
  protected override async System.Threading.Tasks.Task OnInitializedAsync()
  {

    isWaitingForPeopleSelectionRetrieving = false;
    isPeopleSelectionBeingRetrievedNow = true;
    isPeopleSelectionRetrievingErrorOccurred = false;

    try
    {
      people = await ClientDependencies.Injector.gateways().Person.RetrieveAll();
    }
    catch (Exception e)
    {
      Debug.WriteLine(e);
      isPeopleSelectionRetrievingErrorOccurred = true;
    }

    isPeopleSelectionBeingRetrievedNow = false;

  }
  
}
