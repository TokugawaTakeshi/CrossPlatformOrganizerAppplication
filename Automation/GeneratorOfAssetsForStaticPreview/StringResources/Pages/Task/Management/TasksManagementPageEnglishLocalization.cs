/* [ !!! ATTENTION !!! ] NO MANUAL EDITING!!!       */
/* This file is being GENERATED REPEATEDLY.         */
/* All manual changes COULD BE LOST AT ANY MOMENT.  */

using GeneratorOfAssetsForStaticPreview.StringResources.Common;

namespace GeneratorOfAssetsForStaticPreview.StringResources.Pages.Task.Management;


internal record TasksManagementPageEnglishLocalization() : TasksManagementPageLocalization(
  
  pageTitle: "Tasks Management — Experimental CSharp Application",
  
  filteringModalDialog: new FilteringModalDialog { title = "Filter Tasks" },
  
  taskManagerActivationGuidance: "Click or tap the task card to view details or edit the dedicated task.",
  
  successMessages:
  
      new TasksManagementPageLocalization.SuccessMessages
      {
        taskAddingSucceeded = "Task has been added.",
        taskUpdatingSucceeded = "Task has been updated",
        taskDeletingSucceeded = "Task has been deleted."
      },
  
  errorMessages:
  
      new TasksManagementPageLocalization.ErrorMessages
      {
        taskAddingFailed = CommonEnglishStringResources.SingleInstance.
            buildDataRetrievingOrSubmittingFailedPoliteMessage("The malfunction has occurred during adding of new task."),
        taskUpdatingFailed = CommonEnglishStringResources.SingleInstance.
            buildDataRetrievingOrSubmittingFailedPoliteMessage("The malfunction has occurred during updating of task."),
        taskDeletingFailed = CommonEnglishStringResources.SingleInstance.
          buildDataRetrievingOrSubmittingFailedPoliteMessage("The malfunction has occurred during deleting of task.")
      }
  
);