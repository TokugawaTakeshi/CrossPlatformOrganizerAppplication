// ReSharper disable ReplaceAutoPropertyWithComputedProperty
// To avoid generating a backing field https://stackoverflow.com/a/77935080/4818123

using Client.Resources.Localizations;


namespace Client.Pages.Person.Management.Localizations;


internal record PeopleManagementPageJapaneseLocalization : PeopleManagementPageLocalization
{

  internal override string personManagerActivationGuidance { get; } = 
      "人の詳細を閲覧する事や編集するにはカードをクリック・タップして下さい。";
  
  internal override SuccessMessages successMessages { get; init; } = new()
  {
    personAddingSucceeded = "新規人が追加されました。",
    personUpdatingSucceeded = "人の更新が完了しました。",
    personDeletingSucceeded = "人を削除しました。"
  };
  
  internal override ErrorMessages errorMessages { get; init; } = new()
  {
    personAddingFailed = SharedStaticJapaneseStrings.SingleInstance.
        buildDataRetrievingOrSubmittingFailedPoliteMessage("新規人の追加中不具合が発生しました。"),
    personUpdatingFailed = SharedStaticJapaneseStrings.SingleInstance.
        buildDataRetrievingOrSubmittingFailedPoliteMessage("人の更新中不具合が発生しました。"),
    personDeletingFailed = SharedStaticJapaneseStrings.SingleInstance.
      buildDataRetrievingOrSubmittingFailedPoliteMessage("人の削除中不具合が発生しました。")
  };
  
}