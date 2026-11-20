/* [ !!! ATTENTION !!! ] NO MANUAL EDITING!!!       */
/* This file is being GENERATED REPEATEDLY.         */
/* All manual changes COULD BE LOST AT ANY MOMENT.  */

using GeneratorOfAssetsForStaticPreview.StringResources.Common;

namespace GeneratorOfAssetsForStaticPreview.StringResources.SharedGUI_Components.Controls.TasksFilteringPanel;


internal record TasksFilteringPanelJapaneseLocalization() : TasksFilteringPanelLocalization(
  
  titles:
    
      new TasksFilteringPanelLocalization.Titles(
        summaries: "まとめ",
        custom: "カスタム"  
      ),
  
  summaryFolders:
  
      new TasksFilteringPanelLocalization.SummaryFolders(
         
        all: 
          
            new TasksFilteringPanelLocalization.SummaryFolder(
              title: "全課題",
              accessibilityGuidance: "全課題を見る"
            ),
        
        today:
        
            new TasksFilteringPanelLocalization.SummaryFolder(
              title: "本日",
              accessibilityGuidance: "本日に予定された課題を見る"
            ),
        
        overdue:
        
            new TasksFilteringPanelLocalization.SummaryFolder(
              title: "期限切れ",
              accessibilityGuidance: "期限切れの課題を見る"
            ),
        
       byDatesAndTimes:
       
            new TasksFilteringPanelLocalization.SummaryFolder(
              title: "日時別",
              accessibilityGuidance: "日時別の課題を見る"
            ),
       
        byDates:
        
            new TasksFilteringPanelLocalization.SummaryFolder(
              title: "日付別",
              accessibilityGuidance: "日付別の課題を見る"  
            ),
        
        byLocations:
        
            new TasksFilteringPanelLocalization.SummaryFolder(
              title: "場所別",
              accessibilityGuidance: "場所別の課題を見る"
            ),
        
        repeating:
        
            new TasksFilteringPanelLocalization.SummaryFolder(
              title: "繰り返し",
              accessibilityGuidance: "繰り返しの課題を見る"
            )
        
       ),
  
  buttons: 
  
      new TasksFilteringPanelLocalization.Buttons(
        addingOfFirstTaskCustomFolder: new CommonStringResources.ButtonWithVisibleLabel(label: "一件目のフォルダーを追加"),
        retryingOfTasksCustomFoldersRetrieving: new CommonStringResources.ButtonWithVisibleLabel (label: "再取得")  
      ),
  
  errorsMessages: 
  
      new TasksFilteringPanelLocalization.ErrorMessages(
        taskCustomFoldersRetrievingFailed: "課題フォルダーの取得中不具合が発生しました。"
      )
  
);