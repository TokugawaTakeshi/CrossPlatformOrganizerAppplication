using EntityFramework;
using Microsoft.EntityFrameworkCore;


namespace FrontServer;


public class RemoteDatabaseContext : DatabaseContext
{

  public RemoteDatabaseContext()
  {
    // base.Database.EnsureDeleted();
    base.Database.EnsureCreated();
  }
  
  
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    
    base.OnConfiguring(optionsBuilder);

    optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=pass1234");

  }
  
}