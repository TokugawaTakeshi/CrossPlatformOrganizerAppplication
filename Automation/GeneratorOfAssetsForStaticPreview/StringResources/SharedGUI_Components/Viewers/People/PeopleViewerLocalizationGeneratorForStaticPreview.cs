using System.Text.Json.Nodes;
using YamatoDaiwa.PugCSharpStaticPreview;
using LanguageKey = string;
using JSON_Value = string;


namespace GeneratorOfAssetsForStaticPreview.StringResources.SharedGUI_Components.Viewers.People;


internal abstract class PeopleViewerLocalizationGeneratorForStaticPreview
{

  public static void Generate(JsonObject outputObjectWorkpiece)
  {

    LocalizationsGeneratorForStaticPreview.Generate(
      outputObjectWorkpiece,
      outputObjectDotSeparatedPathCommonPart: "components.viewers.people",
      languageKeysAndLocalizations: new Dictionary<LanguageKey, PeopleViewerLocalization>
      {
        { "$$english", new PeopleViewerEnglishLocalization() },
        { "$$japanese", new PeopleViewerJapaneseLocalization() }
      },
      properties: new Dictionary<string, Func<PeopleViewerLocalization, JSON_Value>>
      {
        {
          "searchBox.placeholder", 
          localization => localization.searchBox.placeholder
        },
        {
          "searchBox.accessibilityGuidance", 
          localization => localization.searchBox.accessibilityGuidance
        },
        {
          "buttons.personAdding.label", 
          localization => localization.buttons.personAdding.label
        },
        {
          "buttons.retryingOfDataRetrieving.label", 
          localization => localization.buttons.retryingOfDataRetrieving.label
        },
        {
          "buttons.immediateAddingOfFirstPerson.label", 
          localization => localization.buttons.immediateAddingOfFirstPerson.label
        },
        
        {
          "buttons.resettingOfFiltering.label", 
          localization => localization.buttons.resettingOfFiltering.label
        },
        {
          "buttons.peopleFiltering.label", 
          localization => localization.buttons.peopleFiltering.label
        },
        {
          "errors.peopleRetrieving.title", 
          localization => localization.errors.peopleRetrieving.title
        },
        {
          "errors.peopleRetrieving.description", 
          localization => localization.errors.peopleRetrieving.description
        },
        {
          "guidances.noItemsAvailable", 
          localization => localization.guidances.noItemsAvailable
        },
        {
          "guidances.noItemsFound", 
          localization => localization.guidances.noItemsFound
        },
        {
          "accessibilityGuidances.dataRetrievingInProgress",
          localization => localization.accessibilityGuidances.dataRetrievingInProgress
        }
      }, 
      objectTypeNameForJSDoc: nameof(PeopleViewerLocalization)
    );
    
  }
  
}