/* [ !!! ATTENTION !!! ] NO MANUAL EDITING!!!       */
/* This file is being GENERATED REPEATEDLY.         */
/* All manual changes COULD BE LOST AT ANY MOMENT.  */

using GeneratorOfAssetsForStaticPreview.StringResources.Common;

namespace GeneratorOfAssetsForStaticPreview.StringResources.SharedGUI_Components.Lists.TasksFolders;


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