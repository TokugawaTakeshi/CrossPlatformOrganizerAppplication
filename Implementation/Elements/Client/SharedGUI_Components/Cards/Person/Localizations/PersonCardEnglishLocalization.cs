namespace Client.SharedGUI_Components.Cards.Person.Localizations;


internal record PersonCardEnglishLocalization : PersonCardLocalization
{
  internal override Metadata metadata { get; init; } = new()
  {
    name = "Name",
    nameSpell = "Name Spell",
    emailAddress = "Email Address",
    phoneNumber = "Phone Number"
  };
}
