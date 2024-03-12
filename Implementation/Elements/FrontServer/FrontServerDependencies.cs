using CommonSolution.Gateways;


namespace FrontServer;


internal class FrontServerDependencies {

  public required Gateways gateways { get; init; }

  public struct Gateways {
    public required PersonGateway Person { get; init; }
    public required TaskGateway Task { get; init; }
  }
  
  public abstract class Injector {

    private static FrontServerDependencies? dependencies;

    public static void SetDependencies(FrontServerDependencies dependencies) {
      Injector.dependencies = dependencies;
    }


    private static FrontServerDependencies getDependencies() {

      if (Injector.dependencies == null) {
        throw new NullReferenceException(
          "\"FrontServerDependencies.Injector\" has not been initialized." +
          "Invoke \"FrontServerDependencies.Injector.SetDependencies\" to complete initialization."
        );
      }


      return Injector.dependencies;
      
    }

    public static Gateways gateways() {
      return getDependencies().gateways;
    }
    
  }
  
}