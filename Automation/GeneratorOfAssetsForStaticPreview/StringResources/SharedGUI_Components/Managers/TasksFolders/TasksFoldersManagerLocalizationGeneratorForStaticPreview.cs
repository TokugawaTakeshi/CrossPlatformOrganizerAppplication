using System.Text.Json.Nodes;
using YamatoDaiwa.PugCSharpStaticPreview;
using LanguageKey = string;
using JSON_Value = string;


namespace GeneratorOfAssetsForStaticPreview.StringResources.SharedGUI_Components.Managers.TasksFolders;


public static class TasksFoldersManagerLocalizationGeneratorForStaticPreview
{
 
  public static void Generate(JsonObject outputObjectWorkpiece)
  {

    LocalizationsGeneratorForStaticPreview.Generate(
      outputObjectWorkpiece,
      outputObjectDotSeparatedPathCommonPart: "components.managers.tasksFolders",
      languageKeysAndLocalizations: new Dictionary<LanguageKey, TasksFoldersManagerLocalization>
      {
        { "$$english", new TasksFoldersManagerEnglishLocalization() },
        { "$$japanese", new TasksFoldersManagerJapaneseLocalization() }
      },
      properties: new Dictionary<string, Func<TasksFoldersManagerLocalization, JSON_Value>>
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
      objectTypeNameForJSDoc: nameof(TasksFoldersManagerLocalization)
    );
    
  }
  
}