namespace Client.Pages.Task.Management.Localizations;


internal abstract record TasksManagementPageLocalization(
  string pageTitle,
  TasksManagementPageLocalization.FilteringModalDialog filteringModalDialog,
  string taskManagerActivationGuidance,
  TasksManagementPageLocalization.SuccessMessages successMessages,
  TasksManagementPageLocalization.ErrorMessages errorMessages
)
{

  internal record FilteringModalDialog
  {
    internal required string title { get; init; }
  }

  internal record SuccessMessages
  {
    internal required string taskAddingSucceeded { get; init; }
    internal required string taskUpdatingSucceeded { get; init; }
    internal required string taskDeletingSucceeded { get; init; }
  }
  
  internal record ErrorMessages
  {
    internal required string taskAddingFailed { get; init; }
    internal required string taskUpdatingFailed { get; init; }
    internal required string taskDeletingFailed { get; init; }
  }
  
}
