using SupportedCultures = CommonSolution.Restrictions.SupportedCultures;
using System.Globalization;


namespace Client;


public static class ClientConfigurationRepresentative
{

  public const string ARI_ORIGIN = "https://localhost:7074";

  
  /* ━━━ Localization ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public const bool MustForceDefaultLocalization = false;
  
  public static string GetBCP_47_Tag_OfSupportedLocale()
  {
    return ClientConfigurationRepresentative.MustForceDefaultLocalization ||
        CommonSolution.Restrictions.SupportedCultures.BCP_47_Tags.All.Contains(CultureInfo.CurrentCulture.Name) ?
            CultureInfo.CurrentCulture.Name :      
            SupportedCultures.DEFAULT_BCP_47_TAG;
  }

}