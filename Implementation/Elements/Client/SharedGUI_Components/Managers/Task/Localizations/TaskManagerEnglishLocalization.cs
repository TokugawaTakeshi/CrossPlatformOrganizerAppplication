using Client.Resources.Localizations;

namespace Client.SharedGUI_Components.Managers.Task.Localizations;


internal record TaskManagerEnglishLocalization() : TaskManagerLocalization(
  
  heading: "Task Manager",
  
  buttons:
  
      new TaskManagerLocalization.Buttons(
        taskEditing: new CommonStringResources.ButtonWithVisibleLabel(label: "Edit Task"),
        taskDeleting: new CommonStringResources.ButtonWithVisibleLabel(label: "Delete Task"),
        taskSaving: new CommonStringResources.ButtonWithVisibleLabel(label: "Save Task"),
        terminatingOfEditing: new CommonStringResources.ButtonWithVisibleLabel(label: "Cancel Editing")
      ),
  
  labels:
  
      new TaskManagerLocalization.Labels(
        title: "Title",
        status: "Status",
        priority: "Priority",
        description: "Description"
      ),
  
  taskStatuses:
  
      new TaskManagerLocalization.TaskStatuses(
        inProgress: "In Progress",
        completed: "Completed"
      ),
  
  tasksPriorities:
  
      new TaskManagerLocalization.TasksPriorities(
        one: "1 (Must be Done ASAP)",
        two: "2 (Must be Done Right After Ones of with Priority 1)",
        three: "3 (May be Dome if Time Left)" 
      ),
  
  inputs: 
  
      new TaskManagerLocalization.Inputs(
        
        taskTitle:
        
            new CommonStringResources.ControlWithLabelAndGuidance
            {
              label = "Title",
              guidance = 
                  $"Please input **{ CommonSolution.Entities.Task.Task.Title.MINIMAL_CHARACTERS_COUNT } - " + 
                    $"{ CommonSolution.Entities.Task.Task.Title.MAXIMAL_CHARACTERS_COUNT }** characters." 
                  
            },
        
        taskDescription: 
        
            new CommonStringResources.ControlWithLabelAndGuidance
            {
              label = "Description",
              guidance = 
                  $"Please input **at least { CommonSolution.Entities.Task.Task.Description.MINIMAL_CHARACTERS_COUNT }**" + 
                    "characters" 
            }
        
      ),
  
  taskDeletingConfirmationModalDialog:
  
      new CommonStringResources.ModalDialog {
        title = "Deleting Confirmation",
        question = "Are you sure about deleting of this person?"
      }
  
);