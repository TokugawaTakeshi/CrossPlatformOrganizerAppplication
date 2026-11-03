using System.Text.Json.Nodes;
using YamatoDaiwa.PugCSharpStaticPreview;
using LanguageKey = string;
using JSON_Value = string;


namespace GeneratorOfAssetsForStaticPreview.StringResources.SharedGUI_Components.Lists.TasksFolders;


public static class TasksFoldersListLocalizationGeneratorForStaticPreview
{
 
  public static void Generate(JsonObject outputObjectWorkpiece)
  {

    LocalizationsGeneratorForStaticPreview.Generate(
      outputObjectWorkpiece,
      outputObjectDotSeparatedPathCommonPart: "components.lists.tasksFolders",
      languageKeysAndLocalizations: new Dictionary<LanguageKey, TasksFoldersListLocalization>
      {
        { "$$english", new TasksFoldersListEnglishLocalization() },
        { "$$japanese", new TasksFoldersListJapaneseLocalization() }
      },
      properties: new Dictionary<string, Func<TasksFoldersListLocalization, JSON_Value>>
      {
        
        /* ━━━ Buttons ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
        {
          "buttons.addingOfNewTaskFolder.label", 
          localization => localization.buttons.addingOfNewTaskFolder.label
        },
        
        /* ━━━ Accessibility Guidancs ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
        {
          "loadingStateAccessibilityGuidance", 
          localization => localization.loadingStateAccessibilityGuidance
        }
        
      }, 
      objectTypeNameForJSDoc: nameof(TasksFoldersListLocalization)
    );
    
  }
  
}