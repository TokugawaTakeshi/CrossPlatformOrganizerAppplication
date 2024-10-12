/* [ !!! ATTENTION !!! ] NO MANUAL EDITING!!!       */
/* This file is being GENERATED REPEATEDLY.         */
/* All manual changes COULD BE LOST AT ANY MOMENT.  */

using GeneratorOfAssetsForStaticPreview.StringResources.Common;

namespace GeneratorOfAssetsForStaticPreview.StringResources.SharedGUI_Components.Viewers.Tasks;


internal abstract record class TasksViewerLocalization
{

  internal abstract SearchBox searchBox { get; init; }
  
  internal record SearchBox
  {
    internal required string placeholder { get; init; }
    internal required string accessibilityGuidance { get; init; }
  }
  
  
  internal abstract Buttons buttons { get; init; } 
  
  internal record Buttons
  {
    internal required CommonStringResources.ButtonWithVisibleLabel taskAdding { get; init; }
    internal required CommonStringResources.ButtonWithVisibleLabel retryingOfDataRetrieving { get; init; }
    internal required CommonStringResources.ButtonWithVisibleLabel immediateAddingOfFirstTask { get; init; }
    internal required CommonStringResources.ButtonWithVisibleLabel resettingOfFiltering { get; init; }
    internal required CommonStringResources.ButtonWithVisibleLabel tasksFiltering { get; init; }
  }

  
  internal abstract Errors errors { get; init; }
  
  internal record Errors
  {
    internal required CommonStringResources.MessageWithTitleAndDescription tasksRetrieving { get; init; }
  }

  
  internal abstract Guidances guidances { get; init; }
  
  internal record Guidances
  {
    internal required string noItemsAvailable { get; init; }
    internal required string noItemsFound { get; init; }
  }


  internal abstract AccessibilityGuidances accessibilityGuidances { get; init; }
  
  internal record AccessibilityGuidances 
  {
    internal required string dataRetrievingInProgress { get; init; }
  }
  
  
  internal abstract Titles titles { get; init; }

  internal record Titles
  {
    internal required string completedTasks { get; init; }
  }
  
}