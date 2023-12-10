using System.Diagnostics;
using Client.SharedState;
using CommonSolution.Gateways;
using Utils;
using YamatoDaiwa.CSharpExtensions;


namespace Client.SharedComponents.Controls.TasksFilteringPanel;


public partial class TasksFilteringPanel : Microsoft.AspNetCore.Components.ComponentBase
{
  
  [Microsoft.AspNetCore.Components.Parameter] 
  public string? rootElementModifierCSS_Class { get; set; }
 

  /* ━━━ ライフサイクルフック ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  protected override void OnInitialized()
  {
    TasksSharedState.onStateChanged += base.StateHasChanged;
  }
  
  
  /* ━━━ 行動処理 ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private System.Threading.Tasks.Task retrieveAllTasks()
  {
    return TasksSharedState.retrieveTasksSelection(
      mustResetFilteringByAssociatedDate: true,
      mustResetFilteringByAssociatedDateTime: true
    );
  }
  
  private System.Threading.Tasks.Task retrieveTasksWithAssociatedDate()
  {
    return TasksSharedState.retrieveTasksSelection(
      requestParameters: new TaskGateway.SelectionRetrieving.RequestParameters
      {
        OnlyTasksWithAssociatedDate = true
      }
    );
  }
  
  private System.Threading.Tasks.Task retrieveTasksWithAssociatedDateTime()
  {
    return TasksSharedState.retrieveTasksSelection(
      requestParameters: new TaskGateway.SelectionRetrieving.RequestParameters
      {
        OnlyTasksWithAssociatedDateTime = true
      }
    );
  }
  
  
  /* ━━━ 条件描画 ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private bool isDisabled => TasksSharedState.isTasksRetrievingInProgressOrNotStartedYet;

  private string retrievingOfAllTasksButtonAdditionalCSS_Classes => new List<string>().
      AddElementToEndIf(
        "TasksFilteringPanel-List-Item-Button__SelectedState",
        !TasksSharedState.onlyTasksWithAssociatedDate && !TasksSharedState.onlyTasksWithAssociatedDateTime
      ).

      StringifyEachElementAndJoin(" ");
  
  private string retrievingOfTasksAssociatedWithDateButtonAdditionalCSS_Classes => new List<string>().
    AddElementToEndIf(
      "TasksFilteringPanel-List-Item-Button__SelectedState",
      TasksSharedState.onlyTasksWithAssociatedDate
    ).

    StringifyEachElementAndJoin(" ");

  private string retrievingOfTasksAssociatedWithDateTimeButtonAdditionalCSS_Classes => new List<string>().
    AddElementToEndIf(
      "TasksFilteringPanel-List-Item-Button__SelectedState",
      TasksSharedState.onlyTasksWithAssociatedDateTime
    ).
    StringifyEachElementAndJoin(" ");

}