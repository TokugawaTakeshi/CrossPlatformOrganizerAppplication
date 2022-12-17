namespace Client;

using Gateways;


internal class ClientDependencies {

  public readonly Gateways gateways;

  public ClientDependencies(Gateways gateways)
  {
    this.gateways = gateways;
  }

  public class Gateways {
    
    public readonly IPersonGateway Person;
    public readonly ITaskGateway Task;

    public Gateways(IPersonGateway person, ITaskGateway task)
    {
      Person = person;
      Task = task;
    }
  }
  
  public abstract class Injector {

    private static ClientDependencies dependencies;

    public static void SetDependencies(ClientDependencies dependencies) {
      Injector.dependencies = dependencies;
    }


    private static ClientDependencies getDependencies() {

      if (dependencies == null) {
        throw new NullReferenceException("ClientDependenciesは初期化されなかった。");
      }


      return dependencies;
    }

    public static Gateways gateways() {
      return getDependencies().gateways;
    }
  }
}