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

    // TODO テストを終わらせてから削除
    // === ＜ テスト専用 ==================================================================================================
    FrontEndFramework.Components.Badge.Badge.defineCustomDecorativeVariations(
      typeof(Client.Components.SharedReusable.Badge.Badge.DecorativeVariations)
    );
    // === テスト専用 ＞ ==================================================================================================
    
    InitializeComponent();

    MainPage = new MainPage();
    
  }
}