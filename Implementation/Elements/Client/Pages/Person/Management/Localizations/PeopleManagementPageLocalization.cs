namespace Client.Pages.Person.Management.Localizations;


internal abstract record PeopleManagementPageLocalization
{

  internal abstract string personManagerActivationGuidance { get; }
  
  
  internal record SuccessMessages
  {
    internal required string personAddingSucceeded { get; init; }
    internal required string personUpdatingSucceeded { get; init; }
    internal required string personDeletingSucceeded { get; init; }
  }
  
  internal abstract SuccessMessages successMessages { get; init; }
  
  
  internal record ErrorMessages
  {
    internal required string personAddingFailed { get; init; }
    internal required string personUpdatingFailed { get; init; }
    internal required string personDeletingFailed { get; init; }
  }
  
  internal abstract ErrorMessages errorMessages { get; init; }
  
}
