namespace Client.Pages.Task.Management.Localizations;


internal abstract record TasksManagementPageLocalization(
  string pageTitle,
  TasksManagementPageLocalization.FilteringModalDialog filteringModalDialog,
  string taskManagerActivationGuidance,
  TasksManagementPageLocalization.SuccessMessages successMessages,
  TasksManagementPageLocalization.ErrorMessages errorMessages
)
{

  internal record FilteringModalDialog(string title);

  internal record SuccessMessages
  (
    string taskAddingSucceeded,
    string taskUpdatingSucceeded,
    string taskDeletingSucceeded
  );
  
  internal record ErrorMessages
  (
    string taskAddingFailed,
    string taskUpdatingFailed,
    string taskDeletingFailed
  );
  
}
