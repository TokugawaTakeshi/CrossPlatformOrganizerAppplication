using Task = BusinessRules.Enterprise.Tasks.Task;


namespace Gateways;


public interface ITasksGateway
{
  System.Threading.Tasks.Task<Task[]> RetrieveAll();
}
