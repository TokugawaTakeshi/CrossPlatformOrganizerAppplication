using CommonSolution.Entities.Task;
using CommonSolution.Gateways.Task;
using TaskCustomFolderTransactions = ClientAndFrontServer.Transactions.Task.TaskCustomFolderTransactions;


namespace FrontServer.Controllers.Task;


[Microsoft.AspNetCore.Mvc.ApiController]
public class TaskCustomFolderController(
  TaskCustomFolderGateway taskCustomFolderGateway
) : Microsoft.AspNetCore.Mvc.ControllerBase
{
  
  /* ━━━ Retrieving ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  [Microsoft.AspNetCore.Mvc.HttpGet(TaskCustomFolderTransactions.RetrievingOfTreeOfAll.URN_PATH)]
  public async System.Threading.Tasks.Task<
    Microsoft.AspNetCore.Mvc.ActionResult<TaskCustomFolder[]>
  > RetrieveTreeOfAll() {
    return base.Ok(
      await taskCustomFolderGateway.RetrieveTreeOfAll()
    );
  }

}