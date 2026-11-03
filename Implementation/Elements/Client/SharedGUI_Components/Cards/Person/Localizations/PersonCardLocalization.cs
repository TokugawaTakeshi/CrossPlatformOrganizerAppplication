namespace Client.SharedGUI_Components.Cards.Person.Localizations;


internal abstract record PersonCardLocalization
{
  
  internal record Metadata
  {
    internal required string name { get; init; }
    internal required string nameSpell { get; init; }
    internal required string emailAddress { get; init; }
    internal required string phoneNumber { get; init; }
  }
  
  internal abstract Metadata metadata { get; init; }
  
}
