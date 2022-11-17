using BusinessRules.Enterprise;
using MockDataSource.Entities;


namespace MockDataSource.Collections;


internal abstract class PeopleCollectionsMocker
{

  public static List<Person> Generate(List<Subset> order)
  {

    List<Person> accumulatingCollection = new List<Person>();

    foreach (Subset subset in order)
    {
      for (uint itemNumber = 0; itemNumber < subset.Quantity; itemNumber++)
      {
        accumulatingCollection.Add(PersonMocker.Generate(new PersonMocker.Options
        {
          NamePrefix = subset.NamePrefix,
          AllOptionals = subset.AllOptionals
        }));
      }
    }

    return accumulatingCollection;
    
  }

  public class Subset
  {
    internal uint Quantity;
    internal bool AllOptionals = true;
    internal string? NamePrefix;
  }
  
}