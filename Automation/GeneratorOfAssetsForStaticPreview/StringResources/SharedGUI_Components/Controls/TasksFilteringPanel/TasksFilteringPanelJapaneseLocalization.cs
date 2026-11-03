/* [ !!! ATTENTION !!! ] NO MANUAL EDITING!!!       */
/* This file is being GENERATED REPEATEDLY.         */
/* All manual changes COULD BE LOST AT ANY MOMENT.  */

using GeneratorOfAssetsForStaticPreview.StringResources.Common;

namespace GeneratorOfAssetsForStaticPreview.StringResources.SharedGUI_Components.Controls.TasksFilteringPanel;


internal record TasksFilteringPanelJapaneseLocalization : TasksFilteringPanelLocalization
{

  internal override Titles titles { get; init; } = new()
  {
    summaries = "まとめ",
    custom = "カスタム"
  };
  
  internal override SummaryFolders summaryFolders { get; init; } = new()
  {
    all = new SummaryFolder
    {
      title = "全課題",
      accessibilityGuidance = "全課題を見る"
    },
    today = new SummaryFolder
    {
      title = "本日",
      accessibilityGuidance = "本日に予定された課題を見る"
    },
    overdue = new SummaryFolder
    {
      title = "期限切れ",
      accessibilityGuidance = "期限切れの課題を見る"
    },
    byDatesAndTimes = new SummaryFolder
    {
      title = "日時別",
      accessibilityGuidance = "日時別の課題を見る"
    },
    byDates = new SummaryFolder
    {
      title = "日付別",
      accessibilityGuidance = "日付別の課題を見る"
    },
    byLocations = new SummaryFolder
    {
      title = "場所別",
      accessibilityGuidance = "場所別の課題を見る"
    },
    repeating = new SummaryFolder
    {
      title = "繰り返し",
      accessibilityGuidance = "繰り返しの課題を見る"
    }
  };
  
  internal override Buttons buttons { get; init; } = new()
  {
    addingOfFirstTaskCustomFolder = new CommonStringResources.ButtonWithVisibleLabel { label = "一件目のフォルダーを追加" },
    retryingOfTasksCustomFoldersRetrieving = new CommonStringResources.ButtonWithVisibleLabel { label = "再取得" }
  };
  
  internal override ErrorMessages errorMessages { get; init; } = new()
  {
    taskCustomFoldersRetrievingFailed = CommonJapaneseStringResources.SingleInstance.
        buildDataRetrievingOrSubmittingFailedPoliteMessage("課題フォルダーの取得中不具合が発生しました。")
  };

}