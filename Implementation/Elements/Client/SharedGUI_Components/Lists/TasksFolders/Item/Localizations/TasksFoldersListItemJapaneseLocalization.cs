namespace Client.SharedGUI_Components.Lists.TasksFolders.Item.Localizations;


internal record TasksFoldersListItemJapaneseLocalization : TasksFoldersListItemLocalization
{

  /* ━━━ ボタン ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  internal override Buttons buttons { get; init; } = new()
  {
    
    tasksFolderCollapsing =new Buttons.TasksFolderCollapsing
    {
      generateAccessibilityGuidance = templateVariables => 
          $"課題フォルダー「{ templateVariables.tasksFolderLabel }」を折りたたむ"
    },
    
    tasksFolderExpanding = new Buttons.TasksFolderExpanding
    {
      generateAccessibilityGuidance = templateVariables => 
          $"課題フォルダー「{ templateVariables.tasksFolderLabel }」を展開する"
    },
    
    retrievingOfTasksOfSpecificCustomFolder = new Buttons.RetrievingOfTasksOfSpecificCustomFolder
    {
      generateAccessibilityGuidance = templateVariables => 
          $"課題フォルダー「{ templateVariables.tasksFolderLabel }」の課題を取得する"
    },
    
    renamingOfTasksFolder = new Buttons.RenamingOfTasksFolder
    {
      label = "名前変更",
      generateAccessibilityGuidance = templateVariables => 
          $"課題フォルダー「{ templateVariables.tasksFolderLabel }」の名前を変更する"
    }, 
    
    deletingOfTasksFolder = new Buttons.DeletingOfTasksFolder
    {
      label = "削除",
      generateAccessibilityGuidance = templateVariables => 
          $"課題フォルダー「{ templateVariables.tasksFolderLabel }」を削除する"
    }
    
  };


  /* ━━━ テキストボックス ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  internal override TextBoxes textBoxes { get; init; } = new()
  {
   
    tasksFolderAdding = new TextBoxes.TasksFolderAdding
    {
      accessibilityGuidance = "新しいフォルダーの名前を入力して下さい。"
    },
    
    tasksFolderEditing = new TextBoxes.TasksFolderEditing
    {
      generateAccessibilityGuidance = templateVariables => 
          $"以前の名前の「{ templateVariables.tasksFolderInitialLabel }」フォルダーの新しい名前を入力して下さい。"
    }

  };
  
}