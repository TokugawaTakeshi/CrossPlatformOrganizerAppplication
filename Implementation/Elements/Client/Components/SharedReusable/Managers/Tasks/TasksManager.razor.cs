using Client.SharedState;
using System.Diagnostics;
using Microsoft.AspNetCore.Components;


namespace Client.Components.SharedReusable.Managers.Tasks;


public partial class TasksManager : ComponentBase
{

  [Parameter] public string? spaceSeparatedAdditionalCSS_Classes { get; set; }


  protected override async System.Threading.Tasks.Task OnInitializedAsync()
  {
    TasksSharedState.onStateChanged += base.StateHasChanged;
    await TasksSharedState.retrieveTasks();
  }

  
  private void onSelectTask(CommonSolution.Entities.Task targetTask)
  {
    TasksSharedState.currentlySelectedTask = targetTask;
  }
  
}