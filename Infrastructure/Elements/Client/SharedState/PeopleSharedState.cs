using CommonSolution.Entities;

using System.Diagnostics;


namespace Client.SharedState;


internal abstract class PeopleSharedState
{

  public static event Action? onStateChanged;
  private static void NotifyStateChanged() => PeopleSharedState.onStateChanged?.Invoke();
  
  
  /* === 取得 ======================================================================================================= */
  public static Person[] people { get; private set; } = Array.Empty<Person>();
  
  public static bool isWaitingForPeopleSelectionRetrieving { get; private set; } = true;
  public static bool isPeopleSelectionBeingRetrievedNow { get; private set; } = false;
  public static bool hasPeopleSelectionRetrievingErrorOccurred { get; private set; } = false;

  public static bool isPeopleRetrievingInProgressOrNotStartedYet => 
      PeopleSharedState.isWaitingForPeopleSelectionRetrieving || PeopleSharedState.isPeopleSelectionBeingRetrievedNow;
  
  public static async System.Threading.Tasks.Task retrievePeople()
  {

    if (PeopleSharedState.isPeopleSelectionBeingRetrievedNow)
    {
      return;      
    }
    
    
    PeopleSharedState.isWaitingForPeopleSelectionRetrieving = false;
    PeopleSharedState.isPeopleSelectionBeingRetrievedNow = true;
    PeopleSharedState.hasPeopleSelectionRetrievingErrorOccurred = false;
    
    try
    {
      PeopleSharedState.people = await ClientDependencies.Injector.gateways().Person.RetrieveAll();
    }
    catch (Exception e)
    {
      PeopleSharedState.hasPeopleSelectionRetrievingErrorOccurred = true;
      Debug.WriteLine(e);
    }

    PeopleSharedState.isPeopleSelectionBeingRetrievedNow = false;
    
  }
  
  
  /* === 選択 ======================================================================================================= */
  private static Person? _currentlySelectedPerson = null;
  public static Person? currentlySelectedPerson
  {
    get => PeopleSharedState._currentlySelectedPerson;
    set
    {
      PeopleSharedState._currentlySelectedPerson = value;
      PeopleSharedState.NotifyStateChanged();
    }
  }

}
