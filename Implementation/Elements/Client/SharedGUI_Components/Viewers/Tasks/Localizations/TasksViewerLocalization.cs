using Client.Resources.Localizations;

namespace Client.SharedGUI_Components.Viewers.Tasks.Localizations;


internal abstract record TasksViewerLocalization(
  TasksViewerLocalization.SearchBox searchBox,
  TasksViewerLocalization.Buttons buttons,
  TasksViewerLocalization.Errors errors,
  TasksViewerLocalization.Guidances guidances,
  TasksViewerLocalization.AccessibilityGuidances accessibilityGuidances,
  TasksViewerLocalization.Titles titles
)
{

  internal record SearchBox
  (
    string placeholder,
    string accessibilityGuidance
  );
  
  internal record Buttons
  (
    CommonStringResources.ButtonWithVisibleLabel taskAdding,
    CommonStringResources.ButtonWithVisibleLabel retryingOfDataRetrieving,
    CommonStringResources.ButtonWithVisibleLabel immediateAddingOfFirstTask,
    CommonStringResources.ButtonWithVisibleLabel resettingOfFiltering,
    CommonStringResources.ButtonWithVisibleLabel tasksFiltering
  );
  
  internal record Errors(
    CommonStringResources.MessageWithTitleAndDescription tasksRetrieving
  );
  
  internal record Guidances
  (
    string noItemsAvailable,
    string noItemsFound
  );
  
  internal record AccessibilityGuidances 
  (
    string dataRetrievingInProgress
  );
  
  internal record Titles
  (
    string completedTasks
  );
  
}
