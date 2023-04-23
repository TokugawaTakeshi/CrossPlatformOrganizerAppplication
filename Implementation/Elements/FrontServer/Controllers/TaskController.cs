using Task = CommonSolution.Entities.Task;
using CommonSolution.Gateways;
using Microsoft.AspNetCore.Mvc;

namespace FrontServer.Controllers;


[Route("api/tasks")]
[ApiController]
public class TaskController : ControllerBase
{

  private readonly ITaskGateway taskGateway = FrontServerDependencies.Injector.gateways().Task;

  [HttpGet]
  public async System.Threading.Tasks.Task<ActionResult<Task[]>> retrieveAllTasks()
  {
    
    return Ok(await this.taskGateway.RetrieveAll());
  } 

}