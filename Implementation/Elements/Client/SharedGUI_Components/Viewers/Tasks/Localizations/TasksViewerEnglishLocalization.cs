using Client.Resources.Localizations;

namespace Client.SharedGUI_Components.Viewers.Tasks.Localizations;


internal record TasksViewerEnglishLocalization() : TasksViewerLocalization(
  
  searchBox:
  
      new TasksViewerLocalization.SearchBox
      {
        placeholder = "Search by Title or Description",
        accessibilityGuidance = "Search by task title or description"
      },
  
  buttons:
  
      new TasksViewerLocalization.Buttons
      {
        taskAdding = new CommonStringResources.ButtonWithVisibleLabel { label = "Add Task" },
        retryingOfDataRetrieving = new CommonStringResources.ButtonWithVisibleLabel { label = "Retry to Retrieve" },
        immediateAddingOfFirstTask = new CommonStringResources.ButtonWithVisibleLabel { label = "Let add the first one" },
        resettingOfFiltering = new CommonStringResources.ButtonWithVisibleLabel { label = "Reset Filtering" },
        tasksFiltering = new CommonStringResources.ButtonWithVisibleLabel { label = "Filter Tasks" }    
      },
  
  errors:
  
      new TasksViewerLocalization.Errors
      {
        tasksRetrieving = new CommonStringResources.MessageWithTitleAndDescription
        {
          title = "Tasks Retrieving Failure",
          description = CommonEnglishStringResources.SingleInstance.
              buildDataRetrievingOrSubmittingFailedPoliteMessage("The tasks selection retrieving has failed.")
        }  
      },
  
  guidances:
  
      new TasksViewerLocalization.Guidances
      {
        noItemsAvailable = "No tasks has been added yet.",
        noItemsFound = "No tasks matching with filtering conditions."
      },
  
  accessibilityGuidances:
  
      new TasksViewerLocalization.AccessibilityGuidances
      {
        dataRetrievingInProgress = "Data retrieving in progress. Please wait."
      },
  
  titles:
  
      new TasksViewerLocalization.Titles
      {
        completedTasks = "Completes Tasks"
      }
  
);
