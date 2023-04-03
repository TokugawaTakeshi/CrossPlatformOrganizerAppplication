using CommonSolution.Entities;

using MockDataSource.Entities;
using MockDataSource.Utils;


namespace MockDataSource.Collections;


internal abstract class PeopleCollectionsMocker
{

  public static IEnumerable<Person> Generate(IEnumerable<Subset> order)
  {

    List<Person> accumulatingCollection = new();

    foreach (Subset subset in order)
    {
      for (uint itemNumber = 0; itemNumber < subset.Quantity; itemNumber++)
      {
        accumulatingCollection.Add(PersonMocker.Generate(
          preDefines: null,
          new PersonMocker.Options
          {
            FamilyNamePrefix = subset.FamilyNamePrefix,
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
    internal string? FamilyNamePrefix { get; init; }
  }
  
}