using Client.SharedComponents.Reusables.Badge;
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
      typeof(Badge.DecorativeVariations)
    );
    // === テスト専用 ＞ ==================================================================================================
    
    InitializeComponent();

    MainPage = new MainPage();
    
  }
}