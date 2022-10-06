using Client.LocalDataBase.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;


namespace Client.LocalDataBase;


// TODO 情報収集の上完成 https://github.com/TokugawaTakeshi/ExperimentalCSharpApplication1/issues/4
public class LocalDataBaseContext : DbContext
{
  
  public DbSet<PersonModel> PeopleModels { get; internal set;  }
  
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    base.OnConfiguring(optionsBuilder);
    string stringifiedConnectionData = new SqliteConnectionStringBuilder { DataSource = "c:\\tool\\db.sqlite3"}.ToString();
    optionsBuilder.UseSqlite(new SqliteConnection(stringifiedConnectionData));
  }
  
}