/* [ !!! ATTENTION !!! ] NO MANUAL EDITING!!!       */
/* This file is being GENERATED REPEATEDLY.         */
/* All manual changes COULD BE LOST AT ANY MOMENT.  */

using GeneratorOfAssetsForStaticPreview.StringResources.Common;

namespace GeneratorOfAssetsForStaticPreview.StringResources.SharedGUI_Components.Controls.TasksFilteringPanel;


internal record TasksFilteringPanelEnglishLocalization() : TasksFilteringPanelLocalization(
  
  titles:
    
      new TasksFilteringPanelLocalization.Titles(
        summaries: "Summaries",
        custom: "Custom"  
      ),
  
  summaryFolders:
  
      new TasksFilteringPanelLocalization.SummaryFolders(
         
        all: 
          
            new TasksFilteringPanelLocalization.SummaryFolder(
              title: "All Tasks",
              accessibilityGuidance: "View All Tasks"
            ),
        
        today:
        
            new TasksFilteringPanelLocalization.SummaryFolder(
              title: "Today",
              accessibilityGuidance: "View Tasks Planned to Today"
            ),
        
        overdue:
        
            new TasksFilteringPanelLocalization.SummaryFolder(
              title: "Overdue",
              accessibilityGuidance: "View Overdue Tasks"
            ),
        
       byDatesAndTimes:
       
            new TasksFilteringPanelLocalization.SummaryFolder(
              title: "By Dates and Times",
              accessibilityGuidance: "View Tasks by Dates and Times"
            ),
       
        byDates:
        
            new TasksFilteringPanelLocalization.SummaryFolder(
              title: "By Dates",
              accessibilityGuidance: "View Tasks by Dates"
            ),
        
        byLocations:
        
            new TasksFilteringPanelLocalization.SummaryFolder(
              title: "By Locations",
              accessibilityGuidance: "View Tasks by Locations"
            ),
        
        repeating:
        
            new TasksFilteringPanelLocalization.SummaryFolder(
              title: "Repeating",
              accessibilityGuidance: "View Repeating Tasks"
            )
        
       ),
  
  buttons: 
  
      new TasksFilteringPanelLocalization.Buttons(
        addingOfFirstTaskCustomFolder: new CommonStringResources.ButtonWithVisibleLabel(label: "Add the first one"),
        retryingOfTasksCustomFoldersRetrieving: new CommonStringResources.ButtonWithVisibleLabel (label: "Retry")  
      ),
  
  errorsMessages: 
  
      new TasksFilteringPanelLocalization.ErrorMessages(
        taskCustomFoldersRetrievingFailed: "The tasks custom folders retrieving failed."
      )
  
);