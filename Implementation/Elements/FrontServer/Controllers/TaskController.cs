using CommonSolution.Gateways;
using ClientAndFrontServer;
using Task = CommonSolution.Entities.Task.Task;


namespace FrontServer.Controllers;


[Microsoft.AspNetCore.Mvc.ApiController]
public class TaskController : Microsoft.AspNetCore.Mvc.ControllerBase
{

  private readonly TaskGateway taskGateway = FrontServerDependencies.Injector.gateways().Task;

  
  /* ━━━ Retrieving ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  [Microsoft.AspNetCore.Mvc.HttpGet(TasksTransactions.RetrievingOfAll.URN_PATH)]
  public async System.Threading.Tasks.Task<
    Microsoft.AspNetCore.Mvc.ActionResult<Task[]>
  > retrieveAllTasks()
  {
    return base.Ok(await this.taskGateway.RetrieveAll());
  }
  
  [Microsoft.AspNetCore.Mvc.HttpGet(TasksTransactions.RetrievingOfSelection.URN_PATH)]
  public async System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.ActionResult<TaskGateway.SelectionRetrieving.ResponseData>> Get(
    [
      Microsoft.AspNetCore.Mvc.FromQuery(
        Name=TasksTransactions.RetrievingOfSelection.QueryParameters.onlyTasksWithAssociatedDate
      )
    ] bool onlyTasksWithAssociatedDate,
    [
      Microsoft.AspNetCore.Mvc.FromQuery(
        Name=TasksTransactions.RetrievingOfSelection.QueryParameters.onlyTasksWithAssociatedDateTime)
    ] bool onlyTasksWithAssociatedDateTime,
    [
      Microsoft.AspNetCore.Mvc.FromQuery(
        Name=TasksTransactions.RetrievingOfSelection.QueryParameters.searchingByFullOrPartialTitleOrDescription
      )
    ] string? searchingByFullOrPartialTitle
  ) {
    return base.Ok(
      await this.taskGateway.RetrieveSelection(
      new TaskGateway.SelectionRetrieving.RequestParameters
        {
          OnlyTasksWithAssociatedDate = onlyTasksWithAssociatedDate,
          OnlyTasksWithAssociatedDateTime = onlyTasksWithAssociatedDateTime,
          SearchingByFullOrPartialTitleOrDescription = searchingByFullOrPartialTitle
        }
      )
    );
    
  }
  
  
  /* ━━━ Adding ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  [Microsoft.AspNetCore.Mvc.HttpPost(TasksTransactions.Adding.URN_PATH)]
  public async System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.ActionResult<Task>> AddTask(
    [Microsoft.AspNetCore.Mvc.FromBody] TaskGateway.Adding.RequestData requestData
  ) {
    return base.Ok(
      await this.taskGateway.Add(requestData)
    );
  }
  
  
  /* ━━━ Updating ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  [Microsoft.AspNetCore.Mvc.HttpPut(TasksTransactions.Updating.URN_PATH)]
  public async System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.ActionResult> UpdateTask(
    [Microsoft.AspNetCore.Mvc.FromBody] TaskGateway.Updating.RequestData requestData
  ) {
    return base.Ok(
      await this.taskGateway.Update(requestData)
    );
  }
  
  [Microsoft.AspNetCore.Mvc.HttpPatch(TasksTransactions.TogglingCompletion.URN_PATH_TEMPLATE)]
  public async System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.ActionResult> ToggleTaskCompletion(
    string targetTaskID
  )
  {
    await this.taskGateway.ToggleCompletion(targetTaskID);
    return base.Ok();
  }

  
  /* ━━━ Deleting ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  [Microsoft.AspNetCore.Mvc.HttpDelete(TasksTransactions.Deleting.URN_PATH_TEMPLATE)]
  public async System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.ActionResult> Delete(string targetTaskID) {
    await this.taskGateway.Delete(targetTaskID);
    return base.Ok();
  }

}