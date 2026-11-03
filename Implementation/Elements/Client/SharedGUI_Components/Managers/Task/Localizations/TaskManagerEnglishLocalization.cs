using Client.Resources.Localizations;

namespace Client.SharedGUI_Components.Managers.Task.Localizations;


internal record TaskManagerEnglishLocalization : TaskManagerLocalization
{
  
  internal override string heading { get; } = "Task Manager";

  internal override Buttons buttons { get; init; } = new()
  {
    taskEditing = new CommonStringResources.ButtonWithVisibleLabel { label = "Edit Task"},
    taskDeleting = new CommonStringResources.ButtonWithVisibleLabel { label = "Delete Task"},
    taskSaving = new CommonStringResources.ButtonWithVisibleLabel { label = "Save Task"},
    terminatingOfEditing = new CommonStringResources.ButtonWithVisibleLabel { label = "Cancel Editing"}
  };

  internal override Labels labels { get; init; } = new()
  {
    title = "Title",
    status = "Status",
    priority = "Priority",
    description = "Description"
  };

  internal override TaskStatuses taskStatuses { get; init; } = new()
  {
    inProgress = "In Progress",
    completed = "Completed"
  };
  
  internal override TasksPriorities tasksPriorities { get; init; } = new()
  {
    one = "1 (Must be Done ASAP)",
    two = "2 (Must be Done Right After Ones of with Priority 1)",
    three = "3 (May be Dome if Time Left)" 
  };
  
  internal override Inputs inputs { get; } = new()
  {
    taskTitle = new CommonStringResources.ControlWithLabelAndGuidance
    {
      label = "Title",
      guidance = $"Please input **{ CommonSolution.Entities.Task.Task.Title.MINIMAL_CHARACTERS_COUNT } - " + 
          $"{ CommonSolution.Entities.Task.Task.Title.MAXIMAL_CHARACTERS_COUNT }** characters." 
          
    },
    taskDescription = new CommonStringResources.ControlWithLabelAndGuidance
    {
      label = "Description",
      guidance = $"Please input **at least { CommonSolution.Entities.Task.Task.Description.MINIMAL_CHARACTERS_COUNT }**" + 
          "characters" 
    }
  };
  
  internal override CommonStringResources.ModalDialog taskDeletingConfirmationModalDialog { get; init; } = new()
  {
    title = "Deleting Confirmation",
    question = "Are you sure about deleting of this person?"
  };

}
