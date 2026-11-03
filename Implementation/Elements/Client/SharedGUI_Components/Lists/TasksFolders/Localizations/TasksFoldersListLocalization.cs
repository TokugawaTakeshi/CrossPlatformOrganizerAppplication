using Client.Resources.Localizations;

namespace Client.SharedGUI_Components.Lists.TasksFolders.Localizations;


internal abstract record TasksFoldersListLocalization
{
 
  /* ━━━ Buttons ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  internal abstract Buttons buttons { get; init; }
  
  internal record Buttons
  {
    internal required CommonStringResources.ButtonWithVisibleLabel addingOfNewTaskFolder { get; init;  }
  }
  
  
  /* ━━━ Accessibility Guidancs ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  internal abstract string loadingStateAccessibilityGuidance { get; init; }
  
}