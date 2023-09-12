using System.Diagnostics;
using Client.Pages.Task.Management.ModalDialogs;
using Client.SharedComponents.Managers.Task;
using Client.SharedState;
using FrontEndFramework.Components.BlockingLoadingOverlay;
using FrontEndFramework.Components.ModalDialog;
using FrontEndFramework.Components.Snackbar;
using Microsoft.AspNetCore.Components;


namespace Client.Pages.Task.Management;


public partial class TasksManagementPageContent : ComponentBase
{
  
  /* ━━━ フィルド ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private CommonSolution.Entities.Task? activeTask => TasksSharedState.currentlySelectedTask;

  private readonly string taskManagerActivationGuidance = "課題の詳細を閲覧する事や編集するにはカードをクリック・タップして下さい。";

  private string taskManagerAdditionalCSS_Class =>
      this.activeTask is not null ? "TasksManagementPage-TaskManager__VisibleAtNarrowScreens" : "";

  
  /* ━━━ ライフサイクルフック ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  protected override void OnInitialized()
  {
    TasksSharedState.onStateChanged += base.StateHasChanged;
  }
  

  /* ━━━ 行動処理 ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  /* ─── 新規課題追加 ───────────────────────────────────────────────────────────────────────────────────────────────────── */
  private TaskManager taskManager = null!;
  
  private void beginInputOfNewTaskData()
  {
    this.taskManager.beginInputNewTaskData();
  }
  
  private async void onNewTaskEditingCompleted(CommonSolution.Gateways.ITaskGateway.Adding.RequestData requestData)
  {
    
    BlockingLoadingOverlayService.displayBlockingLoadingOverlay();

    try
    {
      await TasksSharedState.addTask(requestData);
    }
    catch (Exception exception)
    {

      await SnackbarService.displaySnackbarForAWhile(
        message: "課題の追加中不具合が発生しました。お詫び申し上げます。",
        decorativeVariation: Snackbar.StandardDecorativeVariations.error
      );

      Debug.WriteLine(exception);
      return;

    }
    finally
    {
      BlockingLoadingOverlayService.dismissBlockingLoadingOverlay();  
    }
    
    
    await SnackbarService.displaySnackbarForAWhile(
      message: "課題が追加されました。",
      decorativeVariation: Snackbar.StandardDecorativeVariations.success
    );
    
  }
  
  
  /* ─── 既存編集 ─────────────────────────────────────────────────────────────────────────────────────────────────────── */
  private async void onExistingTaskEditingCompleted(
    CommonSolution.Gateways.ITaskGateway.Updating.RequestData requestData
  )
  {
    
    BlockingLoadingOverlayService.displayBlockingLoadingOverlay();

    try
    {
      await TasksSharedState.updateTask(requestData);
    }
    catch (Exception exception)
    {

      await SnackbarService.displaySnackbarForAWhile(
        message: "課題の更新中不具合が発生しました。お詫び申し上げます。",
        decorativeVariation: Snackbar.StandardDecorativeVariations.error
      );
      
      Debug.WriteLine(exception.ToString());
      return;

    }
    finally
    {
      BlockingLoadingOverlayService.dismissBlockingLoadingOverlay();  
    }
  
    await SnackbarService.displaySnackbarForAWhile(
      message: "課題の更新が完了しました。",
      decorativeVariation: Snackbar.StandardDecorativeVariations.success
    );
    
  }
  
  
  /* ━━━ 他のイベント処理 ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private void onTasksFilteringModalDialogInitialized(ModalDialog tasksFilteringModalDialogInstance)
  {
    TasksFilteringModalDialogService.initialize(tasksFilteringModalDialogInstance);
  }
  
}