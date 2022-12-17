using Task = BusinessRules.Enterprise.Tasks.Task;


namespace Gateways;


public interface ITaskGateway
{
  System.Threading.Tasks.Task<Task[]> RetrieveAll();
}
