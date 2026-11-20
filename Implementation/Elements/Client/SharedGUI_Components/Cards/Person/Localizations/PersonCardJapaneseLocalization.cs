namespace Client.SharedGUI_Components.Cards.Person.Localizations;


internal record PersonCardJapaneseLocalization : PersonCardLocalization
{
  internal override Metadata metadata { get; init; } = new()
  {
    name = "名前",
    nameSpell = "名前の読み方",
    emailAddress = "メールアドレス",
    phoneNumber = "電話番号"
  };
}
