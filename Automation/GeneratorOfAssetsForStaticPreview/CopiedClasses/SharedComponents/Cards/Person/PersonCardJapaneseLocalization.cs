namespace GeneratorOfAssetsForStaticPreview.CopiedClasses.SharedComponents.Cards.Person;
// namespace Client.SharedComponents.Cards.Person.Localization;


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
