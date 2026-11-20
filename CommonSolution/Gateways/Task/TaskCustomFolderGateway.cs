using CommonSolution.Entities.Task;


namespace CommonSolution.Gateways.Task;


public interface TaskCustomFolderGateway
{
 
  System.Threading.Tasks.Task<TaskCustomFolder[]> RetrieveTreeOfAll();
  
}