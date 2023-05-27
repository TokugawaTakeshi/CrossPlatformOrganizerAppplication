using FrontServer;
using MockDataSource.Gateways;


FrontServerDependencies.Injector.SetDependencies(
  new FrontServerDependencies
  {
    gateways = new FrontServerDependencies.Gateways
    {
      Person = new PersonMockGateway(),
      Task = new TaskMockGateway()
    }
  }
);


WebApplicationBuilder webApplicationBuilder = WebApplication.CreateBuilder(args);

webApplicationBuilder.Services.
    AddControllers().
    AddNewtonsoftJson();

WebApplication webApplication = webApplicationBuilder.Build();

webApplication.MapGet("/", () => "Dummy top page");

webApplication.MapControllers();

webApplication.Run();
