using Client.SharedStateManagers;


using Microsoft.AspNetCore.Components;


namespace Client.Pages.Task.Management;


public partial class TasksManagementPageContent : ComponentBase
{
  
  private readonly string taskManagerActivationGuidance = "課題の詳細を閲覧する事や編集するにはカードをクリック・タップして下さい。";

  private CommonSolution.Entities.Task.Task? activeTask => TasksSharedStateManager.currentlySelectedTask;


  protected override void OnInitialized()
  {
    TasksSharedStateManager.onStateChanged += StateHasChanged;
  }
  
}