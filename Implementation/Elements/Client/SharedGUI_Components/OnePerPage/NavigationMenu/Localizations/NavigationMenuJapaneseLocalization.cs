namespace Client.SharedGUI_Components.OnePerPage.NavigationMenu.Localizations;


internal record NavigationMenuJapaneseLocalization : NavigationMenuLocalization
{
 
  internal override Links links { get; } = new()
  {
    tasks = "課題",
    people = "人"
  };

  
}