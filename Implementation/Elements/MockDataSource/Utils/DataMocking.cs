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
  
  public struct NullablePropertiesDecisionSourceDataAndOptions<TPropertyType>
  {
    public required NullablePropertiesDecisionStrategies Strategy { get; init; }
    public required Func<TPropertyType> RandomValueGenerator { get; init; }
    public TPropertyType? PreDefinedValue { get; init; }
  }
  
  public static TValueType? DecideOptionalValue<TValueType>(
    NullablePropertiesDecisionSourceDataAndOptions<TValueType> sourceDataAndOptions
  ) 
  {
    return sourceDataAndOptions.Strategy switch
    {
      NullablePropertiesDecisionStrategies.mustGenerateAll => sourceDataAndOptions.PreDefinedValue ?? sourceDataAndOptions.RandomValueGenerator(),
      NullablePropertiesDecisionStrategies.mustSkipIfHasNotBeenPreDefined => sourceDataAndOptions.PreDefinedValue,
      _ => RandomValuesGenerator.GetRandomBoolean() ? sourceDataAndOptions.RandomValueGenerator() : default
    };
  }

}