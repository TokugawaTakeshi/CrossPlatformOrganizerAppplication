using Client.SharedGUI_Components.OnePerPage.NavigationMenu.Localizations;
using CommonSolution.Restrictions;

namespace Client.SharedGUI_Components.OnePerPage.NavigationMenu;


public partial class NavigationMenu
{
 
  private readonly NavigationMenuLocalization localization = 
      ClientConfigurationRepresentative.GetBCP_47_Tag_OfSupportedLocale() switch
          {
            SupportedCultures.BCP_47_Tags.JAPANESE => new NavigationMenuJapaneseLocalization(),
            SupportedCultures.BCP_47_Tags.ENGLISH__UNITED_KINGDOM => new NavigationMenuEnglishLocalization(),
            _ => throw new ArgumentOutOfRangeException()
          };

}