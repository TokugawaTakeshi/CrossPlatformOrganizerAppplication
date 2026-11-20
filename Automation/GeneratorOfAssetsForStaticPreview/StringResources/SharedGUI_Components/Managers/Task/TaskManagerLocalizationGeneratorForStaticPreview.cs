using System.Text.Json.Nodes;
using YamatoDaiwa.PugCSharpStaticPreview;
using LanguageKey = string;
using JSON_Value = string;

namespace GeneratorOfAssetsForStaticPreview.StringResources.SharedGUI_Components.Managers.Task;


internal static class TaskManagerLocalizationGeneratorForStaticPreview
{

  public static void Generate(JsonObject outputObjectWorkpiece)
  {
    
    LocalizationsGeneratorForStaticPreview.Generate(
      outputObjectWorkpiece,
      outputObjectDotSeparatedPathCommonPart: "components.managers.task",
      languageKeysAndLocalizations: new Dictionary<LanguageKey, TaskManagerLocalization>
      {
        { "$$english", new TaskManagerEnglishLocalization() },
        { "$$japanese", new TaskManagerJapaneseLocalization() }
      },
      properties: new Dictionary<string, Func<TaskManagerLocalization, JSON_Value>>
      {
        
        {
          "heading",
          localization => localization.heading
        },

        
        /* ━━━ Buttons ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
        {
          "buttons.taskEditing.label",
          localization => localization.buttons.taskEditing.label
        },
        {
          "buttons.taskDeleting.label",
          localization => localization.buttons.taskDeleting.label
        },
        {
          "buttons.taskSaving.label",
          localization => localization.buttons.taskSaving.label
        },
        {
          "buttons.terminatingOfEditing.label",
          localization => localization.buttons.terminatingOfEditing.label
        },
        
        
        /* ━━━ Labels ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
        { "labels.title", localization => localization.labels.title },
        { "labels.status", localization => localization.labels.status },
        { "labels.priority", localization => localization.labels.priority },
        { "labels.description", localization => localization.labels.description },
        
        
        /* ━━━ Tasks Statuses ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
        { "taskStatuses.inProgress", localization => localization.taskStatuses.inProgress },
        { "taskStatuses.completed", localization => localization.taskStatuses.completed },
        
        /* ━━━ Tasks Priorities ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
        { "tasksPriorities.1", localization => localization.tasksPriorities.one },
        { "tasksPriorities.2", localization => localization.tasksPriorities.two },
        { "tasksPriorities.3", localization => localization.tasksPriorities.three },
        
        /* ━━━ Inputs ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
        { "inputs.taskTitle.label", localization => localization.inputs.taskTitle.label },
        { "inputs.taskTitle.guidance", localization => localization.inputs.taskTitle.guidance },
        { "inputs.taskDescription.label", localization => localization.inputs.taskDescription.label },
        { "inputs.taskDescription.guidance", localization => localization.inputs.taskDescription.guidance },
        
        /* ━━━ Task Deleting Confirmation Modal Dialog ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
        { "taskDeletingConfirmationModalDialog.title", localization => localization.taskDeletingConfirmationModalDialog.title },
        { "taskDeletingConfirmationModalDialog.question", localization => localization.taskDeletingConfirmationModalDialog.question }
        
      },
      objectTypeNameForJSDoc: nameof(TaskManagerLocalization)
    );
    
  }
  
}