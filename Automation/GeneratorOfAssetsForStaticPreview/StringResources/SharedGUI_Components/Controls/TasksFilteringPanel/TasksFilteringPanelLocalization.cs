/* [ !!! ATTENTION !!! ] NO MANUAL EDITING!!!       */
/* This file is being GENERATED REPEATEDLY.         */
/* All manual changes COULD BE LOST AT ANY MOMENT.  */

using GeneratorOfAssetsForStaticPreview.StringResources.Common;

namespace GeneratorOfAssetsForStaticPreview.StringResources.SharedGUI_Components.Controls.TasksFilteringPanel;


internal abstract record TasksFilteringPanelLocalization
{
  
  /* ━━━ Titles ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  internal record Titles
  {
    internal required string summaries { get; init; }
    internal required string custom { get; init; }
  }
  
  internal abstract Titles titles { get; init; }


  /* ━━━ Summary Folders ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  internal record SummaryFolder
  {
    internal required string title { get; init; }
    internal required string accessibilityGuidance { get; init; }
  }
  
  internal record SummaryFolders
  {
    internal required SummaryFolder all { get; init; }
    internal required SummaryFolder today { get; init; }
    internal required SummaryFolder overdue { get; init; }
    internal required SummaryFolder byDatesAndTimes { get; init; }
    internal required SummaryFolder byDates { get; init; }
    internal required SummaryFolder byLocations { get; init; }
    internal required SummaryFolder repeating { get; init; }
  }
  
  internal abstract SummaryFolders summaryFolders { get; init; }

  
  /* ━━━ Buttons ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  internal abstract Buttons buttons { get; init; }
  
  internal record Buttons
  {
    internal required CommonStringResources.ButtonWithVisibleLabel retryingOfTasksCustomFoldersRetrieving { get; init;  }
    internal required CommonStringResources.ButtonWithVisibleLabel addingOfFirstTaskCustomFolder { get; init;  }
  }
  
  
  /* ━━━ Errors Messages ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  internal record ErrorMessages
  {
    internal required string taskCustomFoldersRetrievingFailed { get; init; }
  }
  
  internal abstract ErrorMessages errorMessages { get; init; }

}