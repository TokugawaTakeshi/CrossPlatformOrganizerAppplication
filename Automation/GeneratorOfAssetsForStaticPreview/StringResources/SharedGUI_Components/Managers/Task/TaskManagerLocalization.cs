/* [ !!! ATTENTION !!! ] NO MANUAL EDITING!!!       */
/* This file is being GENERATED REPEATEDLY.         */
/* All manual changes COULD BE LOST AT ANY MOMENT.  */

using GeneratorOfAssetsForStaticPreview.StringResources.Common;

namespace GeneratorOfAssetsForStaticPreview.StringResources.SharedGUI_Components.Managers.Task;


internal abstract record TaskManagerLocalization(
  string heading,
  TaskManagerLocalization.Buttons buttons,
  TaskManagerLocalization.Labels labels,
  TaskManagerLocalization.TaskStatuses taskStatuses,
  TaskManagerLocalization.TasksPriorities tasksPriorities,
  TaskManagerLocalization.Inputs inputs,
  CommonStringResources.ModalDialog taskDeletingConfirmationModalDialog
)
{
  
  internal record Buttons(
    CommonStringResources.ButtonWithVisibleLabel taskEditing,
    CommonStringResources.ButtonWithVisibleLabel taskDeleting,
    CommonStringResources.ButtonWithVisibleLabel taskSaving,
    CommonStringResources.ButtonWithVisibleLabel terminatingOfEditing
  );
  
  internal record Labels(
    string title,
    string status,
    string priority,
    string description
  );
  
  internal record TaskStatuses(
    string inProgress,
    string completed
  );

  internal record TasksPriorities(
    string one,
    string two,
    string three
  );
  
  internal record Inputs(
    CommonStringResources.ControlWithLabelAndGuidance taskTitle,
    CommonStringResources.ControlWithLabelAndGuidance taskDescription
  );
  
}