/* [ !!! ATTENTION !!! ] NO MANUAL EDITING!!!       */
/* This file is being GENERATED REPEATEDLY.         */
/* All manual changes COULD BE LOST AT ANY MOMENT.  */

using GeneratorOfAssetsForStaticPreview.StringResources.Common;

namespace GeneratorOfAssetsForStaticPreview.StringResources.SharedGUI_Components.Managers.TasksFolders;


internal abstract record TasksFoldersManagerLocalization
{
 
  // TODO Устранить неоднородность
  /* ━━━ Buttons ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  internal abstract Buttons buttons { get; init; }
  
  internal record Buttons
  {
    internal required CommonStringResources.ButtonWithVisibleLabel addingOfNewTaskFolder { get; init;  }
  }
  
  
  /* ━━━ Accessibility Guidancs ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  internal abstract string loadingStateAccessibilityGuidance { get; init; }
  
}