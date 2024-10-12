/* [ !!! ATTENTION !!! ] NO MANUAL EDITING!!!       */
/* This file is being GENERATED REPEATEDLY.         */
/* All manual changes COULD BE LOST AT ANY MOMENT.  */

using GeneratorOfAssetsForStaticPreview.StringResources.Common;

namespace GeneratorOfAssetsForStaticPreview.StringResources.SharedGUI_Components.Managers.TasksFolders;


internal record TasksFoldersManagerJapaneseLocalization : TasksFoldersManagerLocalization
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