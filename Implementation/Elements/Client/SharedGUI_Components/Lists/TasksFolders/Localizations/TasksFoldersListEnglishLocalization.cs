using Client.Resources.Localizations;

namespace Client.SharedGUI_Components.Lists.TasksFolders.Localizations;


internal record TasksFoldersListEnglishLocalization() : TasksFoldersListLocalization(
  
  buttons: 
      new TasksFoldersListLocalization.Buttons(
        addingOfNewTaskFolder: new CommonStringResources.ButtonWithVisibleLabel(label: "New Folder")
      ),
  
  loadingStateAccessibilityGuidance: "Task custom folders are been loaded now. Please wait for a while"
      
);
