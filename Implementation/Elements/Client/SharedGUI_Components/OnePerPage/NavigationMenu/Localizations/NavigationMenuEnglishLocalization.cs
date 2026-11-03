namespace Client.SharedGUI_Components.OnePerPage.NavigationMenu.Localizations;


internal record NavigationMenuEnglishLocalization : NavigationMenuLocalization
{
 
  internal override Links links { get; } = new()
  {
    tasks = "Tasks",
    people = "People"
  };
  
}