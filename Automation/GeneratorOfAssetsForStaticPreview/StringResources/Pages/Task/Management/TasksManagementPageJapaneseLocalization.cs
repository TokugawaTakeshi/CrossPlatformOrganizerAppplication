/* [ !!! ATTENTION !!! ] NO MANUAL EDITING!!!       */
/* This file is being GENERATED REPEATEDLY.         */
/* All manual changes COULD BE LOST AT ANY MOMENT.  */

using GeneratorOfAssetsForStaticPreview.StringResources.Common;

namespace GeneratorOfAssetsForStaticPreview.StringResources.Pages.Task.Management;


internal record TasksManagementPageJapaneseLocalization() : TasksManagementPageLocalization(
  
  pageTitle: "課題管理 ｜ Experimental CSharp Application",
  
  filteringModalDialog: new FilteringModalDialog { title = "課題の絞り込み" },
  
  taskManagerActivationGuidance: "課題の詳細を閲覧する事や編集するにはカードをクリック・タップして下さい。",
  
  successMessages:
  
      new TasksManagementPageLocalization.SuccessMessages
      {
        taskAddingSucceeded = "新規課題が追加されました。",
        taskUpdatingSucceeded = "課題の更新が完了しました。",
        taskDeletingSucceeded = "課題を削除しました。"
      },
  
  errorMessages:
  
      new TasksManagementPageLocalization.ErrorMessages
      {
        taskAddingFailed = CommonEnglishStringResources.SingleInstance.
            buildDataRetrievingOrSubmittingFailedPoliteMessage("新規課題の追加中不具合が発生しました。"),
        taskUpdatingFailed = CommonEnglishStringResources.SingleInstance.
            buildDataRetrievingOrSubmittingFailedPoliteMessage("課題の更新中不具合が発生しました。"),
        taskDeletingFailed = CommonEnglishStringResources.SingleInstance.
          buildDataRetrievingOrSubmittingFailedPoliteMessage("課題の削除中不具合が発生しました。")
      }
  
);