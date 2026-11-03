using CommonSolution.Entities.Task;
using CommonSolution.Gateways.Task;
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;


namespace EntityFramework.Gateways.Task;


public class TaskCustomFolderEntityFrameworkGateway(
  Microsoft.EntityFrameworkCore.IDbContextFactory<DatabaseContext> contextFactory
) : TaskCustomFolderGateway
{
  
  public async System.Threading.Tasks.Task<TaskCustomFolder[]> RetrieveTreeOfAll()
  {
    
    await using DatabaseContext databaseContext = await contextFactory.CreateDbContextAsync();
    
    /* [ Theory ]
     * Do NOT remove the items with non-null parents from the top level HERE because they will be removed from the
     *   children too. */
    List<TaskCustomFolderModel> taskCustomFoldersModels = await databaseContext.TaskCustomFoldersModels.ToListAsync();
    
    taskCustomFoldersModels.RemoveAll(
    (TaskCustomFolderModel taskCustomFoldersModel) => taskCustomFoldersModel.ParentID != null
    );
    
    return taskCustomFoldersModels.
        Select((TaskCustomFolderModel taskCustomFolderModel) => taskCustomFolderModel.ToBusinessRulesEntity()).
        ToArray(); 
    
  }
  
}