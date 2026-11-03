using Client.Resources.Localizations;

namespace Client.SharedGUI_Components.Lists.TasksFolders.Localizations;


internal record TasksFoldersListJapaneseLocalization : TasksFoldersListLocalization
{
  
  /* ━━━ ボタン ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  internal override Buttons buttons { get; init; } = new()
  {
    addingOfNewTaskFolder = new CommonStringResources.ButtonWithVisibleLabel
    {
      label = "新規フォルダー"
    }
  };
  
  
  /* ━━━ アクセシビリティ案内 ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  internal override string loadingStateAccessibilityGuidance { get; init; } = "課題カスタムフォルダーはロード中です。暫くお待ち下さい。";
  
}