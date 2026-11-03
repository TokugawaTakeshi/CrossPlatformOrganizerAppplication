/* [ !!! ATTENTION !!! ] NO MANUAL EDITING!!!       */
/* This file is being GENERATED REPEATEDLY.         */
/* All manual changes COULD BE LOST AT ANY MOMENT.  */

using GeneratorOfAssetsForStaticPreview.StringResources.Common;

namespace GeneratorOfAssetsForStaticPreview.StringResources.SharedGUI_Components.Viewers.Tasks;


internal record TasksViewerJapaneseLocalization : TasksViewerLocalization
{
  
  internal override SearchBox searchBox { get; init; } = new()
  {
    placeholder = "課題の見出しや記述で検索",
    accessibilityGuidance = "課題の見出しや記述で検索"
  };
  
  internal override Buttons buttons { get; init; } = new()
  {
    taskAdding = new CommonStringResources.ButtonWithVisibleLabel { label = "課題追加" },
    retryingOfDataRetrieving = new CommonStringResources.ButtonWithVisibleLabel { label = "取得再試験" },
    immediateAddingOfFirstTask = new CommonStringResources.ButtonWithVisibleLabel { label = "一件目の課題を追加しましょう" },
    resettingOfFiltering = new CommonStringResources.ButtonWithVisibleLabel { label = "絞り込みを解除" },
    tasksFiltering = new CommonStringResources.ButtonWithVisibleLabel { label = "課題をフィルタリング" }
  };
  
  internal override Errors errors { get; init; } = new()
  {
    tasksRetrieving = new CommonStringResources.MessageWithTitleAndDescription
    {
      title = "課題一覧取得失敗",
      description = CommonJapaneseStringResources.SingleInstance.
        buildDataRetrievingOrSubmittingFailedPoliteMessage(
          "課題一覧取得中、不具合が発生しました。"
        )
    }
  };
  
  internal override Guidances guidances { get; init; } = new()
  {
    noItemsAvailable = "現在、課題が一件も作られていません。",
    noItemsFound = "該当する課題が見つかりませんでした。"
  };
  
  internal override AccessibilityGuidances accessibilityGuidances { get; init; } = new()
  {
    dataRetrievingInProgress = "データが取得中です。暫くお待ち下さい。"
  };

  internal override Titles titles { get; init; } = new()
  {
    completedTasks = "完了した課題"
  };
  
}