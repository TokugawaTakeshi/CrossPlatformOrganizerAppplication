using Task = CommonSolution.Entities.Task.Task;

using MockDataSource.Entities;
using MockDataSource.Utils;


namespace MockDataSource.Collections;


internal abstract class TasksCollectionsMocker
{

  public static IEnumerable<Task> Generate(IEnumerable<Subset> order)
  {

    List<Task> accumulatingCollection = new();

    foreach (Subset subset in order)
    {
      for (uint itemNumber = 0; itemNumber < subset.Quantity; itemNumber++)
      {
        accumulatingCollection.Add(TaskMocker.Generate(
          preDefines: null,
          new TaskMocker.Options
          {
            NullablePropertiesDecisionStrategy = subset.NullablePropertiesDecisionStrategy
          }
        ));
      }
    }

    return accumulatingCollection.ToArray();

  }

  
  public struct Subset
  {
    internal required uint Quantity { get; init; }
    internal required DataMocking.NullablePropertiesDecisionStrategies NullablePropertiesDecisionStrategy { get; init; }
  }
  
}