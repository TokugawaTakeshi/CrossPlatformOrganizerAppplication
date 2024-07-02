using CommonSolution.Gateways;
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Task = CommonSolution.Entities.Task.Task;


namespace EntityFramework.Gateways;


public class TaskEntityFrameworkGateway : TaskGateway
{
  
  private readonly DatabaseContext databaseContext;

  
  public TaskEntityFrameworkGateway(DatabaseContext databaseContext)
  {
    this.databaseContext = databaseContext;
  }


  /* ━━━ Retrieving ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public override System.Threading.Tasks.Task<Task[]> RetrieveAll()
  {
    return System.Threading.Tasks.Task.FromResult(
      this.databaseContext.TasksModels.Select(taskModel => taskModel.ToBusinessRulesEntity()).ToArray()
    );
  }

  public override System.Threading.Tasks.Task<TaskGateway.SelectionRetrieving.ResponseData> RetrieveSelection(
    TaskGateway.SelectionRetrieving.RequestParameters requestParameters
  )
  {

    Task[] allTasks = this.databaseContext.
        TasksModels.
        Select(taskModel => taskModel.ToBusinessRulesEntity()).
        ToArray();

    uint totalItemsCount = Convert.ToUInt32(allTasks.Length);
    
    Task[] arrangedTasksSelection = 
        TaskGateway.Arrange(
          TaskGateway.Filter(allTasks, requestParameters)
        ); 
    
    return System.Threading.Tasks.Task.FromResult(
      new TaskGateway.SelectionRetrieving.ResponseData
      {
        Items = arrangedTasksSelection,
        TotalItemsCountInSelection = Convert.ToUInt32(arrangedTasksSelection.Length),
        TotalItemsCount = Convert.ToUInt32(totalItemsCount)
      }
    );
    
  }
  
  
  /* ━━━ Adding ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public override async System.Threading.Tasks.Task<Task> Add(
    TaskGateway.Adding.RequestData requestData
  )
  {
    
    EntityEntry<TaskModel> newTask = this.databaseContext.TasksModels.Add(
      new TaskModel
      {
        Title = requestData.Title,
        Description = requestData.Description,
        IsComplete = requestData.IsComplete
      }
    );

    await this.databaseContext.SaveChangesAsync();

    return newTask.Entity.ToBusinessRulesEntity();

  }
  
  
  /* ━━━ Updating ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public override async System.Threading.Tasks.Task<Task> Update(
    TaskGateway.Updating.RequestData requestData
  )
  {

    TaskModel targetTaskModel = this.databaseContext.TasksModels.
        First(taskModel => taskModel.ID == requestData.ID);

    targetTaskModel.Title = requestData.Title;
    targetTaskModel.Description = requestData.Description;

    await databaseContext.SaveChangesAsync();

    return targetTaskModel.ToBusinessRulesEntity();

  }

  public override System.Threading.Tasks.Task ToggleCompletion(string targetTaskID)
  {
    
    TaskModel targetTaskModel = this.databaseContext.TasksModels.
        First(taskModel => taskModel.ID == targetTaskID);

    targetTaskModel.IsComplete = !targetTaskModel.IsComplete;

    return databaseContext.SaveChangesAsync();

  }

  
  /* ━━━ Deleting ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public override System.Threading.Tasks.Task Delete(string targetTaskID)
  {
    return this.databaseContext.TasksModels.Where(taskModel => taskModel.ID == targetTaskID).ExecuteDeleteAsync();
  }
  
}