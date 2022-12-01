using RandomDataGenerator.FieldOptions;
using RandomDataGenerator.Randomizers;
using Task = BusinessRules.Enterprise.Tasks.Task;


namespace MockDataSource.Entities;


internal abstract class TaskMocker
{


  public static Task Generate(Options options)
  {

    uint ID = options.ID ?? GenerateID();
    
    string title = options.Title ?? RandomizerFactory.GetRandomizer(new FieldOptionsTextWords { Min = 1, Max = 10 }).Generate();

    string? description;
    
    if (options.Description == null || options.AllOptionals)
    {
      description = RandomizerFactory.GetRandomizer(new FieldOptionsTextLipsum()).Generate();
    } else
    {
      description = options.Description;
    }


    List<Task>? subtasks = options.Subtasks;

    return new Task
    {
      ID = ID,
      Title = title,
      Description = description,
      Subtasks = subtasks
    };

  }
  
  public struct Options
  {
    internal uint? ID;
    internal string? Title;
    internal string? TitlePrefix;
    internal string? Description;
    internal List<Task>? Subtasks;
    internal bool AllOptionals;
  }
  
  
  private static uint counterForID_Generating;
  
  private static uint GenerateID()
  {
    counterForID_Generating++;
    return counterForID_Generating;
  }
  
}