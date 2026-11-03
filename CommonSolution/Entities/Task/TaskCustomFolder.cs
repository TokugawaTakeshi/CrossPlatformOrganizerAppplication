namespace CommonSolution.Entities.Task;


public class TaskCustomFolder
{
  
  public required string ID { get; init; }
  
  
  /* ━━━ Label ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public required string label { get; set; }
  
  public abstract record Label
  {
    public const bool IS_REQUIRED = true;
    public const byte MINIMAL_CHARACTERS_COUNT = 1;
    public const byte MAXIMAL_CHARACTERS_COUNT = Byte.MaxValue;
  }
  
  
  /* ━━━ Relatives ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  /* ─── Parent ───────────────────────────────────────────────────────────────────────────────────────────────────── */
  public TaskCustomFolder? parent { get; set; }
  
  public abstract record Parent
  {
    public const bool IS_REQUIRED = false;
  }
  
  
  /* ─── Children ─────────────────────────────────────────────────────────────────────────────────────────────────── */
  public List<TaskCustomFolder> children { get; set; } = [];
  
  public abstract record Children
  {
    public const bool IS_REQUIRED = false;
  }
  
  
  /* ━━━ Order Among Siblings ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public required uint orderAmongSiblings { get; set; }
  
  public abstract record OrderAmongSiblings
  {
    public const bool IS_REQUIRED = true;
    public const uint MINIMAL_VALUE = 1;
    public const uint MAXIMAL_VALUE = UInt32.MaxValue;
  }
  
  
  /* ━━━ Path ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public string path
  {
    get
    {

      TaskCustomFolder currentDepthLevel = this;
      List<string> pathSegments = [ currentDepthLevel.label ];

      while (currentDepthLevel.parent is not null)
      {
        currentDepthLevel = currentDepthLevel.parent;
        pathSegments.Add(currentDepthLevel.label);
      }

      return String.Join("/", pathSegments);

    }
  }
  
  
  public override string ToString()
  {
    return "TaskCustomFolder\n" +
      $"      ID : { this.ID }\n" +
      $"   label : { this.label }\n" +
      $"    path : { this.path }\n" +
      $"  parent : { (this.parent is not null ? "yes" : "no" ) }\n" +
      $"children : { (this.children.Count > 0 ? "yes" : "no" ) }";
  }
  
}
