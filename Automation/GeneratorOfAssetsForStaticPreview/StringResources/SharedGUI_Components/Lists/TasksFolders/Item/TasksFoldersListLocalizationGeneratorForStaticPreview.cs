using System.Text.Json.Nodes;
using YamatoDaiwa.PugCSharpStaticPreview;
using LanguageKey = string;
using JSON_Value = string;


namespace GeneratorOfAssetsForStaticPreview.StringResources.SharedGUI_Components.Lists.TasksFolders.Item;


public static class TasksFoldersListItemLocalizationGeneratorForStaticPreview
{
 
  public static void Generate(JsonObject outputObjectWorkpiece)
  {

    LocalizationsGeneratorForStaticPreview.Generate(
      outputObjectWorkpiece,
      outputObjectDotSeparatedPathCommonPart: "components.lists.tasksFolders.item",
      languageKeysAndLocalizations: new Dictionary<LanguageKey, TasksFoldersListItemLocalization>
      {
        { "$$english", new TasksFoldersListItemEnglishLocalization() },
        { "$$japanese", new TasksFoldersListItemJapaneseLocalization() }
      },
      properties: new Dictionary<string, Func<TasksFoldersListItemLocalization, JSON_Value>>
      {
        
        /* ━━━ Buttons ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
        {
          "buttons.tasksFolderCollapsing.accessibilityGuidance.template", 
          localization => localization.buttons.tasksFolderCollapsing.generateAccessibilityGuidance(
            new TasksFoldersListItemLocalization.Buttons.TasksFolderCollapsing.AccessibilityGuidance.TemplateVariables
            {
              tasksFolderLabel = "{{ tasksFolderLabel }}"
            }
          )
        },
        {
          "buttons.tasksFolderExpanding.accessibilityGuidance.template", 
          localization => localization.buttons.tasksFolderExpanding.generateAccessibilityGuidance(
            new TasksFoldersListItemLocalization.Buttons.TasksFolderExpanding.AccessibilityGuidance.TemplateVariables
            {
              tasksFolderLabel = "{{ tasksFolderLabel }}"
            }
          )
        },
        {
          "buttons.retrievingOfTasksOfSpecificCustomFolder.accessibilityGuidance.template", 
          localization => localization.buttons.retrievingOfTasksOfSpecificCustomFolder.generateAccessibilityGuidance(
            new TasksFoldersListItemLocalization.Buttons.RetrievingOfTasksOfSpecificCustomFolder.AccessibilityGuidance.TemplateVariables
            {
              tasksFolderLabel = "{{ tasksFolderLabel }}"
            }
          )
        },
        {
          "buttons.renamingOfTasksFolder.accessibilityGuidance.template", 
          localization => localization.buttons.renamingOfTasksFolder.generateAccessibilityGuidance(
            new TasksFoldersListItemLocalization.Buttons.RenamingOfTasksFolder.AccessibilityGuidance.TemplateVariables
            {
              tasksFolderLabel = "{{ tasksFolderLabel }}"
            }
          )
        },
        {
          "buttons.deletingOfTasksFolder.accessibilityGuidance.template", 
          localization => localization.buttons.deletingOfTasksFolder.generateAccessibilityGuidance(
            new TasksFoldersListItemLocalization.Buttons.DeletingOfTasksFolder.AccessibilityGuidance.TemplateVariables
            {
              tasksFolderLabel = "{{ tasksFolderLabel }}"
            }
          )
        },

        
        /* ━━━ Text Boxes ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
        {
          "textBoxes.tasksFolderAdding.accessibilityGuidance",
          localization => localization.textBoxes.tasksFolderAdding.accessibilityGuidance
        },
        {
          "textBoxes.tasksFolderEditing.accessibilityGuidance.template",
          localization => localization.textBoxes.tasksFolderEditing.generateAccessibilityGuidance(
            new TasksFoldersListItemLocalization.TextBoxes.TasksFolderEditing.AccessibilityGuidance.TemplateVariables
            {
              tasksFolderInitialLabel = "{{ tasksFolderInitialLabel }}"
            }  
          )
        }
        
      }, 
      objectTypeNameForJSDoc: nameof(TasksFoldersListLocalization)
    );
    
  }
  
}