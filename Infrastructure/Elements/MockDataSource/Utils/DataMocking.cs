using Utils;


namespace MockDataSource.Utils;


public abstract class DataMocking
{

  public enum NullablePropertiesDecisionStrategies
  {
    mustGenerateAll,
    mustGenerateWith50PercentageProbability,
    mustSkipIfHasNotBeenPreDefined
  }
  
  public struct NullablePropertiesDecisionOptions<TPropertyType>
  {
    public required NullablePropertiesDecisionStrategies Strategy { get; init; }
    public required Func<TPropertyType> RandomValueGenerator { get; init; }
    public TPropertyType? PreDefinedValue { get; init; }
  }
  
  public static TValueType? DecideOptionalValue<TValueType>(NullablePropertiesDecisionOptions<TValueType> options)
  {
    return options.Strategy switch
    {
      NullablePropertiesDecisionStrategies.mustGenerateAll => options.PreDefinedValue ?? options.RandomValueGenerator(),
      NullablePropertiesDecisionStrategies.mustSkipIfHasNotBeenPreDefined => options.PreDefinedValue,
      _ => RandomValuesGenerator.GetRandomBoolean() ? options.RandomValueGenerator() : null
    };
  }

}