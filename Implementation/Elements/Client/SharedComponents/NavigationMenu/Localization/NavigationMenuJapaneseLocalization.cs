namespace Client.SharedComponents.NavigationMenu.Localization;


internal record NavigationMenuJapaneseLocalization : NavigationMenuLocalization
{
 
  internal override Links links { get; } = new()
  {
    tasks = "課題",
    people = "人"
  };

  
}