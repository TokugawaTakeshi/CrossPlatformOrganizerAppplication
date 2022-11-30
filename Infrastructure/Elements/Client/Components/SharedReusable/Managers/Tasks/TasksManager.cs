using Microsoft.AspNetCore.Components;


namespace Client.Components.SharedReusable.Managers.Tasks;


public partial class TasksManager : ComponentBase
{

  [Parameter]
  public string SpaceSeparatedAdditionalCSS_Classes { get; set; }


  private List<BusinessRules.Enterprise.Tasks.Task> _tasks = new(); 
  
  private bool _isWaitingForTasksSelectionRetrieving = true;
  private bool _isTasksSelectionBeingRetrievedNow = false;
  private bool _isTasksSelectionRetrievingErrorOccurred = false;
  
  
  private bool isTasksRetrievingInProgressOrNotStartedYet => 
    _isWaitingForTasksSelectionRetrieving || _isTasksSelectionBeingRetrievedNow;
  
  protected override async Task OnInitializedAsync()
  {

    _isTasksSelectionBeingRetrievedNow = true;
    _isWaitingForTasksSelectionRetrieving = false;
    _isTasksSelectionRetrievingErrorOccurred = false;
    
    try
    {
      _tasks = (await ClientDependencies.Injector.gateways().Task.RetrieveAll()).ToList();
    }
    catch (Exception e)
    {
      Console.WriteLine(e);
      _isTasksSelectionRetrievingErrorOccurred = true;
    }

    _isTasksSelectionBeingRetrievedNow = false;
    
  }
  
}