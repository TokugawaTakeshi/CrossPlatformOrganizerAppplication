using CommonSolution.Entities.Task;
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

  
  /* ━━━ Label ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  [System.ComponentModel.DataAnnotations.MaxLength(TaskCustomFolder.Label.MAXIMAL_CHARACTERS_COUNT)]
  public string Label { get; set; } = null!;
  
  
  /* ━━━ Relatives ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  /* ─── Parent ───────────────────────────────────────────────────────────────────────────────────────────────────── */
  /* [ Theory ] Although generally the explicit specifying of navigation property is optional, it is required for seeding. */
  /* [ Theory ] `Guid.NewGuid()` return the string of 36 characters. See https://stackoverflow.com/a/4458925/4818123 */
  [System.ComponentModel.DataAnnotations.MaxLength(36)]
  public string? ParentID { get; set; }
  
  public TaskCustomFolderModel? Parent { get; set; }
  
  
  /* ─── Children ─────────────────────────────────────────────────────────────────────────────────────────────────── */
  public List<TaskCustomFolderModel> Children { get; set; } = [];
  
  
  /* ━━━ Order Among Siblings ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public uint OrderAmongSiblings { get; set; }
  
  
  /* ━━━ Compatibility with Business Rules ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public static TaskCustomFolderModel FromBusinessRulesEntity(TaskCustomFolder taskCustomFolder)
  {
    return new TaskCustomFolderModel
    {
      ID = taskCustomFolder.ID,
      Label = taskCustomFolder.label,
      ParentID = taskCustomFolder.parent?.ID,
      OrderAmongSiblings = taskCustomFolder.orderAmongSiblings
    };
  }
  
  public static IEnumerable<TaskCustomFolderModel> FromBusinessRulesEntities(
    IEnumerable<TaskCustomFolder> taskCustomFolders
  )
  {
    return taskCustomFolders.Select(TaskCustomFolderModel.FromBusinessRulesEntity);
  }

  public TaskCustomFolder ToBusinessRulesEntity()
  {
    return new TaskCustomFolder
    {
      ID = this.ID,
      label = this.Label,
      // parent = this.Parent?.ToBusinessRulesEntity(),
      children = TaskCustomFolderModel.ToBusinessRuleEntities(this.Children).ToList(),
      orderAmongSiblings = this.OrderAmongSiblings
    };
  }

  public static IEnumerable<TaskCustomFolder> ToBusinessRuleEntities(
    IEnumerable<TaskCustomFolderModel> taskCustomFolderModels
  )
  {
    return taskCustomFolderModels.Select(
      (TaskCustomFolderModel taskCustomFolderModel) => taskCustomFolderModel.ToBusinessRulesEntity()
    );
  }
  
  
  /* ━━━ Configuration ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public class Configuration : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<TaskCustomFolderModel>
  {

    private const string TABLE_NAME = "TasksCustomFolders";

    public void Configure(
      Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TaskCustomFolderModel> builder)
    {

      builder.ToTable(Configuration.TABLE_NAME);

      builder.
          Property(taskCustomFolderModel => taskCustomFolderModel.Label).
          IsRequired(TaskCustomFolder.Label.IS_REQUIRED);

      
      /* [ Theory ] This part could not be set via Fluent API. See https://stackoverflow.com/q/79129837/4818123
      builder.
          Property(taskCustomFolderModel => taskCustomFolderModel.Parent).
          IsRequired(TaskCustomFolder.Parent.IS_REQUIRED);
      */
      
      builder.
          Property(taskCustomFolderModel => taskCustomFolderModel.ParentID).
          IsRequired(TaskCustomFolder.Parent.IS_REQUIRED);
      
      builder.
          Property(taskCustomFolderModel => taskCustomFolderModel.OrderAmongSiblings).
          IsRequired(TaskCustomFolder.OrderAmongSiblings.IS_REQUIRED);

    }

  }
  
  public override string ToString()
  {
    return "TaskCustomFolder\n" +
      $"      ID : { this.ID }\n" +
      $"   Label : { this.Label }\n" +
      $"  Parent : { (this.ParentID is not null ? "yes" : "no" ) }\n" +
      $"Children : { (this.Children.Count > 0 ? "yes" : "no" ) }";
  }

}