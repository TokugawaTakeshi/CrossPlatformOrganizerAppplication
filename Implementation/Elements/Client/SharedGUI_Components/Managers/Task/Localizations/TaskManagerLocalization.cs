using Client.Resources.Localizations;

namespace Client.SharedGUI_Components.Managers.Task.Localizations;


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
