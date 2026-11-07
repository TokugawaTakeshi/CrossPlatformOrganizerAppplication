using Client.Resources.Localizations;

namespace Client.SharedGUI_Components.Viewers.Tasks.Localizations;


internal record TasksViewerJapaneseLocalization() : TasksViewerLocalization(
 
  searchBox:
  
      new TasksViewerLocalization.SearchBox
      {
        placeholder = "課題の見出しや記述で検索",
        accessibilityGuidance = "課題の見出しや記述で検索"
      },
  
  buttons:
  
      new TasksViewerLocalization.Buttons
      {
        taskAdding = new CommonStringResources.ButtonWithVisibleLabel { label = "課題追加" },
        retryingOfDataRetrieving = new CommonStringResources.ButtonWithVisibleLabel { label = "取得再試験" },
        immediateAddingOfFirstTask = new CommonStringResources.ButtonWithVisibleLabel { label = "一件目の課題を追加しましょう" },
        resettingOfFiltering = new CommonStringResources.ButtonWithVisibleLabel { label = "絞り込みを解除" },
        tasksFiltering = new CommonStringResources.ButtonWithVisibleLabel { label = "課題をフィルタリング" }    
      },
  
  errors:
  
      new TasksViewerLocalization.Errors
      {
        tasksRetrieving = new CommonStringResources.MessageWithTitleAndDescription
        {
          title = "課題一覧取得失敗",
          description = CommonJapaneseStringResources.SingleInstance.
              buildDataRetrievingOrSubmittingFailedPoliteMessage("課題一覧取得中、不具合が発生しました。")
        }  
      },
  
  guidances:
  
      new TasksViewerLocalization.Guidances
      {
        noItemsAvailable = "現在、課題が一件も作られていません。",
        noItemsFound = "該当する課題が見つかりませんでした。"
      },
  
  accessibilityGuidances:
  
      new TasksViewerLocalization.AccessibilityGuidances
      {
        dataRetrievingInProgress = "データが取得中です。暫くお待ち下さい。"
      },
  
  titles:
  
      new TasksViewerLocalization.Titles
      {
        completedTasks = "完了した課題"
      }
  
);