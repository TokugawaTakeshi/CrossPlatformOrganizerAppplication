using SupportedCultures = CommonSolution.Restrictions.SupportedCultures;
using Client.Pages.Task.Management.Localizations;
using Client.SharedGUI_Components.Managers.Task;
using Client.SharedState;
using CommonSolution.Gateways.Task;
using YamatoDaiwa.Frontend.GUI_Components.BlockingLoadingOverlay;
using YamatoDaiwa.Frontend.GUI_Components.Snackbar;

namespace Client.Pages.Task.Management;


public partial class TasksManagementPage : Microsoft.AspNetCore.Components.ComponentBase
{

  /* ━━━ Fields ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private readonly TasksSharedState incompletedTasksSharedState = TasksSharedState.
      getInstanceByID(TasksSharedState.InstancesIDs.Incompleted);
  
  private string taskManagerAdditionalCSS_Class =>
      TasksSharedState.selectedTask is not null ? "TasksManagementPage-TaskManager__VisibleAtNarrowScreens" : "";

  private TaskManager taskManager = null!;
  
  
  /* ━━━ Localization ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private readonly TasksManagementPageLocalization localization = 
      ClientConfigurationRepresentative.GetBCP_47_Tag_OfSupportedLocale() switch
          {
            SupportedCultures.BCP_47_Tags.JAPANESE => new TasksManagementPageJapaneseLocalization(),
            SupportedCultures.BCP_47_Tags.ENGLISH__UNITED_KINGDOM => new TasksManagementPageEnglishLocalization(),
            _ => throw new ArgumentOutOfRangeException()
          };
  
  
  /* ━━━ Livecycle Hooks ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  protected override async System.Threading.Tasks.Task OnInitializedAsync()
  {
    TasksSharedState.onCommonStateChanged += base.StateHasChanged;
    await this.incompletedTasksSharedState.retrieveTasksSelection();
  }
  
  
  /* ━━━ Actions Handling ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  /* ┅┅┅ Adding of New Task ┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅ */
  private void onNewTaskAddingSessionRequested()
  {
    TasksSharedState.selectedTask = null;
    this.taskManager.startInputOfNewTaskData();
  }

  private async System.Threading.Tasks.Task onSaveNewTask(TaskGateway.Adding.RequestData newTaskData)
  {
    
    BlockingLoadingOverlay.display();

    CommonSolution.Entities.Task.Task newTask;
    
    try
    {
      
      newTask = 
          await TasksSharedState.addTask(
            newTaskData, 
            mustRetrieveUnfilteredTasksIfNewOneDoesNotSatisfyingCurrentFilteringConditions: true
          );
      
    }
    catch (Exception exception)
    {
      
      Client.Utils.DataExchange.handleDataSubmittingException(exception, this.localization.errorMessages.taskAddingFailed);
      
      return;

    }
    finally
    {
      BlockingLoadingOverlay.hide();  
    }

    
    this.taskManager.utilizeTaskEditingSession();
    TasksSharedState.selectedTask = newTask;
    
    _ = Snackbar.displayForAWhile(
      message: this.localization.successMessages.taskAddingSucceeded,
      decorativeVariation: Snackbar.StandardDecorativeVariations.success
    );
    
  }
  
  
  /* ┅┅┅ Editing of Task ┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅ */
  private async System.Threading.Tasks.Task onSaveUpdatedTask(
    TaskGateway.Updating.RequestData updatedTaskData
  )
  {
    
    BlockingLoadingOverlay.display();

    try
    {
      await TasksSharedState.updateTask(updatedTaskData);
    }
    catch (Exception exception)
    {

      Client.Utils.DataExchange.handleDataSubmittingException(exception, this.localization.errorMessages.taskUpdatingFailed);
      
      return;

    }
    finally
    {
      BlockingLoadingOverlay.hide();  
    }
  
    
    this.taskManager.utilizeTaskEditingSession();
    
    _ = Snackbar.displayForAWhile(
      message: this.localization.successMessages.taskUpdatingSucceeded,
      decorativeVariation: Snackbar.StandardDecorativeVariations.success
    );
    
  }
  
  
  /* ┅┅┅ Deleting of Task ┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅ */
  private async System.Threading.Tasks.Task onDeleteSelectedTask()
  {

    if (TasksSharedState.selectedTask is null)
    {
      throw new Exception("\"onDeleteTask\" method has been called while \"activeTask\" is still \"null\".");
    }
    
    
    BlockingLoadingOverlay.display();

    try
    {
      await TasksSharedState.deleteTask(TasksSharedState.selectedTask.ID);
    } catch (Exception exception)
    {
      
      Client.Utils.DataExchange.handleDataSubmittingException(exception, this.localization.errorMessages.taskDeletingFailed);
      
      return;
      
    }
    finally
    {
      BlockingLoadingOverlay.hide();  
    }

    
    this.taskManager.utilizeTaskEditingSession();
    
    _ = Snackbar.displayForAWhile(
      message: this.localization.successMessages.taskDeletingSucceeded,
      decorativeVariation: Snackbar.StandardDecorativeVariations.success
    );
    
  }
 
}