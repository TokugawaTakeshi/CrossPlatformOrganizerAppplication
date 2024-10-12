using System.Text.Json.Nodes;
using YamatoDaiwa.PugCSharpStaticPreview;

using LanguageKey = string;
using JSON_Value = string;


namespace GeneratorOfAssetsForStaticPreview.StringResources.Pages.Person.Management;


internal abstract class PeopleManagementPageLocalizationGeneratorForStaticPreview
{
  
  public static void Generate(JsonObject outputObjectWorkpiece)
  {

    LocalizationsGeneratorForStaticPreview.Generate(
      outputObjectWorkpiece,
      outputObjectDotSeparatedPathCommonPart: "pages.person.management",
      languageKeysAndLocalizations: new Dictionary<LanguageKey, PeopleManagementPageLocalization>
      {
        { "$$english", new PeopleManagementPageEnglishLocalization() },
        { "$$japanese", new PeopleManagementPageJapaneseLocalization() }
      },
      properties: new Dictionary<string, Func<PeopleManagementPageLocalization, JSON_Value>>
      {
        {
          "pageTitle",
          localization => localization.pageTitle
        },
        {
          "taskManagerActivationGuidance", 
          localization => localization.personManagerActivationGuidance
        }
      },
      objectTypeNameForJSDoc: nameof(PeopleManagementPageLocalization)
    );
    
  }
  
}