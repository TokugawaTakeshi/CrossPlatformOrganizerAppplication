namespace Client.SharedGUI_Components.Cards.Task.Localizations;


internal abstract record TaskCardLocalization(
  TaskCardLocalization.Badges badges
)
{

  internal record Badges(
    string date,
    string dateTime
  );
  
}
