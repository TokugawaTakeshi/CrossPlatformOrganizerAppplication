using System.Text.Json.Nodes;
using YamatoDaiwa.PugCSharpStaticPreview;
using LanguageKey = string;
using JSON_Value = string;


namespace GeneratorOfAssetsForStaticPreview.StringResources.SharedGUI_Components.Viewers.Tasks;


internal abstract class TasksViewerLocalizationGeneratorForStaticPreview
{

  public static void Generate(JsonObject outputObjectWorkpiece)
  {

    LocalizationsGeneratorForStaticPreview.Generate(
      outputObjectWorkpiece,
      outputObjectDotSeparatedPathCommonPart: "components.viewers.tasks",
      languageKeysAndLocalizations: new Dictionary<LanguageKey, TasksViewerLocalization>
      {
        { "$$english", new TasksViewerEnglishLocalization() },
        { "$$japanese", new TasksViewerJapaneseLocalization() }
      },
      properties: new Dictionary<string, Func<TasksViewerLocalization, JSON_Value>>
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
          "buttons.taskAdding.label", 
          localization => localization.buttons.taskAdding.label
        },
        {
          "buttons.retryingOfDataRetrieving.label", 
          localization => localization.buttons.retryingOfDataRetrieving.label
        },
        {
          "buttons.immediateAddingOfFirstTask.label", 
          localization => localization.buttons.immediateAddingOfFirstTask.label
        },
        {
          "buttons.resettingOfFiltering.label", 
          localization => localization.buttons.resettingOfFiltering.label
        },
        {
          "buttons.tasksFiltering.label", 
          localization => localization.buttons.tasksFiltering.label
        },
        {
          "errors.tasksRetrieving.title", 
          localization => localization.errors.tasksRetrieving.title
        },
        {
          "errors.tasksRetrieving.description", 
          localization => localization.errors.tasksRetrieving.description
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
        },
        {
          "titles.completedTasks",
          localization => localization.titles.completedTasks
        }
      }, 
      objectTypeNameForJSDoc: nameof(TasksViewerLocalization)
    );
    
  }
  
}