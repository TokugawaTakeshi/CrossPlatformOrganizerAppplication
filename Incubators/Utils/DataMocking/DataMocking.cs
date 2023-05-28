namespace Utils.DataMocking;


public abstract class DataMocking
{

  public enum NullablePropertiesDecisionStrategies
  {
    mustGenerateAll,
    mustGenerateWith50PercentageProbabilityIfHasNotBeenPreDefined,
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
    switch (sourceDataAndOptions.Strategy)
    {
      
      case NullablePropertiesDecisionStrategies.mustGenerateAll:
        return sourceDataAndOptions.PreDefinedValue ?? sourceDataAndOptions.RandomValueGenerator();
      
      case NullablePropertiesDecisionStrategies.mustSkipIfHasNotBeenPreDefined:
        return sourceDataAndOptions.PreDefinedValue;
      
      case NullablePropertiesDecisionStrategies.mustGenerateWith50PercentageProbabilityIfHasNotBeenPreDefined:
      default:
      {
        
        if (sourceDataAndOptions.PreDefinedValue is not null)
        {
          return sourceDataAndOptions.PreDefinedValue;
        }
        
        
        return RandomValuesGenerator.GetRandomBoolean() ? sourceDataAndOptions.RandomValueGenerator() : default;
        
      }
        
    }
  }

}