/* [ !!! ATTENTION !!! ] NO MANUAL EDITING!!!       */
/* This file is being GENERATED REPEATEDLY.         */
/* All manual changes COULD BE LOST AT ANY MOMENT.  */

namespace GeneratorOfAssetsForStaticPreview.StringResources.Pages.Task.Management;


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