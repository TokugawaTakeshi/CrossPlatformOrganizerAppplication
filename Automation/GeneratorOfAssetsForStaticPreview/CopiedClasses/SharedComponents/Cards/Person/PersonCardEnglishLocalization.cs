namespace GeneratorOfAssetsForStaticPreview.CopiedClasses.SharedComponents.Cards.Person;
// namespace Client.SharedComponents.Cards.Person.Localization;


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
