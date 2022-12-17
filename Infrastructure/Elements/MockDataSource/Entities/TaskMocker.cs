using Task = CommonSolution.Entities.Task.Task;

using MockDataSource.Utils;
using RandomDataGenerator.FieldOptions;
using RandomDataGenerator.Randomizers;


namespace MockDataSource.Entities;


internal abstract class TaskMocker
{

  public struct PreDefines
  {
    internal string? ID { get; init; }
    internal string? Title { get; init; }
    internal string? Description { get; init; }
    internal List<Task>? Subtasks { get; init; }
    internal bool IsComplete { get; init; } 
  }
  
  public struct Options
  {
    internal required DataMocking.NullablePropertiesDecisionStrategies NullablePropertiesDecisionStrategy { get; init; }
  }

  
  public static Task Generate(PreDefines? preDefines, Options options)
  {

    string ID = preDefines?.ID ?? GenerateID();

    string title =
        preDefines?.Title ??
        RandomizerFactory.GetRandomizer(new FieldOptionsTextWords { Min = 1, Max = 10 }).Generate() + "";

    string? description = DataMocking.DecideOptionalValue(
      new DataMocking.NullablePropertiesDecisionOptions<string?>
      {
        PreDefinedValue = preDefines?.Description,
        RandomValueGenerator = () => RandomizerFactory.GetRandomizer(new FieldOptionsTextLipsum()).Generate(),
        Strategy = options.NullablePropertiesDecisionStrategy
      }
    );

    return new Task
    {
      ID = ID,
      Title = title,
      Description = description
    };

  }
  
  
  private static uint counterForID_Generating;

  private static string GenerateID()
  {
    counterForID_Generating++;
    return $"TASK-{counterForID_Generating}__GENERATED";
  }
  
}