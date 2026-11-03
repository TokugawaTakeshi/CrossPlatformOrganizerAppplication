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

  
  /* ━━━ Title ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  [System.ComponentModel.DataAnnotations.MaxLength(CommonSolution.Entities.Task.Task.Title.MAXIMAL_CHARACTERS_COUNT)]
  public string Title { get; set; } = null!;

  
  /* ━━━ Description ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public string? Description { get; set; }

  
  /* ━━━ Is Completed ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public bool IsCompleted { get; set; } = false;
  
  
  /* ━━━ Priority ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public byte? Priority { get; set; }
  
  
  /* ━━━ Custom Folder ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  /* [ Theory ] Although generally the explicit specifying of navigation property is optional, it is required for seeding. */
  /* [ Theory ] `Guid.NewGuid()` returns the string of 36 characters. See https://stackoverflow.com/a/4458925/4818123 */
  [System.ComponentModel.DataAnnotations.MaxLength(36)]
  public string? CustomFolderID { get; set; }
  
  public TaskCustomFolderModel? CustomFolder { get; set; }
  
  
  /* ━━━ Relatives ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  /* ─── Parent ───────────────────────────────────────────────────────────────────────────────────────────────────── */
  /* [ Theory ] Although generally the explicit specifying of navigation property is optional, it is required for seeding. */
  /* [ Theory ] `Guid.NewGuid()` return the string of 36 characters. See https://stackoverflow.com/a/4458925/4818123 */
  [System.ComponentModel.DataAnnotations.MaxLength(36)]
  public string? ParentID { get; set; }
  
  public TaskModel? Parent { get; set; }

  
  /* ─── Children ─────────────────────────────────────────────────────────────────────────────────────────────────── */
  public List<TaskModel> Subtasks { get; set; } = [];
  
  
  /* ━━━ Date & Time ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  protected DateTime? _deadlineDateTime;
  protected DateOnly? _deadlineDate;
  
  public DateTime? DeadlineDateTime
  {
    get => this._deadlineDateTime;
    set
    {
      
      if (value is not null)
      {
        this._deadlineDate = null;
      }

      this._deadlineDateTime = value;
      
    }
  }

  public DateOnly? DeadlineDate
  {
    get => this._deadlineDate;
    set
    {

      if (value is not null)
      {
        this._deadlineDateTime = null;
      }

      this._deadlineDate = value;

    }
  }
  
  
  /* ━━━ Compatibility with Business Rules ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public static TaskModel FromBusinessRulesEntity(CommonSolution.Entities.Task.Task task)
  {
    return new TaskModel
    {
      ID = task.ID,
      Title = task.title,
      Description = task.description,
      IsCompleted = task.isCompleted,
      Priority = task.priority,
      CustomFolderID = task.customFolder?.ID,
      ParentID = task.parent?.ID,
      DeadlineDateTime = task.deadlineDateTime,
      DeadlineDate = task.deadlineDate
    };
  }
  
  public static IEnumerable<TaskModel> FromBusinessRulesEntities(IEnumerable<CommonSolution.Entities.Task.Task> tasks)
  {
    return tasks.Select(TaskModel.FromBusinessRulesEntity);
  }
  
  public CommonSolution.Entities.Task.Task ToBusinessRulesEntity()
  {
    return new CommonSolution.Entities.Task.Task
    {
      ID = this.ID,
      title = this.Title,
      description = this.Description,
      isCompleted = this.IsCompleted,
      priority = this.Priority,
      parent = this.Parent?.ToBusinessRulesEntity(),
      subtasks = TaskModel.ToBusinessRuleEntities(this.Subtasks).ToList()
    };
  }
  
  public static IEnumerable<CommonSolution.Entities.Task.Task> ToBusinessRuleEntities(IEnumerable<TaskModel> taskModels)
  {
    return taskModels.Select((TaskModel taskModel) => taskModel.ToBusinessRulesEntity());
  }


  /* ━━━ Configuration ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
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
          Property(taskModel => taskModel.IsCompleted).
          IsRequired(CommonSolution.Entities.Task.Task.IsCompleted.IS_REQUIRED);
      
      builder.
          Property(taskModel => taskModel.Priority).
          IsRequired(CommonSolution.Entities.Task.Task.Priority.IS_REQUIRED);
      
      
      /* [ Theory ] This part could not be set via Fluent API. See https://stackoverflow.com/q/79129837/4818123
      builder.
          Property(taskModel => taskModel.CustomFolder).
          IsRequired(CommonSolution.Entities.Task.Task.CustomFolder.IS_REQUIRED);

      builder.
          Property(taskModel => taskModel.Parent).
          IsRequired(CommonSolution.Entities.Task.Task.Parent.IS_REQUIRED);
      */
      
      builder.
          Property(taskModel => taskModel.ParentID).
          IsRequired(CommonSolution.Entities.Task.Task.Parent.IS_REQUIRED);
      
      /* [ Theory ] This part could not be set via Fluent API. See https://stackoverflow.com/q/79129837/4818123
      builder.Property(taskModel => taskModel.Subtasks);
      */
      
      builder.
          Property(taskModel => taskModel.DeadlineDateTime).
          IsRequired(CommonSolution.Entities.Task.Task.DeadlineDateTime.IS_REQUIRED).
          HasColumnType("timestamp without time zone");
      
      builder.
          Property(taskModel => taskModel.DeadlineDate).
          IsRequired(CommonSolution.Entities.Task.Task.DeadlineDate.IS_REQUIRED);
      
    }
    
  }

}