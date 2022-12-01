using System.Diagnostics;
using Microsoft.AspNetCore.Components;


namespace Client.Components.SharedReusable.Managers.People;


public partial class PeopleManager : ComponentBase
{

  [Parameter]
  public string SpaceSeparatedAdditionalCSS_Classes { get; set; }

  
  private List<BusinessRules.Enterprise.Person> _people = new();
  
  private bool _isWaitingForPeopleSelectionRetrieving = true;
  private bool _isPeopleSelectionBeingRetrievedNow = false;
  private bool _isPeopleSelectionRetrievingErrorOccurred = false;
  
  private bool isPeopleSelectionRetrievingInProgressOrNotStartedYet => 
    _isWaitingForPeopleSelectionRetrieving || _isPeopleSelectionBeingRetrievedNow;

  
  protected override async System.Threading.Tasks.Task OnInitializedAsync()
  {

    _isWaitingForPeopleSelectionRetrieving = false;
    _isPeopleSelectionBeingRetrievedNow = true;
    _isPeopleSelectionRetrievingErrorOccurred = false;

    try
    {
      _people = await ClientDependencies.Injector.gateways().Person.RetrieveAll();
    }
    catch (Exception e)
    {
      Debug.WriteLine(e);
      _isPeopleSelectionRetrievingErrorOccurred = true;
    }

    _isPeopleSelectionBeingRetrievedNow = false;

  }
  
}
