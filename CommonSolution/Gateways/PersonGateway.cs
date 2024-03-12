using CommonSolution.Fundamentals;
using Person = CommonSolution.Entities.Person;


namespace CommonSolution.Gateways;


public abstract class PersonGateway
{

  /* ━━━ Retrieving ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public abstract Task<Person[]> RetrieveAll();
  
  public abstract Task<SelectionRetrieving.ResponseData> RetrieveSelection(
    SelectionRetrieving.RequestParameters? requestParameters
  );
  
  public abstract class SelectionRetrieving
  {
    
    public record RequestParameters
    {
      public string? SearchingByFullOrPartialNameOrItsSpell { get; init; }
    }

    public record ResponseData
    {
      public required uint TotalItemsCount;
      public required uint TotalItemsCountInSelection;
      public required Person[] Items;
    }
    
  }
  
  
  /* ─── Filtering & Arranging ────────────────────────────────────────────────────────────────────────────────────── */
  public static Person[] Filter(
    Person[] people, SelectionRetrieving.RequestParameters? filtering
  )
  {
    
    Person[] workpiece = people;

    if (!String.IsNullOrEmpty(filtering?.SearchingByFullOrPartialNameOrItsSpell))
    {
      workpiece = workpiece.
        Where(
          (Person person) => 
            person.familyName.Contains(filtering.SearchingByFullOrPartialNameOrItsSpell) ||
            (person.givenName?.Contains(filtering.SearchingByFullOrPartialNameOrItsSpell) ?? false) ||
            (person.familyNameSpell?.Contains(filtering.SearchingByFullOrPartialNameOrItsSpell) ?? false) ||
            (person.givenNameSpell?.Contains(filtering.SearchingByFullOrPartialNameOrItsSpell) ?? false)
        ).
        ToArray();
    }

    return workpiece;

  }
  
  public static bool IsPersonSatisfyingToFilteringConditions(
    Person person, SelectionRetrieving.RequestParameters filtering
  )
  {
    return PersonGateway.Filter([ person ], filtering).Length == 1;
  }

  
  /* ━━━ Adding ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public abstract Task<Person> Add(Adding.RequestData requestData);

  public abstract class Adding
  {
    
    public struct RequestData
    {
      public required string FamilyName { get; init; }
      public string? GivenName { get; init; }
      public string? FamilyNameSpell { get; init; }
      public string? GivenNameSpell { get; init; }
      public Genders? Gender { get; init; }
      public string? AvatarURI { get; init; }
      public ushort? BirthYear { get; set; }
      public byte? BirthMonthNumber__NumerationFrom1 { get; set; }
      public byte? BirthDayOfMonth__NumerationFrom1 { get; set; }
      public string? EmailAddress { get; init; }
      public string? PhoneNumber__DigitsOnly { get; init; }
    }
    
  }
  
  
  /* ━━━ Updating ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public abstract System.Threading.Tasks.Task<Person> Update(Updating.RequestData requestData);

  public abstract class Updating
  {
    public struct RequestData
    {
      public required string ID { get; set; }
      public required string FamilyName { get; init; }
      public string? GivenName { get; init; }
      public string? FamilyNameSpell { get; init; }
      public string? GivenNameSpell { get; init; }
      public Genders? Gender { get; init; }
      public string? AvatarURI { get; init; }
      public ushort? BirthYear { get; set; }
      public byte? BirthMonthNumber__NumerationFrom1 { get; set; }
      public byte? BirthDayOfMonth__NumerationFrom1 { get; set; }
      public string? EmailAddress { get; init; }
      public string? PhoneNumber__DigitsOnly { get; init; }
    }
  }
  
  /* ━━━ Deleting ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public abstract Task Delete(string targetPersonID);
  
}
