using Client.Resources.Localizations;

namespace Client.SharedGUI_Components.Controls.TasksFilteringPanel.Localizations;


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