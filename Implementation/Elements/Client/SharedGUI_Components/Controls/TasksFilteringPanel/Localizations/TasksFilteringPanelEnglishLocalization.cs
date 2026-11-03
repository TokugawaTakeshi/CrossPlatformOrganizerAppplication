using Client.Resources.Localizations;

namespace Client.SharedGUI_Components.Controls.TasksFilteringPanel.Localizations;


internal record TasksFilteringPanelEnglishLocalization : TasksFilteringPanelLocalization
{
  
  internal override Titles titles { get; init; } = new()
  {
    summaries = "Summaries",
    custom = "Custom"
  };

  internal override SummaryFolders summaryFolders { get; init; } = new()
  {
    all = new SummaryFolder
    {
      title = "All Tasks",
      accessibilityGuidance = "View All Tasks"
    },
    today = new SummaryFolder
    {
      title = "Today",
      accessibilityGuidance = "View Tasks Planned to Today"
    },
    overdue = new SummaryFolder
    {
      title = "Overdue",
      accessibilityGuidance = "View Overdue Tasks"
    },
    byDatesAndTimes = new SummaryFolder
    {
      title = "By Dates and Times",
      accessibilityGuidance = "View Tasks by Dates and Times"
    },
    byDates = new SummaryFolder
    {
      title = "By Dates",
      accessibilityGuidance = "View Tasks by Dates"
    },
    byLocations = new SummaryFolder
    {
      title = "By Locations",
      accessibilityGuidance = "View Tasks by Locations"
    },
    repeating = new SummaryFolder
    {
      title = "Repeating",
      accessibilityGuidance = "View Repeating Tasks"
    }
  };

  internal override Buttons buttons { get; init; } = new()
  {
    addingOfFirstTaskCustomFolder = new CommonStringResources.ButtonWithVisibleLabel { label = "Add the first one" },
    retryingOfTasksCustomFoldersRetrieving = new CommonStringResources.ButtonWithVisibleLabel { label = "Retry" }
  };

  internal override ErrorMessages errorMessages { get; init; } = new()
  {
    taskCustomFoldersRetrievingFailed = CommonEnglishStringResources.SingleInstance.
          buildDataRetrievingOrSubmittingFailedPoliteMessage("The tasks custom folders retrieving failed.")
  };
    
}