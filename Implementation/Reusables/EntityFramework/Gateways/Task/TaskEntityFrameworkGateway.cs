using CommonSolution.Gateways.Task;
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace EntityFramework.Gateways.Task;


public class TaskEntityFrameworkGateway(
  Microsoft.EntityFrameworkCore.IDbContextFactory<DatabaseContext> contextFactory
) : TaskGateway
{

  /* ━━━ Retrieving ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public override async System.Threading.Tasks.Task<TaskGateway.SelectionRetrieving.ResponseData> RetrieveSelection(
    TaskGateway.SelectionRetrieving.RequestParameters requestParameters
  )
  {
    
    await using DatabaseContext databaseContext = await contextFactory.CreateDbContextAsync();
    
    CommonSolution.Entities.Task.Task[] allTasks = await databaseContext.
        TasksModels.
        Select(taskModel => taskModel.ToBusinessRulesEntity()).
        ToArrayAsync();
    
    uint totalItemsCount = Convert.ToUInt32(allTasks.Length);
    
    CommonSolution.Entities.Task.Task[] arrangedTasksSelection = 
        TaskGateway.Arrange(
          TaskGateway.Filter(allTasks, requestParameters)
        ); 
    
    return new TaskGateway.SelectionRetrieving.ResponseData
    {
      items = arrangedTasksSelection,
      totalItemsCountInSelection = Convert.ToUInt32(arrangedTasksSelection.Length),
      totalItemsCountWithForcedFiltering = Convert.ToUInt32(totalItemsCount)
    };
    
  }
  
  
  /* ━━━ Adding ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public override async System.Threading.Tasks.Task<CommonSolution.Entities.Task.Task> Add(
    TaskGateway.Adding.RequestData requestData
  )
  {
    
    await using DatabaseContext databaseContext = await contextFactory.CreateDbContextAsync();
    
    EntityEntry<TaskModel> newTask = databaseContext.TasksModels.Add(
      new TaskModel
      {
        Title = requestData.Title,
        Description = requestData.Description,
        IsCompleted = requestData.IsComplete
      }
    );

    await databaseContext.SaveChangesAsync();

    return newTask.Entity.ToBusinessRulesEntity();

  }
  
  
  /* ━━━ Updating ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public override async System.Threading.Tasks.Task<CommonSolution.Entities.Task.Task> Update(
    TaskGateway.Updating.RequestData requestData
  )
  {

    await using DatabaseContext databaseContext = await contextFactory.CreateDbContextAsync();
    
    TaskModel targetTaskModel = databaseContext.TasksModels.
        First(taskModel => taskModel.ID == requestData.ID);

    targetTaskModel.Title = requestData.Title;
    targetTaskModel.Description = requestData.Description;

    await databaseContext.SaveChangesAsync();

    return targetTaskModel.ToBusinessRulesEntity();

  }

  public override async System.Threading.Tasks.Task ToggleCompletion(string targetTaskID)
  {
    
    await using DatabaseContext databaseContext = await contextFactory.CreateDbContextAsync();
    
    TaskModel targetTaskModel = databaseContext.TasksModels.
        First(taskModel => taskModel.ID == targetTaskID);

    targetTaskModel.IsCompleted = !targetTaskModel.IsCompleted;

    await databaseContext.SaveChangesAsync();

  }

  
  /* ━━━ Deleting ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public override async System.Threading.Tasks.Task Delete(string targetTaskID)
  {
    await using DatabaseContext databaseContext = await contextFactory.CreateDbContextAsync();
    await databaseContext.TasksModels.Where(taskModel => taskModel.ID == targetTaskID).ExecuteDeleteAsync();
  }
  
}