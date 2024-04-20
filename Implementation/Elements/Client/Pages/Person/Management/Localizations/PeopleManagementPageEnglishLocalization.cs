// ReSharper disable ReplaceAutoPropertyWithComputedProperty
// To avoid generating a backing field https://stackoverflow.com/a/77935080/4818123


using Client.Resources.Localizations;


namespace Client.Pages.Person.Management.Localizations;


internal record PeopleManagementPageEnglishLocalization : PeopleManagementPageLocalization
{

  internal override string personManagerActivationGuidance { get; } = 
      "Click or tap the person card to view details or edit the dedicated person data.";
  
  internal override SuccessMessages successMessages { get; init; } = new()
  {
    personAddingSucceeded = "Person has been added.",
    personUpdatingSucceeded = "Person has been updated",
    personDeletingSucceeded = "Person has been deleted."
  };
  
  internal override ErrorMessages errorMessages { get; init; } = new()
  {
    personAddingFailed = SharedStaticEnglishStrings.SingleInstance.
        buildDataRetrievingOrSubmittingFailedPoliteMessage("The malfunction has occurred during adding of new person."),
    personUpdatingFailed = SharedStaticEnglishStrings.SingleInstance.
        buildDataRetrievingOrSubmittingFailedPoliteMessage("The malfunction has occurred during updating of person."),
    personDeletingFailed = SharedStaticEnglishStrings.SingleInstance.
      buildDataRetrievingOrSubmittingFailedPoliteMessage("The malfunction has occurred during deleting of person.")
  };
  
}
