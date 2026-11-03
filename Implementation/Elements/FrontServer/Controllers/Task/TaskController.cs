using CommonSolution.Gateways.Task;
using TasksTransactions = ClientAndFrontServer.Transactions.Task.TasksTransactions;


namespace FrontServer.Controllers.Task;


[Microsoft.AspNetCore.Mvc.ApiController]
public class TaskController(
  TaskGateway taskGateway
) : Microsoft.AspNetCore.Mvc.ControllerBase
{
  
  /* ━━━ Retrieving ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public abstract record SelectionRetrieving
  {
    public record QueryParameters
    {
      
      [Microsoft.AspNetCore.Mvc.FromQuery(Name = TasksTransactions.RetrievingOfSelection.QueryParameters.forcedFiltering)]
      public required ForcedFiltering forcedFiltering { get; set; }
      
      public record ForcedFiltering
      {
  
        [
          Microsoft.AspNetCore.Mvc.FromQuery(
            Name = TasksTransactions.RetrievingOfSelection.QueryParameters.ForcedFiltering.ProgressStatus.SPECIFIC_PART
          )
        ]
        public required TaskGateway.SelectionRetrieving.RequestParameters.ForcedFiltering.ProgressStatues progressStatus { get; set; }
        
      }
      
      [Microsoft.AspNetCore.Mvc.FromQuery(Name = TasksTransactions.RetrievingOfSelection.QueryParameters.optionalFiltering)]
      public OptionalFiltering? optionalFiltering { get; set; }
      
      public record OptionalFiltering
      {
        
        [
          Microsoft.AspNetCore.Mvc.FromQuery(
            Name = TasksTransactions.RetrievingOfSelection.QueryParameters.OptionalFiltering.StartingDate.SPECIFIC_PART
          )
        ]
        public DateOnly? startingDate { get; set; }
        
        [
          Microsoft.AspNetCore.Mvc.FromQuery(
            Name = TasksTransactions.RetrievingOfSelection.QueryParameters.OptionalFiltering.EndingDate.SPECIFIC_PART
          )
        ]
        public DateOnly? endingDate { get; set; }
        
        [
          Microsoft.AspNetCore.Mvc.FromQuery(
            Name = TasksTransactions.RetrievingOfSelection.QueryParameters.OptionalFiltering.
                SearchingByFullOrPartialTitleOrDescription.SPECIFIC_PART
          )
        ]
        public string? searchingByFullOrPartialTitleOrDescription { get; set; }
      }
      
      public TaskGateway.SelectionRetrieving.RequestParameters ToRequestParameters()
      {
        return new TaskGateway.SelectionRetrieving.RequestParameters
        {
          forcedFiltering = new TaskGateway.SelectionRetrieving.RequestParameters.ForcedFiltering
          {
            progressStatus = this.forcedFiltering.progressStatus
          },
          optionalFiltering = new TaskGateway.SelectionRetrieving.RequestParameters.OptionalFiltering
          {
            startingDate = this.optionalFiltering?.startingDate,
            endingDate = this.optionalFiltering?.endingDate,
            searchingByFullOrPartialTitleOrDescription = this.optionalFiltering?.searchingByFullOrPartialTitleOrDescription
          }
        };
      }
            
    } 
  }
  
  [Microsoft.AspNetCore.Mvc.HttpGet(TasksTransactions.RetrievingOfSelection.URN_PATH)]
  public async System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.ActionResult<TaskGateway.SelectionRetrieving.ResponseData>> Get(
    [Microsoft.AspNetCore.Mvc.FromQuery] TaskController.SelectionRetrieving.QueryParameters queryParameters
  ) {
    return base.Ok(
      await taskGateway.RetrieveSelection(queryParameters.ToRequestParameters())
    );
  }

  
  /* ━━━ Adding ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  [Microsoft.AspNetCore.Mvc.HttpPost(TasksTransactions.Adding.URN_PATH)]
  public async System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.ActionResult<CommonSolution.Entities.Task.Task>> AddTask(
    [Microsoft.AspNetCore.Mvc.FromBody] TaskGateway.Adding.RequestData requestData
  ) {
    return base.Ok(
      await taskGateway.Add(requestData)
    );
  }
  
  
  /* ━━━ Updating ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  [Microsoft.AspNetCore.Mvc.HttpPut(TasksTransactions.Updating.URN_PATH)]
  public async System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.ActionResult> UpdateTask(
    [Microsoft.AspNetCore.Mvc.FromBody] TaskGateway.Updating.RequestData requestData
  ) {
    return base.Ok(
      await taskGateway.Update(requestData)
    );
  }
  
  [Microsoft.AspNetCore.Mvc.HttpPatch(TasksTransactions.TogglingCompletion.URN_PATH_TEMPLATE)]
  public async System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.ActionResult> ToggleTaskCompletion(
    string targetTaskID
  )
  {
    await taskGateway.ToggleCompletion(targetTaskID);
    return base.Ok();
  }

  
  /* ━━━ Deleting ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  [Microsoft.AspNetCore.Mvc.HttpDelete(TasksTransactions.Deleting.URN_PATH_TEMPLATE)]
  public async System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.ActionResult> Delete(string targetTaskID) {
    await taskGateway.Delete(targetTaskID);
    return base.Ok();
  }

}