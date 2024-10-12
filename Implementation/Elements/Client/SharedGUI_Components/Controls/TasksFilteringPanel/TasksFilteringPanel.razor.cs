using Client.SharedGUI_Components.Controls.TasksFilteringPanel.Localizations;
using Client.SharedState;
using CommonSolution.Restrictions;

namespace Client.SharedGUI_Components.Controls.TasksFilteringPanel;


public partial class TasksFilteringPanel : 
    Microsoft.AspNetCore.Components.ComponentBase,
    YamatoDaiwa.Frontend.GUI_Components.Abstractions.IHTML_AttributesFallthrough
{
  
  /* ━━━ Component Parameters ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  [Microsoft.AspNetCore.Components.Parameter(CaptureUnmatchedValues = true)]
  public Dictionary<string, object>? rootElementHTML_Attributes { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter] 
  public bool disabled { get; set; } = false;


  /* ━━━ Common Fields ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  // TODO Update when today will change
  private readonly DateOnly today = new();
  
  private readonly TaskCustomFolderSharedState taskCustomFolderSharedState = TaskCustomFolderSharedState.GetInstance();
  private readonly TasksSharedState incompletedTasksSharedState = 
      TasksSharedState.getInstanceByID(TasksSharedState.InstancesIDs.Incompleted);
  
  private readonly Func<System.Threading.Tasks.Task> lastDataRetrieving;
  
  private readonly TasksFilteringPanelLocalization localization = 
      ClientConfigurationRepresentative.GetBCP_47_Tag_OfSupportedLocale() switch
          {
            SupportedCultures.BCP_47_Tags.JAPANESE => new TasksFilteringPanelJapaneseLocalization(),
            SupportedCultures.BCP_47_Tags.ENGLISH__UNITED_KINGDOM => new TasksFilteringPanelEnglishLocalization(),
            _ => throw new ArgumentOutOfRangeException()
          };
  
  
  /* ━━━ Lifecycle Hooks ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  protected override async System.Threading.Tasks.Task OnInitializedAsync()
  {
    
    TasksSharedState.onCommonStateChanged += base.StateHasChanged;
    TaskCustomFolderSharedState.GetInstance().onStateChanged += base.StateHasChanged;
    
    try
    {
      await this.taskCustomFolderSharedState.retrieveTreeOfAll();
    }
    catch
    {
      /* [ Approach ]
       * The error messages will be displayed to a user even no additional logic here.
       * The only thing which must be done here is to prevent the application crashing by the catching of error. */
    }
    
  }
  
  
  /* ┅┅┅ HTML IDs ┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅ */
  private readonly string summariesTitleHTML_ID;
  private readonly string customFoldersTitleHTML_ID;
  
  private static uint counterForHTML_ID_Generating = 0;


  /* ━━━ Constructor ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public TasksFilteringPanel()
  {
    
    string HTML_ID_COMMON_PART = $"TASK_FILTERING_PANEL-{ ++TasksFilteringPanel.counterForHTML_ID_Generating }";
    this.summariesTitleHTML_ID = $"{ HTML_ID_COMMON_PART }-TITLE-SUMMARIES";
    this.customFoldersTitleHTML_ID = $"{ HTML_ID_COMMON_PART }-TITLE-CUSTOM_FOLDERS";

    this.lastDataRetrieving = this.taskCustomFolderSharedState.retrieveTreeOfAll;
    
  }
  
  
  /* ━━━ Events Handling ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private async System.Threading.Tasks.Task retrieveAllIncompleteTasks()
  {
    await this.incompletedTasksSharedState.retrieveTasksSelection(
      new TasksSharedState.SelectionRetrieving.Options
      {
        mustResetFiltering = true
      }
    );
  }
  
  private async System.Threading.Tasks.Task retrieveTasksWithAssociatedWithToday()
  {
    await this.incompletedTasksSharedState.retrieveTasksSelection(
      new TasksSharedState.SelectionRetrieving.Options
      {
        earliestStartingDate = this.today, 
        latestStartingDate = this.today
      }
    );
  }

  
  /* ━━━ Rendering ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private bool isTodayTasksItemSelected => 
      this.incompletedTasksSharedState.filtering.earliestStartingDate == this.today &&
      this.incompletedTasksSharedState.filtering.latestStartingDate == this.today;
  
}