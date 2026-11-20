using CommonSolution.Restrictions;
using Client.SharedState;
using Client.SharedGUI_Components.Viewers.Tasks.Localizations;
using YamatoDaiwa.Frontend.GUI_Components.BlockingLoadingOverlay;

namespace Client.SharedGUI_Components.Viewers.Tasks;


public partial class TasksViewer : 
    Microsoft.AspNetCore.Components.ComponentBase,
    YamatoDaiwa.Frontend.GUI_Components.Abstractions.IHTML_AttributesFallthrough
{

  /* ━━━ Component Parameters ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  [Microsoft.AspNetCore.Components.Parameter]
  public required Microsoft.AspNetCore.Components.EventCallback<string> 
      onNewTaskAddingSessionRequestedEventHandler { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter(CaptureUnmatchedValues = true)]
  public Dictionary<string, object>? rootElementHTML_Attributes { get; set; }
  

  /* ━━━ Common Fields ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  /* ┅┅┅ Shared State ┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅ */
  /* [ Specification ] Currently, the starting of tasks retrieving is being triggered from the outside of this component. */
  private readonly TasksSharedState incompletedTasksSharedState = TasksSharedState.
      getInstanceByID(TasksSharedState.InstancesIDs.Incompleted);
  
  private TasksSharedState? completedTasksSharedState = null;
  
  
  /* ┅┅┅ Localization ┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅ */
  private readonly TasksViewerLocalization localization = 
      ClientConfigurationRepresentative.GetBCP_47_Tag_OfSupportedLocale() switch
          {
            SupportedCultures.BCP_47_Tags.JAPANESE => new TasksViewerJapaneseLocalization(),
            SupportedCultures.BCP_47_Tags.ENGLISH__UNITED_KINGDOM => new TasksViewerEnglishLocalization(),
            _ => throw new ArgumentOutOfRangeException()
          };

  
  /* ━━━ Lifecycle Hooks ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  protected override void OnInitialized()
  {
    this.incompletedTasksSharedState.onInstanceStateChanged += base.StateHasChanged;
    TasksSharedState.onCommonStateChanged += base.StateHasChanged;
  }
  

  /* ━━━ Common Actions Handling ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private async System.Threading.Tasks.Task onTasksFilteringResettingButtonClicked()
  {

    try
    {

      await System.Threading.Tasks.Task.WhenAll(
      
        this.incompletedTasksSharedState.retrieveTasksSelection(
          new TasksSharedState.SelectionRetrieving.Options
          {
            mustResetFiltering = true
          }
        ),
        
        this.completedTasksSharedState is not null ?
            this.completedTasksSharedState.retrieveTasksSelection(
              new TasksSharedState.SelectionRetrieving.Options
              {
                mustResetFiltering = true
              }
            ) :
            System.Threading.Tasks.Task.CompletedTask
          
      );
      
    }
    catch
    {
      /* [ Approach ]
       * The error messages will be displayed to a user even no additional logic here.
       * The only thing which must be done here is to prevent the application crashing by the catching of error. */
    }
  }
  
  private static void onTaskCardClicked(CommonSolution.Entities.Task.Task targetTask)
  {
    TasksSharedState.selectedTask = targetTask;
  }
  
  private static async System.Threading.Tasks.Task onCompletionCheckboxClicked(CommonSolution.Entities.Task.Task targetTask)
  {

    BlockingLoadingOverlay.display();
    
    try
    {
      await TasksSharedState.toggleTaskCompletion(targetTask.ID);
    }
    catch (Exception exception)
    {
      Client.Utils.DataExchange.handleDataSubmittingException(exception, "TEMP"); // TODO Loc. message
    } finally
    {
      BlockingLoadingOverlay.hide();  
    }
    
  }
  
  
  /* ━━━ GUI ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  /* [ Maintainability ] Keep class members in order according to GUI component placement, from left-top to right-bottom. */
  
  /* ┅┅┅ Tasks Actions Bar ┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅ */
  /* ╍╍╍ Tasks Search Box ╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍ */
  private async System.Threading.Tasks.Task onNewTaskSearchingByFullOrPartialTitleOrDescriptionButtonClicked(
    string? newSearchingOfTaskByFullOrPartialTitleOrDescriptionRequest 
  )
  {

    try
    {

      await System.Threading.Tasks.Task.WhenAll(
        
        this.incompletedTasksSharedState.retrieveTasksSelection(
          new TasksSharedState.SelectionRetrieving.Options
          {
            searchingByFullOrPartialTitleOrDescription = newSearchingOfTaskByFullOrPartialTitleOrDescriptionRequest,
            mustResetSearchingByFullOrPartialTitleOrDescription = 
                newSearchingOfTaskByFullOrPartialTitleOrDescriptionRequest is null  
          }
        ),
        
        this.completedTasksSharedState is not null ?
            this.completedTasksSharedState.retrieveTasksSelection(
              new TasksSharedState.SelectionRetrieving.Options
              {
                searchingByFullOrPartialTitleOrDescription = newSearchingOfTaskByFullOrPartialTitleOrDescriptionRequest,
                mustResetSearchingByFullOrPartialTitleOrDescription = 
                    newSearchingOfTaskByFullOrPartialTitleOrDescriptionRequest is null  
              }
            ) :
            System.Threading.Tasks.Task.CompletedTask
          
      );
      
    }
    catch
    {
      /* [ Approach ]
       * The error messages will be displayed to a user even no additional logic here.
       * The only thing which must be done here is to prevent the application crashing by the catching of error. */
    }
    
  }
  

  /* ╍╍╍ New Task Adding Button ╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍ */
  private System.Threading.Tasks.Task onStartingOfNewTaskAddingSessionButtonClicked()
  {
    return this.onNewTaskAddingSessionRequestedEventHandler.InvokeAsync(null);
  }
    
  
  /* ┅┅┅ Incompleted Tasks Section ┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅ */
  private const byte INCOMPLETED_TASKS_CARDS_LOADING_PLACEHOLDERS_COUNT = 12;
  
  private async System.Threading.Tasks.Task onRetryingOfIncompletedTasksSelectionRetrievingButtonClicked()
  {
    await this.incompletedTasksSharedState.retrieveTasksSelection();
  }
  
  
  /* ┅┅┅ Completed Tasks Section ┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅ */
  private const byte COMPLETED_TASKS_CARDS_LOADING_PLACEHOLDERS_COUNT = 8;
  
  private async System.Threading.Tasks.Task onCompletedTasksAccordionExpandingStarted()
  {
    
    this.completedTasksSharedState = TasksSharedState.getInstanceByID(TasksSharedState.InstancesIDs.Completed);
  
    try
    {
      await this.completedTasksSharedState.retrieveTasksSelection();
    }
    catch
    {
      /* [ Approach ]
       * The error messages will be displayed to a user even no additional logic here.
       * The only thing which must be done here is to prevent the application crashing by the catching of error. */
    }
    
  }
  
  private void onCompletedTasksAccordionCollapsed()
  {
    this.completedTasksSharedState = null;
    TasksSharedState.disposeInstance(TasksSharedState.InstancesIDs.Completed); 
  }
  
  private async System.Threading.Tasks.Task onRetryingOfCompletedTasksSelectionRetrievingButtonClicked()
  {

    if (this.completedTasksSharedState is null)
    {
      return;
    }


    try
    {
      await this.completedTasksSharedState.retrieveTasksSelection();
    }
    catch
    {
      /* [ Approach ]
       * The error messages will be displayed to a user even no additional logic here.
       * The only thing which must be done here is to prevent the application crashing by the catching of error. */
    }
    
  }

}
