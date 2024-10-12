using Client.Resources.Localizations;

namespace Client.SharedGUI_Components.Managers.Task.Localizations;


internal abstract record TaskManagerLocalization
{
  
  internal abstract string heading { get; }
  
  
  /* ━━━ Buttons ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  internal record Buttons
  {
    internal required CommonStringResources.ButtonWithVisibleLabel taskEditing { get; init; }
    internal required CommonStringResources.ButtonWithVisibleLabel taskDeleting { get; init; }
    internal required CommonStringResources.ButtonWithVisibleLabel taskSaving { get; init; }
    internal required CommonStringResources.ButtonWithVisibleLabel terminatingOfEditing { get; init; }
  }
  
  internal abstract Buttons buttons { get; init; }

  
  /* ━━━ Labels ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  internal record Labels
  {
    internal required string title { get; init; }
    internal required string status { get; init; }
    internal required string priority { get; init; }
    internal required string description { get; init; }
  }
  
  internal abstract Labels labels { get; init; }
  

  /* ━━━ Tasks Statuses ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  internal record TaskStatuses
  {
    internal required string inProgress { get; init; }
    internal required string completed { get; init; }
  }
  
  internal abstract TaskStatuses taskStatuses { get; init; }
  

  /* ━━━ Tasks Priorities ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  internal record TasksPriorities
  {
    internal required string one { get; init; }
    internal required string two { get; init; }
    internal required string three { get; init; }
  }
  
  internal abstract TasksPriorities tasksPriorities { get; init; }
  
  
  /* ━━━ Inputs ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  internal record Inputs
  {
    internal required CommonStringResources.ControlWithLabelAndGuidance taskTitle { get; init; }
    internal required CommonStringResources.ControlWithLabelAndGuidance taskDescription { get; init; }
  }
  
  internal abstract Inputs inputs { get; }
  
  
  /* ━━━ Task Deleting Confirmation Modal Dialog ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  internal abstract CommonStringResources.ModalDialog taskDeletingConfirmationModalDialog { get; init; }
  
}
