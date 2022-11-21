using MockDataSource.Entities;
using Task = BusinessRules.Enterprise.Tasks.Task;

namespace MockDataSource.Collections;


internal class TasksCollectionsMocker
{

  public static Task[] Generate(Subset[] order)
  {

    List<Task> accumulatingCollection = new List<Task>();

    foreach (Subset subset in order)
    {
      for (uint itemNumber = 0; itemNumber < subset.Quantity; itemNumber++)
      {
        accumulatingCollection.Add(TaskMocker.Generate(new TaskMocker.Options()
        {
          AllOptionals = subset.AllOptionals
        }));
      }
    }

    return accumulatingCollection.ToArray();

  }

  
  public struct Subset
  {
    internal uint Quantity;
    internal bool AllOptionals = false;

    public Subset(uint quantity) : this()
    {
      Quantity = quantity;
    }
  }
  
}