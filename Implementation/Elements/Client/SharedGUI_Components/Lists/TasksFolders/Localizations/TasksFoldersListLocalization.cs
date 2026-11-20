using Client.Resources.Localizations;

namespace Client.SharedGUI_Components.Lists.TasksFolders.Localizations;


internal abstract record TasksFoldersListLocalization(
  TasksFoldersListLocalization.Buttons buttons,
  string loadingStateAccessibilityGuidance
)
{
  
  internal record Buttons(CommonStringResources.ButtonWithVisibleLabel addingOfNewTaskFolder);
  
}
