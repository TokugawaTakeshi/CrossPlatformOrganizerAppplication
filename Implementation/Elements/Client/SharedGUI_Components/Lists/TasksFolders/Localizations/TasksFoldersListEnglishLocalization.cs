using Client.Resources.Localizations;

namespace Client.SharedGUI_Components.Lists.TasksFolders.Localizations;


internal record TasksFoldersListEnglishLocalization : TasksFoldersListLocalization
{
  
  /* ━━━ Buttons ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  internal override Buttons buttons { get; init; } = new()
  {
    addingOfNewTaskFolder = new CommonStringResources.ButtonWithVisibleLabel
    {
      label = "New Folder"
    }
  };
  
  
  /* ━━━ Accessibility Guidancs ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  internal override string loadingStateAccessibilityGuidance { get; init; } = 
      "Task custom folders are been loaded now. Please wait for a while";

}