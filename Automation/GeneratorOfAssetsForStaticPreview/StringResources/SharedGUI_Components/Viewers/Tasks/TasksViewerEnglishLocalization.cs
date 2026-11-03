/* [ !!! ATTENTION !!! ] NO MANUAL EDITING!!!       */
/* This file is being GENERATED REPEATEDLY.         */
/* All manual changes COULD BE LOST AT ANY MOMENT.  */

using GeneratorOfAssetsForStaticPreview.StringResources.Common;

namespace GeneratorOfAssetsForStaticPreview.StringResources.SharedGUI_Components.Viewers.Tasks;


internal record TasksViewerEnglishLocalization : TasksViewerLocalization
{
  
  internal override SearchBox searchBox { get; init; } = new()
  {
    placeholder = "Search by Title or Description",
    accessibilityGuidance = "Search by task title or description"
  };
  
  internal override Buttons buttons { get; init; } = new()
  {
    taskAdding = new CommonStringResources.ButtonWithVisibleLabel { label = "Add Task" },
    retryingOfDataRetrieving = new CommonStringResources.ButtonWithVisibleLabel { label = "Retry to Retrieve" },
    immediateAddingOfFirstTask = new CommonStringResources.ButtonWithVisibleLabel { label = "Let add the first one" },
    resettingOfFiltering = new CommonStringResources.ButtonWithVisibleLabel { label = "Reset Filtering" },
    tasksFiltering = new CommonStringResources.ButtonWithVisibleLabel { label = "Filter Tasks" }
  };

  internal override Errors errors { get; init; } = new()
  {
    tasksRetrieving = new CommonStringResources.MessageWithTitleAndDescription
    {
      title = "Tasks Retrieving Failure",
      description = CommonEnglishStringResources.SingleInstance.
          buildDataRetrievingOrSubmittingFailedPoliteMessage(
            "The tasks selection retrieving has failed."
          )
    }
  };
  
  internal override Guidances guidances { get; init; } = new()
  {
    noItemsAvailable = "No tasks has been added yet.",
    noItemsFound = "No tasks matching with filtering conditions."
  };
  
  internal override AccessibilityGuidances accessibilityGuidances { get; init; } = new()
  {
    dataRetrievingInProgress = "Data retrieving in progress. Please wait."
  };

  internal override Titles titles { get; init; } = new()
  {
    completedTasks = "Completes Tasks"
  };
  
}