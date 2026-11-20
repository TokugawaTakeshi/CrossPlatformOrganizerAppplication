using Client.Resources.Localizations;

namespace Client.SharedGUI_Components.Lists.TasksFolders.Localizations;


internal record TasksFoldersListJapaneseLocalization() : TasksFoldersListLocalization(
  
  buttons: 
      new TasksFoldersListLocalization.Buttons(
        addingOfNewTaskFolder: new CommonStringResources.ButtonWithVisibleLabel(label: "新規フォルダー")
      ),
  
  loadingStateAccessibilityGuidance: "課題カスタムフォルダーはロード中です。暫くお待ち下さい。"
      
);
