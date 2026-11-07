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
  {
    internal required string placeholder { get; init; }
    internal required string accessibilityGuidance { get; init; }
  }
  
  internal record Buttons
  {
    internal required CommonStringResources.ButtonWithVisibleLabel taskAdding { get; init; }
    internal required CommonStringResources.ButtonWithVisibleLabel retryingOfDataRetrieving { get; init; }
    internal required CommonStringResources.ButtonWithVisibleLabel immediateAddingOfFirstTask { get; init; }
    internal required CommonStringResources.ButtonWithVisibleLabel resettingOfFiltering { get; init; }
    internal required CommonStringResources.ButtonWithVisibleLabel tasksFiltering { get; init; }
  }
  
  internal record Errors
  {
    internal required CommonStringResources.MessageWithTitleAndDescription tasksRetrieving { get; init; }
  }
  
  internal record Guidances
  {
    internal required string noItemsAvailable { get; init; }
    internal required string noItemsFound { get; init; }
  }
  
  internal record AccessibilityGuidances 
  {
    internal required string dataRetrievingInProgress { get; init; }
  }
  
  internal record Titles
  {
    internal required string completedTasks { get; init; }
  }
  
}
