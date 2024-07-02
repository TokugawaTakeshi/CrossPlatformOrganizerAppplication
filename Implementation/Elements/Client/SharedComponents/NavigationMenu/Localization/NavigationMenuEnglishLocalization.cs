namespace Client.SharedComponents.NavigationMenu.Localization;


internal record NavigationMenuEnglishLocalization : NavigationMenuLocalization
{
 
  internal override Links links { get; } = new()
  {
    tasks = "Tasks",
    people = "People"
  };
  
}