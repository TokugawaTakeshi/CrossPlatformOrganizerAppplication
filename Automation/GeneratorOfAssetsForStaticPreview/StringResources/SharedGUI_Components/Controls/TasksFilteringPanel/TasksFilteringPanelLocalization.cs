/* [ !!! ATTENTION !!! ] NO MANUAL EDITING!!!       */
/* This file is being GENERATED REPEATEDLY.         */
/* All manual changes COULD BE LOST AT ANY MOMENT.  */

using GeneratorOfAssetsForStaticPreview.StringResources.Common;

namespace GeneratorOfAssetsForStaticPreview.StringResources.SharedGUI_Components.Controls.TasksFilteringPanel;


internal abstract record TasksFilteringPanelLocalization (
  TasksFilteringPanelLocalization.Titles titles,
  TasksFilteringPanelLocalization.SummaryFolders summaryFolders,
  TasksFilteringPanelLocalization.Buttons buttons,
  TasksFilteringPanelLocalization.ErrorMessages errorsMessages
) 
{
  
  /* ━━━ Titles ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  internal record Titles (
    string summaries,
    string custom
  );


  /* ━━━ Summary Folders ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  internal record SummaryFolder(
    string title,
    string accessibilityGuidance
  );
  
  internal record SummaryFolders(
    TasksFilteringPanelLocalization.SummaryFolder all,
    TasksFilteringPanelLocalization.SummaryFolder today,
    TasksFilteringPanelLocalization.SummaryFolder overdue,
    TasksFilteringPanelLocalization.SummaryFolder byDatesAndTimes,
    TasksFilteringPanelLocalization.SummaryFolder byDates,
    TasksFilteringPanelLocalization.SummaryFolder byLocations,
    TasksFilteringPanelLocalization.SummaryFolder repeating
  );

  
  /* ━━━ Buttons ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  internal record Buttons(
    CommonStringResources.ButtonWithVisibleLabel retryingOfTasksCustomFoldersRetrieving,
    CommonStringResources.ButtonWithVisibleLabel addingOfFirstTaskCustomFolder
  );
  
  
  /* ━━━ Errors Messages ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  internal record ErrorMessages(string taskCustomFoldersRetrievingFailed);

}