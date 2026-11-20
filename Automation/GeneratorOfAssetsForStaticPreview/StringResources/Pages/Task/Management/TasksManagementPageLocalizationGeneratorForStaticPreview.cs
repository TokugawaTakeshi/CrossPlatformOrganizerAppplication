using System.Text.Json.Nodes;
using YamatoDaiwa.PugCSharpStaticPreview;

using LanguageKey = string;
using JSON_Value = string;


namespace GeneratorOfAssetsForStaticPreview.StringResources.Pages.Task.Management;


internal abstract class TasksManagementPageLocalizationGeneratorForStaticPreview
{
  
  public static void Generate(JsonObject outputObjectWorkpiece)
  {

    LocalizationsGeneratorForStaticPreview.Generate(
      outputObjectWorkpiece,
      outputObjectDotSeparatedPathCommonPart: "pages.task.management",
      languageKeysAndLocalizations: new Dictionary<LanguageKey, TasksManagementPageLocalization>
      {
        { "$$english", new TasksManagementPageEnglishLocalization() },
        { "$$japanese", new TasksManagementPageJapaneseLocalization() }
      },
      properties: new Dictionary<string, Func<TasksManagementPageLocalization, JSON_Value>>
      {
        {
          "pageTitle",
          localization => localization.pageTitle
        },
        {
          "filteringModalDialog.title", 
          localization => localization.filteringModalDialog.title
        },
        {
          "taskManagerActivationGuidance", 
          localization => localization.taskManagerActivationGuidance
        }
      },
      objectTypeNameForJSDoc: nameof(TasksManagementPageLocalization)
    );
    
  }
  
}