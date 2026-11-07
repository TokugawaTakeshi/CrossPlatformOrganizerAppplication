/* [ !!! ATTENTION !!! ] NO MANUAL EDITING!!!       */
/* This file is being GENERATED REPEATEDLY.         */
/* All manual changes COULD BE LOST AT ANY MOMENT.  */

using GeneratorOfAssetsForStaticPreview.StringResources.Common;

namespace GeneratorOfAssetsForStaticPreview.StringResources.SharedGUI_Components.Lists.TasksFolders.Item;


internal abstract record TasksFoldersListItemLocalization
{
  
  /* ━━━ Buttons ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  internal abstract Buttons buttons { get; init; }
  
  internal record Buttons
  {
    
    /* ┅┅┅ Tasks Folder Collapsing ┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅ */
    internal required TasksFolderCollapsing tasksFolderCollapsing { get; init; }

    internal record TasksFolderCollapsing: 
        CommonStringResources.IClickableWithDynamicAccessibilityGuidance<
          TasksFolderCollapsing.AccessibilityGuidance.TemplateVariables
        >
    {
      
      public required Func<
        TasksFolderCollapsing.AccessibilityGuidance.TemplateVariables, string
      > generateAccessibilityGuidance { get; init; }

      internal abstract record AccessibilityGuidance
      {
        internal record TemplateVariables
        {
          internal required string tasksFolderLabel { get; init; }
        } 
      }
      
    } 
    
    
    /* ┅┅┅ Tasks Folder Expanding ┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅ */
    internal required TasksFolderExpanding tasksFolderExpanding { get; init; }

    internal record TasksFolderExpanding: 
        CommonStringResources.IClickableWithDynamicAccessibilityGuidance<
          TasksFolderExpanding.AccessibilityGuidance.TemplateVariables
        >
    {
      
      public required Func<
        TasksFolderExpanding.AccessibilityGuidance.TemplateVariables, string
      > generateAccessibilityGuidance { get; init; }
      
      internal abstract record AccessibilityGuidance
      {
        internal record TemplateVariables
        {
          internal required string tasksFolderLabel { get; init; }
        } 
      }
      
    }
    
    /* ─── Retrieving of Tasks of Specific Folder ─────────────────────────────────────────────────────────────────── */
    internal required RetrievingOfTasksOfSpecificCustomFolder retrievingOfTasksOfSpecificCustomFolder { get; init; }

    internal record RetrievingOfTasksOfSpecificCustomFolder: 
        CommonStringResources.IClickableWithDynamicAccessibilityGuidance<
          RetrievingOfTasksOfSpecificCustomFolder.AccessibilityGuidance.TemplateVariables
        >
    {
      
      public required Func<
        RetrievingOfTasksOfSpecificCustomFolder.AccessibilityGuidance.TemplateVariables, string
      > generateAccessibilityGuidance { get; init; }
      
      internal abstract record AccessibilityGuidance
      {
        internal record TemplateVariables
        {
          internal required string tasksFolderLabel { get; init; }
        } 
      }
      
    }
    

    /* ─── Renaming of Tasks Folder ───────────────────────────────────────────────────────────────────────────────── */
    internal required RenamingOfTasksFolder renamingOfTasksFolder { get; init; }

    internal record RenamingOfTasksFolder: 
        CommonStringResources.IClickableWithStaticLabel,
        CommonStringResources.IClickableWithDynamicAccessibilityGuidance<RenamingOfTasksFolder.AccessibilityGuidance.TemplateVariables>
    {
      
      public required string label { get; init; }
      
      public required Func<
        RenamingOfTasksFolder.AccessibilityGuidance.TemplateVariables, string
      > generateAccessibilityGuidance { get; init; }
      
      internal abstract record AccessibilityGuidance
      {
        internal record TemplateVariables
        {
          internal required string tasksFolderLabel { get; init; }
        } 
      }
      
    }
    
    
    /* ─── Deleting of Tasks of Specific Folder ───────────────────────────────────────────────────────────────────── */
    internal required DeletingOfTasksFolder deletingOfTasksFolder { get; init; }

    internal record DeletingOfTasksFolder: 
        CommonStringResources.IClickableWithStaticLabel,
        CommonStringResources.IClickableWithDynamicAccessibilityGuidance<DeletingOfTasksFolder.AccessibilityGuidance.TemplateVariables>
    {
      
      public required string label { get; init; }
      
      public required Func<
        DeletingOfTasksFolder.AccessibilityGuidance.TemplateVariables, string
      > generateAccessibilityGuidance { get; init; }
      
      internal abstract record AccessibilityGuidance
      {
        internal record TemplateVariables
        {
          internal required string tasksFolderLabel { get; init; }
        } 
      }
      
    }
    
  }

  /* ━━━ Text Boxes ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  internal abstract TextBoxes textBoxes { get; init; }
  
  internal record TextBoxes
  {
    
    /* ─── Task Folder Adding ─────────────────────────────────────────────────────────────────────────────────────── */
    internal required TasksFolderAdding tasksFolderAdding { get; init; }

    internal record TasksFolderAdding : CommonStringResources.IInputtableWithStaticAccessibilityGuidance
    {
      public required string accessibilityGuidance { get; init; }
    }
    
    
    /* ─── Task Folder Editing ────────────────────────────────────────────────────────────────────────────────────── */
    internal required TasksFolderEditing tasksFolderEditing { get; init; }
    
    internal record TasksFolderEditing : 
        CommonStringResources.IInputtableWithDynamicAccessibilityGuidance<
          TasksFolderEditing.AccessibilityGuidance.TemplateVariables
        >
    {
      
      public required Func<
        TasksFolderEditing.AccessibilityGuidance.TemplateVariables, string
      > generateAccessibilityGuidance { get; init; }
      
      internal abstract record AccessibilityGuidance
      {
        internal record TemplateVariables
        {
          internal required string tasksFolderInitialLabel { get; init; }
        } 
      }
      
    }

  }
  
}