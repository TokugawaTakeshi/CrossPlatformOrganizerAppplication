using EntityFramework;
using Microsoft.EntityFrameworkCore;


namespace FrontServer;


public sealed class DatabaseContextFactoryAdapterForFrontServer(IDbContextFactory<RemoteDatabaseContext> innerContextFactory)
  : Microsoft.EntityFrameworkCore.IDbContextFactory<DatabaseContext>
{
  
  public DatabaseContext CreateDbContext()
  {
    return innerContextFactory.CreateDbContext();
  }

  public async ValueTask<DatabaseContext> CreateDbContextAsync(CancellationToken cancellationToken = default)
  {
    return await innerContextFactory.CreateDbContextAsync(cancellationToken).ConfigureAwait(false);
  }
  
}