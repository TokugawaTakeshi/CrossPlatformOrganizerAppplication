namespace Client.SharedGUI_Components.Cards.Person.Localizations;


internal abstract record PersonCardLocalization(
  PersonCardLocalization.TableHeadings tableHeadings
)
{
  
  internal record TableHeadings(
    string name,
    string nameSpell,
    string emailAddress,
    string phoneNumber
  );
  
}