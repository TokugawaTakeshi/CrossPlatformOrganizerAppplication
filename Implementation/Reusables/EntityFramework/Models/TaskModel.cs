using Microsoft.EntityFrameworkCore;


namespace EntityFramework.Models;


[System.ComponentModel.DataAnnotations.Schema.Table("tasks")]
[Microsoft.EntityFrameworkCore.EntityTypeConfiguration(typeof(TaskModel.Configuration))]
public class TaskModel
{

  /* [ Theory ] `Guid.NewGuid()` return the string of 36 characters. See https://stackoverflow.com/a/4458925/4818123 */
  [System.ComponentModel.DataAnnotations.Key]
  [System.ComponentModel.DataAnnotations.MaxLength(36)]
  public string ID { get; set; } = Guid.NewGuid().ToString();

  [System.ComponentModel.DataAnnotations.MaxLength(CommonSolution.Entities.Task.Task.Title.MAXIMAL_CHARACTERS_COUNT)]
  public string Title { get; set; } = null!;

  public string? Description { get; set; }

  public bool IsComplete { get; set; }

  /* ━━━ < TODO Next versions ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  // [System.ComponentModel.DataAnnotations.Required]
  // public List<TaskModel> Subtasks { get; set; } = null!;
  
  // public DateTime? AssociatedDateTime { get; set; }
  // public DateOnly? AssociatedDate { get; set; }
  
  // public Location? Location { get; set; }
  /* ━━━ TODO > ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  
  
  public CommonSolution.Entities.Task.Task ToBusinessRulesEntity()
  {
    return new CommonSolution.Entities.Task.Task
    {
      ID = this.ID,
      title = this.Title,
      description = this.Description,
      isComplete = this.IsComplete
    };
  }


  public class Configuration : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<TaskModel>
  {

    private const string TABLE_NAME = "Tasks";
    
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TaskModel> builder)
    {

      builder.ToTable(Configuration.TABLE_NAME);

      builder.
          Property(taskModel => taskModel.Title).
          IsRequired(CommonSolution.Entities.Task.Task.Title.IS_REQUIRED);
      
      builder.
          Property(taskModel => taskModel.Description).
          IsRequired(CommonSolution.Entities.Task.Task.Description.IS_REQUIRED);
      
      builder.
          Property(taskModel => taskModel.IsComplete).
          IsRequired(CommonSolution.Entities.Task.Task.IsComplete.IS_REQUIRED);

    }
    
  }

}