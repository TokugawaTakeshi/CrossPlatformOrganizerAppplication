using Client.SharedGUI_Components.Controls.TasksFilteringPanel.Localizations;
using Client.SharedState;
using CommonSolution.Restrictions;

namespace Client.SharedGUI_Components.Controls.TasksFilteringPanel;


public partial class TasksFilteringPanel : 
    Microsoft.AspNetCore.Components.ComponentBase,
    YamatoDaiwa.Frontend.GUI_Components.Abstractions.IHTML_AttributesFallthrough,
    IDisposable
{
  
  /* ━━━ Component Parameters ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  [Microsoft.AspNetCore.Components.Parameter(CaptureUnmatchedValues = true)]
  public Dictionary<string, object>? rootElementHTML_Attributes { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter] 
  public bool disabled { get; set; } = false;


  /* ━━━ Common Fields ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  /* ┅┅┅ Shared State ┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅ */
  private readonly TaskCustomFolderSharedState taskCustomFolderSharedState = 
      TaskCustomFolderSharedState.GetInstance();
  
  private readonly TasksSharedState incompletedTasksSharedState = 
      TasksSharedState.getInstanceByID(TasksSharedState.InstancesIDs.Incompleted);
  
  
  /* ┅┅┅ Date ┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅ */
  private DateOnly today = new();
  
  private System.Threading.Timer midnightTimer =
      new(
        callback: _ => {},
        state: null,
        dueTime: Timeout.Infinite,
        period: 0 
      );
  
  
  /* ┅┅┅ Data Retrieving ┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅ */
  private readonly Func<System.Threading.Tasks.Task> lastDataRetrieving;
  
  
  /* ┅┅┅ Localization ┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅ */
  private readonly TasksFilteringPanelLocalization localization = 
      ClientConfigurationRepresentative.GetBCP_47_Tag_OfSupportedLocale() switch
          {
            SupportedCultures.BCP_47_Tags.JAPANESE => new TasksFilteringPanelJapaneseLocalization(),
            SupportedCultures.BCP_47_Tags.ENGLISH__UNITED_KINGDOM => new TasksFilteringPanelEnglishLocalization(),
            _ => throw new ArgumentOutOfRangeException()
          };
  
  
  /* ┅┅┅ HTML IDs ┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅ */
  private readonly string summariesTitleHTML_ID;
  private readonly string customFoldersTitleHTML_ID;
  
  private static uint counterForHTML_ID_Generating = 0;

  
  /* ┅┅┅ Debugging ┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅ */
  #if DEBUG
    private const bool DATE_UPDATING_CHECKING_MODE = false;
  #endif

  /* ━━━ Constructor ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public TasksFilteringPanel()
  {
    
    string HTML_ID_COMMON_PART = $"TASK_FILTERING_PANEL-{ ++TasksFilteringPanel.counterForHTML_ID_Generating }";
    this.summariesTitleHTML_ID = $"{ HTML_ID_COMMON_PART }-TITLE-SUMMARIES";
    this.customFoldersTitleHTML_ID = $"{ HTML_ID_COMMON_PART }-TITLE-CUSTOM_FOLDERS";

    this.lastDataRetrieving = this.taskCustomFolderSharedState.retrieveTreeOfAll;
    
  }
  
  
  /* ━━━ Lifecycle Hooks ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  protected override async System.Threading.Tasks.Task OnInitializedAsync()
  {
    
    this.ScheduleMidnightUpdate();
    
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
  
  public void Dispose()
  {
    this.midnightTimer.Dispose();
  }
  
  
  /* ━━━ Events Handling ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  /* ┅┅┅ Consequent Actions ┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅ */
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
  
  
  /* ┅┅┅ User-independent Events ┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅ */
  private void OnDateChanged()
  {

    #if DEBUG
      if (TasksFilteringPanel.DATE_UPDATING_CHECKING_MODE)
      #pragma warning disable CS0162 // Unreachable code detected 
      {
        System.Diagnostics.Debug.WriteLine("TasksFilteringPanel, the date change has been simulated.");    
      }
      #pragma warning restore CS0162 // Unreachable code detected
    #endif
    
    this.today = new DateOnly();
    this.ScheduleMidnightUpdate();
  }

  
  /* ━━━ Rendering ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private bool isTodayTasksItemSelected => 
      this.incompletedTasksSharedState.filtering.earliestStartingDate == this.today &&
      this.incompletedTasksSharedState.filtering.latestStartingDate == this.today;

  
  /* ━━━ Routines ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private void ScheduleMidnightUpdate()
  {
    
    DateTime now = DateTime.Now;
    DateTime midnightTimerExpirationMoment;
    
    #if DEBUG
      midnightTimerExpirationMoment = 
          TasksFilteringPanel.DATE_UPDATING_CHECKING_MODE ? 
              now.Date.AddSeconds(5) : 
              now.Date.AddDays(1);
    #else 
      midnightTimerExpirationMoment = now.Date.AddDays(1);
    #endif
    
    TimeSpan timeUntilMidnight = midnightTimerExpirationMoment - now;
    
    midnightTimer.Dispose();
    
    this.midnightTimer = 
        new System.Threading.Timer(
          _ => this.OnDateChanged(),
          null, 
          timeUntilMidnight, 
          System.Threading.Timeout.InfiniteTimeSpan
        );
    
  }
  
}
