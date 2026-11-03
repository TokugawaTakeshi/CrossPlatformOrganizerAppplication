namespace Client.SharedGUI_Components.Cards.Task.Localizations;


internal abstract record TaskCardLocalization
{

  internal record Badges
  {
    internal required string date { get; init; }
    internal required string dateTime { get; init; }
  }
  
  internal abstract Badges badges { get; init; }
  
}
