using System.Diagnostics;
using Microsoft.AspNetCore.Components;

using Client.SharedStateManagers;


namespace Client.Components.SharedReusable.Managers.Tasks;


public partial class TasksManager : ComponentBase
{

  [Parameter]
  public string spaceSeparatedAdditionalCSS_Classes { get; set; }


  private CommonSolution.Entities.Task.Task[] _tasks = Array.Empty<CommonSolution.Entities.Task.Task>();
  
  private bool isWaitingForTasksSelectionRetrieving = true;
  private bool isTasksSelectionBeingRetrievedNow = false;
  private bool isTasksSelectionRetrievingErrorOccurred = false;
  
  private bool isTasksRetrievingInProgressOrNotStartedYet => 
      this.isWaitingForTasksSelectionRetrieving || this.isTasksSelectionBeingRetrievedNow;
  
  
  protected override async System.Threading.Tasks.Task OnInitializedAsync()
  {
    await this.retrieveTasks();
  }


  private async System.Threading.Tasks.Task retrieveTasks()
  {
    
    this.isWaitingForTasksSelectionRetrieving = false;
    this.isTasksSelectionBeingRetrievedNow = true;
    this.isTasksSelectionRetrievingErrorOccurred = false;
    
    try
    {
      _tasks = await ClientDependencies.Injector.gateways().Task.RetrieveAll();
    }
    catch (Exception e)
    {
      Debug.WriteLine(e);
      isTasksSelectionRetrievingErrorOccurred = true;
    }

    isTasksSelectionBeingRetrievedNow = false;
    
  }

  private void onSelectTask(CommonSolution.Entities.Task.Task targetTask)
  {
    TasksSharedStateManager.currentlySelectedTask = targetTask;
  }
  
}