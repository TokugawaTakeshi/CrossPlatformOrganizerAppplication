namespace Client.SharedGUI_Components.Lists.TasksFolders.Item.Localizations;


internal record TasksFoldersListItemEnglishLocalization : TasksFoldersListItemLocalization
{
  
  /* ━━━ Buttons ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  internal override Buttons buttons { get; init; } = new()
  {
    
    tasksFolderCollapsing = new Buttons.TasksFolderCollapsing
    {
      generateAccessibilityGuidance = templateVariables => 
          $"Collapse tasks folder \"{ templateVariables.tasksFolderLabel }\""
    },
    
    tasksFolderExpanding = new Buttons.TasksFolderExpanding
    {
      generateAccessibilityGuidance = templateVariables => 
          $"Expand tasks folder \"{ templateVariables.tasksFolderLabel }\""
    }, 
     
    retrievingOfTasksOfSpecificCustomFolder = new Buttons.RetrievingOfTasksOfSpecificCustomFolder
    {
      generateAccessibilityGuidance = templateVariables => 
          $"Retrieve tasks of group \"{ templateVariables.tasksFolderLabel }\""
    },
    
    renamingOfTasksFolder = new Buttons.RenamingOfTasksFolder
    {
      label = "Rename",
      generateAccessibilityGuidance = templateVariables => 
          $"Rename the task folder \"{ templateVariables.tasksFolderLabel }\""
    }, 
    
    deletingOfTasksFolder = new Buttons.DeletingOfTasksFolder
    {
      label = "Delete",
      generateAccessibilityGuidance = templateVariables => 
          $"Delete the task folder \"{ templateVariables.tasksFolderLabel }\""
    }
    
  };


  /* ━━━ Text Boxes ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  internal override TextBoxes textBoxes { get; init; } = new()
  {
    
    tasksFolderAdding = new TextBoxes.TasksFolderAdding
    {
      accessibilityGuidance = "Please input the tasks folder name"
    },
    
    tasksFolderEditing = new TextBoxes.TasksFolderEditing
    {
      generateAccessibilityGuidance = templateVariables => 
        $"Please input new name for the tasks group previously named \"{ templateVariables.tasksFolderInitialLabel }\""
    }
    
  };

}