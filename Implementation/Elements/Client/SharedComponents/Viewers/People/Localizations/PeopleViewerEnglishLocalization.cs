using Client.Resources.Localizations;


namespace Client.SharedComponents.Viewers.People.Localizations;


public record PeopleViewerEnglishLocalization : PeopleViewerLocalization
{
 
  internal override SearchBox searchBox { get; init; } = new()
  {
    placeholder = "Search by name or its spell",
    accessibilityGuidance = "Search by name or its spell"
  };
  
  internal override Buttons buttons { get; init; } = new()
  {
    personAdding = new SharedStaticStrings.ButtonWithVisibleLabel { label = "Add Person" },
    retryingOfDataRetrieving = new SharedStaticStrings.ButtonWithVisibleLabel { label = "Retry to Retrieve" },
    immediateAddingOfFirstPerson = new SharedStaticStrings.ButtonWithVisibleLabel { label = "Let add the first one" },
    resettingOfFiltering = new SharedStaticStrings.ButtonWithVisibleLabel { label = "Reset Filtering" },
    tasksFiltering = new SharedStaticStrings.ButtonWithVisibleLabel { label = "Filter People" }
  };

  internal override Errors errors { get; init; } = new()
  {
    tasksRetrieving = new SharedStaticStrings.MessageWithTitleAndDescription
    {
      title = "People Retrieving Failure",
      description = SharedStaticEnglishStrings.SingleInstance.
        buildDataRetrievingOrSubmittingFailedPoliteMessage(
          "The people selection retrieving has failed."
        )
    }
  };
  
  internal override Guidances guidances { get; init; } = new()
  {
    noItemsAvailable = "No people has been added yet.",
    noItemsFound = "No people matching with filtering conditions."
  };
  
}