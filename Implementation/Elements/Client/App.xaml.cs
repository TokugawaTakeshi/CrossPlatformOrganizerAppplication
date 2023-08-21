using MockDataSource.Gateways;


namespace Client;


public partial class App : Application
{
  public App()
  {

    ClientDependencies.Injector.SetDependencies(
      new ClientDependencies
      {
        gateways = new ClientDependencies.Gateways
        {
          Person = new PersonMockGateway(),
          Task = new TaskMockGateway()
        }
      }
    );

    InitializeComponent();

    MainPage = new MainPage();
    
  }
}