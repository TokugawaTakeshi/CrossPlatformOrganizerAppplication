using Microsoft.EntityFrameworkCore;


namespace EntityFramework.Models;


[System.ComponentModel.DataAnnotations.Schema.Table("tasks_custom_folders")]
[Microsoft.EntityFrameworkCore.EntityTypeConfiguration(typeof(TaskCustomFolderModel.Configuration))]
public class TaskCustomFolderModel
{

  /* [ Theory ] `Guid.NewGuid()` return the string of 36 characters. See https://stackoverflow.com/a/4458925/4818123 */
  [System.ComponentModel.DataAnnotations.Key]
  [System.ComponentModel.DataAnnotations.MaxLength(36)]
  public string ID { get; set; } = Guid.NewGuid().ToString();
    
  [System.ComponentModel.DataAnnotations.MaxLength(100)]
  public string Title { get; set; } = null!;
  
  public TaskCustomFolderModel? Parent { get; set; }
  
  public List<TaskCustomFolderModel> Children { get; set; } = [];

  public class Configuration : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<TaskCustomFolderModel>
  {

    private const string TABLE_NAME = "TasksCustomFolders";

    public void Configure(
      Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TaskCustomFolderModel> builder)
    {

      builder.ToTable(Configuration.TABLE_NAME);

      builder.Property(taskCustomFolderModel => taskCustomFolderModel.Title);

    }

  }

}