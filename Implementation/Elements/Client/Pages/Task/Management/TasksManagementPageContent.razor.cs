using Client.SharedState;
using Microsoft.AspNetCore.Components;


namespace Client.Pages.Task.Management;


public partial class TasksManagementPageContent : ComponentBase
{
  
  /* ━━━ フィルド ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private CommonSolution.Entities.Task? activeTask => TasksSharedState.currentlySelectedTask;

  private readonly string taskManagerActivationGuidance = "課題の詳細を閲覧する事や編集するにはカードをクリック・タップして下さい。";

  private string taskManagerAdditionalCSS_Class =>
      this.activeTask is not null ? "TasksManagementPage-TaskManager__VisibleAtNarrowScreens" : "";

  
  /* ━━━ ライフサイクルフック ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  protected override void OnInitialized()
  {
    TasksSharedState.onStateChanged += base.StateHasChanged;
  }
  
}