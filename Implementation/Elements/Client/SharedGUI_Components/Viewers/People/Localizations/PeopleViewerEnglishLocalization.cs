using Client.Resources.Localizations;

namespace Client.SharedGUI_Components.Viewers.People.Localizations;


public record PeopleViewerEnglishLocalization : PeopleViewerLocalization
{
 
  internal override SearchBox searchBox { get; init; } = new()
  {
    placeholder = "Search by name or its spell",
    accessibilityGuidance = "Search by name or its spell"
  };
  
  internal override Buttons buttons { get; init; } = new()
  {
    personAdding = new CommonStringResources.ButtonWithVisibleLabel { label = "Add Person" },
    retryingOfDataRetrieving = new CommonStringResources.ButtonWithVisibleLabel { label = "Retry to Retrieve" },
    immediateAddingOfFirstPerson = new CommonStringResources.ButtonWithVisibleLabel { label = "Let add the first one" },
    resettingOfFiltering = new CommonStringResources.ButtonWithVisibleLabel { label = "Reset Filtering" },
    peopleFiltering = new CommonStringResources.ButtonWithVisibleLabel { label = "Filter People" }
  };

  internal override Errors errors { get; init; } = new()
  {
    peopleRetrieving = new CommonStringResources.MessageWithTitleAndDescription
    {
      title = "People Retrieving Failure",
      description = CommonEnglishStringResources.SingleInstance.
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
  
  internal override AccessibilityGuidances accessibilityGuidances { get; init; } = new()
  {
    dataRetrievingInProgress = "Data retrieving in progress. Please wait."
  };
  
}