using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;


namespace EntityFramework;


public abstract class DatabaseContext : Microsoft.EntityFrameworkCore.DbContext
{
  
  public DbSet<TaskModel> TasksModels { get; internal set; } = null!;
  public DbSet<TaskCustomFolderModel> TaskCustomFoldersModels { get; internal set; } = null!;
  public DbSet<LocationModel> LocationModels { get; internal set; } = null!;
  
  public DbSet<PersonModel> PeopleModels { get; internal set; } = null!;
  
}