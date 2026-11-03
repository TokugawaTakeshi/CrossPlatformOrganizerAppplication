namespace Client.SharedGUI_Components.Cards.Task.Localizations;


internal record TaskCardJapaneseLocalization : TaskCardLocalization
{

  internal override Badges badges { get; init; } = new()
  {
    date = "日付",
    dateTime = "日時"
  };

}
