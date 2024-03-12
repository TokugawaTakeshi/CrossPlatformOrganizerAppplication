using Client.Resources.Localizations;


namespace Client.SharedComponents.Viewers.People.Localizations;


public record PeopleViewerJapaneseLocalization : PeopleViewerLocalization
{
  
  internal override SearchBox searchBox { get; init; } = new()
  {
    placeholder = "名義や名前の読み方で検索",
    accessibilityGuidance = "名義や名前の読み方で検索"
  };
  
  internal override Buttons buttons { get; init; } = new()
  {
    personAdding = new SharedStaticStrings.ButtonWithVisibleLabel { label = "人を追加" },
    retryingOfDataRetrieving = new SharedStaticStrings.ButtonWithVisibleLabel { label = "取得再試験" },
    immediateAddingOfFirstPerson = new SharedStaticStrings.ButtonWithVisibleLabel { label = "一名目の人を追加しましょう" },
    resettingOfFiltering = new SharedStaticStrings.ButtonWithVisibleLabel { label = "絞り込みを解除" },
    tasksFiltering = new SharedStaticStrings.ButtonWithVisibleLabel { label = "課題をフィルタリング" }
  };
  
  internal override Errors errors { get; init; } = new()
  {
    tasksRetrieving = new SharedStaticStrings.MessageWithTitleAndDescription
    {
      title = "人一覧取得失敗",
      description = SharedStaticJapaneseStrings.SingleInstance.
        buildDataRetrievingOrSubmittingFailedPoliteMessage(
          "人一覧取得中、不具合が発生しました。"
        )
    }
  };
  
  internal override Guidances guidances { get; init; } = new()
  {
    noItemsAvailable = "現在、人が一名も登録されていません。",
    noItemsFound = "該当する人が見つかりませんでした。"
  };
  
}