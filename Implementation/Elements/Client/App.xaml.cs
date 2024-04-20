using Client.Data.FromServer;
using Client.LocalDataBase;

using EntityFramework;
using MockDataSource.Gateways;

using System.Diagnostics;
using YamatoDaiwa.CSharpExtensions.DataMocking;


namespace Client;


public partial class App : Application
{
  public App()
  {

    DatabaseContext databaseContext = new LocalDatabaseContext();
    
    ClientDependencies.Injector.SetDependencies(
      new ClientDependencies
      {
        gateways = new ClientDependencies.Gateways
        {
          Person = new PersonMockGateway(),
          Task = new TaskHTTP_ClientGateway()
          // Task = new TaskMockGateway()
          // Task = new TaskHTTP_ClientGateway()
        }
      }
    );
    
    MockGatewayHelper.SetLogger((string message) => { Debug.WriteLine(message); });

    InitializeComponent();

    MainPage = new MainPage();
    
  }
}