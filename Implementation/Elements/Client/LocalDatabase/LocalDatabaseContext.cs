using EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;


namespace Client.LocalDataBase;


public class LocalDatabaseContext : DatabaseContext
{

  public LocalDatabaseContext()
  {
    base.Database.EnsureDeleted();
    base.Database.EnsureCreated();
  }
  
  
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    
    base.OnConfiguring(optionsBuilder);

    string stringifiedConnectionData = new SqliteConnectionStringBuilder
    {
      /* [ Example ] C:\Users\Takeshi Tokugawa\AppData\Local\Packages\2302D388(中略)yvjzm\LocalState\TestTest.sq3 */
      DataSource = Path.Combine(FileSystem.AppDataDirectory, "LocalDatabase.sq3")
    }.ToString();
    
    optionsBuilder.UseSqlite(new SqliteConnection(stringifiedConnectionData));
    
  }
  
}
