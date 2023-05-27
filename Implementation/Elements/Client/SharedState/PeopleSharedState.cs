using CommonSolution.Entities;

using System.Diagnostics;


namespace Client.SharedState;


internal abstract class PeopleSharedState
{

  public static event Action? onStateChanged;
  private static void NotifyStateChanged() => PeopleSharedState.onStateChanged?.Invoke();
  
  
  /* === 取得 ======================================================================================================= */
  private static Person[] _people = Array.Empty<Person>();
  public static Person[] people
  {
    get => PeopleSharedState._people;
    private set
    {
      PeopleSharedState._people = value;
      PeopleSharedState.NotifyStateChanged();
    }
  }
  
  private static bool _isWaitingForPeopleSelectionRetrieving = true;
  public static bool isWaitingForPeopleSelectionRetrieving
  {
    get => PeopleSharedState._isWaitingForPeopleSelectionRetrieving;
    private set
    {
      PeopleSharedState._isWaitingForPeopleSelectionRetrieving = value;
      PeopleSharedState.NotifyStateChanged();
    }
  }
  
  private static bool _isPeopleSelectionBeingRetrievedNow = false;
  public static bool isPeopleSelectionBeingRetrievedNow
  {
    get => PeopleSharedState._isPeopleSelectionBeingRetrievedNow;
    private set
    {
      PeopleSharedState._isPeopleSelectionBeingRetrievedNow = value;
      PeopleSharedState.NotifyStateChanged();
    }
  }
  
  private static bool _hasPeopleSelectionRetrievingErrorOccurred = false;
  public static bool hasPeopleSelectionRetrievingErrorOccurred
  {
    get => PeopleSharedState._hasPeopleSelectionRetrievingErrorOccurred;
    private set
    {
      PeopleSharedState._hasPeopleSelectionRetrievingErrorOccurred = value;
      PeopleSharedState.NotifyStateChanged();
    }
  }

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
    catch (Exception exception)
    {
      PeopleSharedState.hasPeopleSelectionRetrievingErrorOccurred = true;
      Debug.WriteLine(exception);
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
