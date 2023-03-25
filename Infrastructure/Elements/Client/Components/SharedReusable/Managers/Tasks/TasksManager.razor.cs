using System.Diagnostics;
using Microsoft.AspNetCore.Components;

using Client.SharedStateManagers;


namespace Client.Components.SharedReusable.Managers.Tasks;


public partial class TasksManager : ComponentBase
{

  [Parameter]
  public string? spaceSeparatedAdditionalCSS_Classes { get; set; }


  protected override async System.Threading.Tasks.Task OnInitializedAsync()
  {
    // TasksSharedStateManager.onStateChanged += StateHasChanged;
    await TasksSharedStateManager.retrieveTasks();
  }

  private void onSelectTask(CommonSolution.Entities.Task.Task targetTask)
  {
    TasksSharedStateManager.currentlySelectedTask = targetTask;
  }
  
}