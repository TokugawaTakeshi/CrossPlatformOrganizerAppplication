using System.Globalization;
using Client.SharedComponents.NavigationMenu.Localization;


namespace Client.SharedComponents.NavigationMenu;


public partial class NavigationMenu
{
  
  private readonly NavigationMenuLocalization localization = 
      ClientConfigurationRepresentative.MustForceDefaultLocalization ?
          new NavigationMenuEnglishLocalization() :
          CultureInfo.CurrentCulture.Name switch
          {
            SupportedCultures.JAPANESE => new NavigationMenuJapaneseLocalization(),
            _ => new NavigationMenuEnglishLocalization()
          };
  
}