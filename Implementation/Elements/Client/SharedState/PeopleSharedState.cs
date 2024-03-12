using CommonSolution.Entities;
using CommonSolution.Gateways;
using System.Diagnostics;
using YamatoDaiwa.CSharpExtensions.Exceptions;


namespace Client.SharedState;


internal abstract class PeopleSharedState
{

  public static event Action? onStateChanged;
  private static void NotifyStateChanged() => PeopleSharedState.onStateChanged?.Invoke();

  private static PersonGateway? _personGateway = null;
  private static PersonGateway personGateway => 
      PeopleSharedState._personGateway ??= 
      ClientDependencies.Injector.gateways().Person;


  /* ━━━ Selecting ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private static Person? _currentlySelectedPerson = null;

  public delegate void OnSelectedPersonHasChanged(Person newPerson);
  public static OnSelectedPersonHasChanged? onSelectedPersonHasChanged;

  public static Person? currentlySelectedPerson
  {
    get => PeopleSharedState._currentlySelectedPerson;
    set
    {

      PeopleSharedState._currentlySelectedPerson = value;

      if (value is not null)
      {
        PeopleSharedState.onSelectedPersonHasChanged?.Invoke(value);
      }

      PeopleSharedState.NotifyStateChanged();

    }
  }


  /* ━━━ Retrieving ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private static List<Person> _peopleSelection = [];
  public static List<Person> peopleSelection
  {
    get => PeopleSharedState._peopleSelection;
    private set
    {
      PeopleSharedState._peopleSelection = value;
      PeopleSharedState.NotifyStateChanged();
    }
  }


  private static uint _totalPeopleCountInDataSource = 0;
  public static uint totalPeopleCountInDataSource
  {
    get => PeopleSharedState._totalPeopleCountInDataSource;
    private set
    {
      PeopleSharedState._totalPeopleCountInDataSource = value;
      PeopleSharedState.NotifyStateChanged();
    }
  }

  private static uint _totalPeopleCountInSelection = 0;
  public static uint totalPeopleCountInSelection
  {
    get => PeopleSharedState._totalPeopleCountInSelection;
    private set
    {
      PeopleSharedState._totalPeopleCountInSelection = value;
      PeopleSharedState.NotifyStateChanged();
    }
  }

  private static string? _searchingByFullOrPartialNameOrItsSpell = null;

  public static string? searchingByFullOrPartialNameOrItsSpell
  {
    get => PeopleSharedState._searchingByFullOrPartialNameOrItsSpell;
    private set
    {
      PeopleSharedState._searchingByFullOrPartialNameOrItsSpell = value;
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

  public static async System.Threading.Tasks.Task retrievePeopleSelection(
    PersonGateway.SelectionRetrieving.RequestParameters? requestParameters = null,
    bool mustResetSearchingByFullOrPartialNameOrItsSpell = false
  )
  {

    if (PeopleSharedState.isPeopleSelectionBeingRetrievedNow)
    {
      return;
    }


    PeopleSharedState.currentlySelectedPerson = null;
    PeopleSharedState.isWaitingForPeopleSelectionRetrieving = false;
    PeopleSharedState.isPeopleSelectionBeingRetrievedNow = true;
    PeopleSharedState.hasPeopleSelectionRetrievingErrorOccurred = false;

    if (mustResetSearchingByFullOrPartialNameOrItsSpell)
    {
      PeopleSharedState.searchingByFullOrPartialNameOrItsSpell = null;
    }
    else
    {
      PeopleSharedState.searchingByFullOrPartialNameOrItsSpell =
        requestParameters?.SearchingByFullOrPartialNameOrItsSpell ??
        PeopleSharedState.searchingByFullOrPartialNameOrItsSpell;
    }


    PersonGateway.SelectionRetrieving.ResponseData responseData;

    try
    {

      responseData = await PeopleSharedState.personGateway.RetrieveSelection(
        new PersonGateway.SelectionRetrieving.RequestParameters
          { SearchingByFullOrPartialNameOrItsSpell = PeopleSharedState.searchingByFullOrPartialNameOrItsSpell }
      );

    }
    catch (Exception exception)
    {

      PeopleSharedState.hasPeopleSelectionRetrievingErrorOccurred = true;
      PeopleSharedState.isPeopleSelectionBeingRetrievedNow = false;
      
      Debug.WriteLine(exception);

      return;

    }


    PeopleSharedState._peopleSelection = responseData.Items.ToList();
    PeopleSharedState._totalPeopleCountInSelection = responseData.TotalItemsCountInSelection;
    PeopleSharedState._totalPeopleCountInDataSource = responseData.TotalItemsCount;

    PeopleSharedState.isPeopleSelectionBeingRetrievedNow = false;

  }
  
  
  /* ━━━ Adding ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public static async System.Threading.Tasks.Task<Person> addPerson(
    CommonSolution.Gateways.PersonGateway.Adding.RequestData requestData,
    bool mustRetrieveUnfilteredPeopleIfNewOneDoesNotSatisfyingTheCurrentFilteringConditions
  )
  {

    Person newPerson;

    try
    {
      newPerson = await PeopleSharedState.personGateway.Add(requestData);
    } 
    catch (Exception exception)
    {
      throw new DataSubmittingFailedException("Failed to add the new person.", exception); 
    }

    PersonGateway.SelectionRetrieving.RequestParameters currentFiltering = new()
    {
      SearchingByFullOrPartialNameOrItsSpell = PeopleSharedState.searchingByFullOrPartialNameOrItsSpell
    };

    PeopleSharedState.totalPeopleCountInDataSource++;

    if (PersonGateway.IsPersonSatisfyingToFilteringConditions(newPerson, currentFiltering))
    {

      PeopleSharedState.peopleSelection = PersonGateway.Filter(
        PeopleSharedState.peopleSelection.ToArray(), currentFiltering
      ).ToList();
      
      PeopleSharedState.totalPeopleCountInSelection++;

      return newPerson;
      
    }
    
    if (mustRetrieveUnfilteredPeopleIfNewOneDoesNotSatisfyingTheCurrentFilteringConditions)
    {
      _ = PeopleSharedState.retrievePeopleSelection(
        requestParameters: null, 
        mustResetSearchingByFullOrPartialNameOrItsSpell: true
      );
    }

    return newPerson;

  }
  
  
  /* ━━━ Updating ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private static bool _isPersonBeingUpdatedNow = false;
  public static bool isPersonBeingUpdatedNow
  {
    get => PeopleSharedState._isPersonBeingUpdatedNow;
    private set
    {
      PeopleSharedState._isPersonBeingUpdatedNow = value;
      PeopleSharedState.NotifyStateChanged();
    }
  }

  public static async System.Threading.Tasks.Task updatePerson(PersonGateway.Updating.RequestData requestData)
  {

    PeopleSharedState.isPersonBeingUpdatedNow = true;

    try
    {
      await ClientDependencies.Injector.gateways().Person.Update(requestData);
    }
    catch (Exception exception)
    {
      throw new DataSubmittingFailedException(
        $"The error has occurred during the updating of person with ID \"{requestData.ID}\"", exception
      );
    }
    finally
    {
      PeopleSharedState.isPersonBeingUpdatedNow = false;
    }

    
    Person targetPerson = PeopleSharedState.peopleSelection.Single(person => person.ID == requestData.ID);

    targetPerson.familyName = requestData.FamilyName;
    targetPerson.givenName = requestData.GivenName;
    targetPerson.familyNameSpell = requestData.FamilyNameSpell;
    targetPerson.givenNameSpell = requestData.GivenNameSpell;
    targetPerson.gender = requestData.Gender;
    targetPerson.birthYear = requestData.BirthYear;
    targetPerson.birthMonthNumber__numerationFrom1 = requestData.BirthMonthNumber__NumerationFrom1;
    targetPerson.birthDayOfMonth__numerationFrom1 = requestData.BirthDayOfMonth__NumerationFrom1;
    targetPerson.emailAddress = requestData.EmailAddress;
    targetPerson.phoneNumber__digitsOnly = requestData.PhoneNumber__DigitsOnly;

  }
  
  
  /* ━━━ Deleting ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public static async System.Threading.Tasks.Task deletePerson(string targetPersonID)
  {

    try
    {
      await ClientDependencies.Injector.gateways().Person.Delete(targetPersonID);
    }
    catch (Exception exception)
    {
      throw new DataSubmittingFailedException(
        $"Failed to delete the person with ID \"{ targetPersonID }\"", exception
      );
    }

    
    if (targetPersonID == PeopleSharedState.currentlySelectedPerson?.ID) {}

    {
      PeopleSharedState.currentlySelectedPerson = null;
    }
    
    PeopleSharedState.totalPeopleCountInDataSource--;
    
    if (PeopleSharedState.peopleSelection.Any(person => person.ID == targetPersonID))
    {
      PeopleSharedState.totalPeopleCountInSelection--;
    }
    
    PeopleSharedState.peopleSelection.RemoveAll(person => person.ID == targetPersonID);

  }

}
