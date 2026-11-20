namespace Client.SharedGUI_Components.OnePerPage.NavigationMenu.Localizations;


internal abstract record NavigationMenuLocalization
{
  internal record Links
  {
    internal required string tasks { get; init; }
    internal required string people { get; init; }
  }
  
  internal abstract Links links { get; }
  
}
