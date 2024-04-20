using EntityFramework;
using EntityFramework.Gateways;
using FrontServer;
using YamatoDaiwa.CSharpExtensions.DataMocking;


DatabaseContext databaseContext = new RemoteDatabaseContext();

FrontServerDependencies.Injector.SetDependencies(
  new FrontServerDependencies
  {
    gateways = new FrontServerDependencies.Gateways
    {
      // Person = new PersonMockGateway(),
      Person = new PersonEntityFrameworkGateway(databaseContext),
      // Task = new TaskMockGateway()
      Task = new TaskEntityFrameworkGateway(databaseContext)
    }
  }
);

MockGatewayHelper.SetLogger(Console.WriteLine);

WebApplicationBuilder webApplicationBuilder = WebApplication.CreateBuilder(args);


webApplicationBuilder.Services.
    AddControllers().
    AddJsonOptions(
      (Microsoft.AspNetCore.Mvc.JsonOptions options) => options.JsonSerializerOptions.PropertyNamingPolicy = null
    );


WebApplication webApplication = webApplicationBuilder.Build();

webApplication.MapControllers();

webApplication.Run();
