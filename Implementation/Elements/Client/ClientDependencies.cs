using CommonSolution.Gateways;


namespace Client;


internal class ClientDependencies {

  public required Gateways gateways { get; init; }

  public struct Gateways {
    public required PersonGateway Person { get; init; }
    public required TaskGateway Task { get; init; }
  }
  
  public abstract class Injector {

    private static ClientDependencies? dependencies;

    public static void SetDependencies(ClientDependencies dependencies) {
      Injector.dependencies = dependencies;
    }


    private static ClientDependencies getDependencies() {

      if (Injector.dependencies == null) {
        throw new NullReferenceException(
          "\"ClientDependencies.Injector\" has not been initialized." +
          "Invoke \"ClientDependencies.Injector.SetDependencies\" to complete initialization."
        );
      }


      return Injector.dependencies;
      
    }

    public static Gateways gateways() {
      return getDependencies().gateways;
    }
    
  }
  
}