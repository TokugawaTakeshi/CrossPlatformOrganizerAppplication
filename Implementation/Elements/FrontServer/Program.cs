using CommonSolution.Gateways;
using CommonSolution.Gateways.Task;
using EntityFramework;
using EntityFramework.Gateways;
using EntityFramework.Gateways.Task;
using FrontServer;
using YamatoDaiwa.CSharpExtensions.DataMocking;


MockGatewayHelper.SetLogger(Console.WriteLine);


WebApplicationBuilder webApplicationBuilder = WebApplication.CreateBuilder(args);

webApplicationBuilder.Services.
  
    AddDbContextFactory<RemoteDatabaseContext>().
    AddScoped<Microsoft.EntityFrameworkCore.IDbContextFactory<DatabaseContext>>(
      (IServiceProvider serviceProvider) =>
          new DatabaseContextFactoryAdapterForFrontServer(
            serviceProvider.GetRequiredService<Microsoft.EntityFrameworkCore.IDbContextFactory<RemoteDatabaseContext>>()
          )
    ).
  
    AddScoped<TaskCustomFolderGateway, TaskCustomFolderEntityFrameworkGateway>().
    AddScoped<TaskGateway, TaskEntityFrameworkGateway>().
    AddScoped<PersonGateway, PersonEntityFrameworkGateway>().
    
    AddControllers().
    
    AddJsonOptions(
      (Microsoft.AspNetCore.Mvc.JsonOptions options) => options.JsonSerializerOptions.PropertyNamingPolicy = null
    );


WebApplication webApplication = webApplicationBuilder.Build();

webApplication.MapControllers();

webApplication.Run();
