using MockDataSource.Gateways;


namespace Client;


public partial class App : Application
{
  public App()
  {

    ClientDependencies.Injector.SetDependencies(new ClientDependencies (
      gateways: new ClientDependencies.Gateways (
        person: new PersonMockGateway(),
        task: new TaskMockGateway()
      )
    ));
    
    InitializeComponent();

    MainPage = new MainPage();
    
  }
}