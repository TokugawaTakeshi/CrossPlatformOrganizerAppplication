using CommonSolution.Gateways;
using Client.SharedState;
using System.Diagnostics;
using Client.Pages.Task.Management.ModalDialogs;
using FrontEndFramework.Components.BlockingLoadingOverlay;
using FrontEndFramework.Components.Snackbar;


namespace Client.SharedComponents.Viewers.Tasks;


public partial class TasksViewer : Microsoft.AspNetCore.Components.ComponentBase 
{

  [Microsoft.AspNetCore.Components.Parameter]
  public required Microsoft.AspNetCore.Components.EventCallback<string> onClickTaskAddingButtonEventHandler { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter] 
  public string? rootElementModifierCSS_Class { get; set; }
 
  
  /* ━━━ ライフサイクルフック ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  protected override async System.Threading.Tasks.Task OnInitializedAsync()
  {
    TasksSharedState.onStateChanged += base.StateHasChanged;
    await TasksSharedState.retrieveTasksSelection();
  }
  
  
  /* ━━━ 操作の処理 ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  /* ─── 課題取得・再取得 ─────────────────────────────────────────────────────────────────────────────────────────────────── */
  private async System.Threading.Tasks.Task onNewTaskSearchingByFullOrPartialTitleOrDescriptionRequestHasBeenEmitted(
    string? newPersonSearchingByFullOrPartialTitleOrDescription 
  )
  {
    await TasksSharedState.retrieveTasksSelection(
      new ITaskGateway.SelectionRetrieving.RequestParameters
      {
        SearchingByFullOrPartialTitleOrDescription = newPersonSearchingByFullOrPartialTitleOrDescription
      },
      mustResetSearchingByFullOrPartialTitleOrDescription: newPersonSearchingByFullOrPartialTitleOrDescription is null
    );
  }

  private async System.Threading.Tasks.Task onClickTasksSelectionRetrievingRetryingButton()
  {
    await TasksSharedState.retrieveTasksSelection();
  }

  private async void onClickFilteringResettingButton()
  {
    await TasksSharedState.retrieveTasksSelection(mustResetSearchingByFullOrPartialTitleOrDescription: true);
  }
  
  private async System.Threading.Tasks.Task onClickTaskAddingButton()
  {
    await this.onClickTaskAddingButtonEventHandler.InvokeAsync(null);
  }

  private void openTasksFilteringModalDialog()
  {
    TasksFilteringModalDialogService.openModalDialog();
  }

  
  
  /* ─── 課題を選択 ────────────────────────────────────────────────────────────────────────────────────────────────────── */
  private void onSelectTask(CommonSolution.Entities.Task targetTask)
  {
    TasksSharedState.currentlySelectedTask = targetTask;
  }

  
  /* ─── 課題完成切り替え ─────────────────────────────────────────────────────────────────────────────────────────────────── */
  private async void onToggleTaskCompletion(CommonSolution.Entities.Task targetTask)
  {

    BlockingLoadingOverlayService.displayBlockingLoadingOverlay();
    
    try
    {
      await TasksSharedState.toggleTaskCompletion(targetTask.ID);
    }
    catch (Exception exception)
    {
      Debug.WriteLine(exception);
    }

    BlockingLoadingOverlayService.dismissBlockingLoadingOverlay();
    
  }


  
  /* ━━━ 条件的表示 ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private bool mustDisableSearchBox =>
      TasksSharedState.isTasksRetrievingInProgressOrNotStartedYet ||
      TasksSharedState.totalTasksCountInDataSource == 0;

}
