namespace Client.SharedGUI_Components.Cards.Task.Localizations;


internal record TaskCardEnglishLocalization : TaskCardLocalization
{

  internal override Badges badges { get; init; } = new()
  {
    date = "Date",
    dateTime = "Date and Time"
  };

}
