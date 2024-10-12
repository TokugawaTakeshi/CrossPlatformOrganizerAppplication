using System.Text.Json.Nodes;
using YamatoDaiwa.PugCSharpStaticPreview;
using LanguageKey = string;
using JSON_Value = string;


namespace GeneratorOfAssetsForStaticPreview.StringResources.SharedGUI_Components.Controls.TasksFilteringPanel;


internal abstract class TasksFilteringPanelLocalizationGeneratorForStaticPreview
{

  public static void Generate(JsonObject outputObjectWorkpiece)
  {

    LocalizationsGeneratorForStaticPreview.Generate(
      outputObjectWorkpiece,
      outputObjectDotSeparatedPathCommonPart: "components.controls.tasksFilteringPanel",
      languageKeysAndLocalizations: new Dictionary<LanguageKey, TasksFilteringPanelLocalization>
      {
        { "$$english", new TasksFilteringPanelEnglishLocalization() },
        { "$$japanese", new TasksFilteringPanelJapaneseLocalization() }
      },
      properties: new Dictionary<string, Func<TasksFilteringPanelLocalization, JSON_Value>>
      {
        
        /* ━━━ Titles ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
        {
          "titles.summaries", 
          localization => localization.titles.summaries
        },
        {
          "titles.custom", 
          localization => localization.titles.custom
        },
        
        /* ━━━ Summary Folders ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
        {
          "summaryFolders.all.title", 
          localization => localization.summaryFolders.all.title
        },
        {
          "summaryFolders.all.accessibilityGuidance", 
          localization => localization.summaryFolders.all.accessibilityGuidance
        },
        {
          "summaryFolders.today.title", 
          localization => localization.summaryFolders.today.title
        },
        {
          "summaryFolders.today.accessibilityGuidance", 
          localization => localization.summaryFolders.today.accessibilityGuidance
        },
        {
          "summaryFolders.overdue.title", 
          localization => localization.summaryFolders.overdue.title
        },
        {
          "summaryFolders.overdue.accessibilityGuidance", 
          localization => localization.summaryFolders.overdue.accessibilityGuidance
        },
        {
          "summaryFolders.byDatesAndTimes.title", 
          localization => localization.summaryFolders.byDatesAndTimes.title
        },
        {
          "summaryFolders.byDatesAndTimes.accessibilityGuidance", 
          localization => localization.summaryFolders.byDatesAndTimes.accessibilityGuidance
        },
        {
          "summaryFolders.byDates.title", 
          localization => localization.summaryFolders.byDates.title
        },
        {
          "summaryFolders.byDates.accessibilityGuidance", 
          localization => localization.summaryFolders.byDates.accessibilityGuidance
        },
        {
          "summaryFolders.byLocations.title", 
          localization => localization.summaryFolders.byLocations.title
        },
        {
          "summaryFolders.byLocations.accessibilityGuidance", 
          localization => localization.summaryFolders.byLocations.accessibilityGuidance
        },
        {
          "summaryFolders.repeating.title", 
          localization => localization.summaryFolders.repeating.title
        },
        {
          "summaryFolders.repeating.accessibilityGuidance", 
          localization => localization.summaryFolders.repeating.accessibilityGuidance
        },

        
        /* ━━━ Buttons ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
        {
          "buttons.retryingOfTasksCustomFoldersRetrieving.label",
          localization => localization.buttons.retryingOfTasksCustomFoldersRetrieving.label
        },
        {
          "buttons.addingOfFirstTaskCustomFolder.label",
          localization => localization.buttons.addingOfFirstTaskCustomFolder.label
        },
        
        
        /* ━━━ Errors Messages ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
        {
          "errorMessages.taskCustomFoldersRetrievingFailed",
          localization => localization.errorMessages.taskCustomFoldersRetrievingFailed
        }
        
      }, 
      objectTypeNameForJSDoc: nameof(TasksFilteringPanelLocalization)
    );
    
  }
  
}