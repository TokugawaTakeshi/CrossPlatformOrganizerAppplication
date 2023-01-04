using CommonSolution.Entities;

using MockDataSource.Utils;
using RandomDataGenerator.FieldOptions;
using RandomDataGenerator.Randomizers;

using Utils;


namespace MockDataSource.Entities;


internal abstract class PersonMocker
{
  
  public struct PreDefines
  {
    internal string? ID { get; init; }
    internal string? FamilyName { get; init; }
    internal string? GivenName { get; init; }
    internal byte? Age;
    
    internal string? EmailAddress { get; init; }
    
    internal string? PhoneNumber;
  }
  
  public struct Options
  {
    internal required DataMocking.NullablePropertiesDecisionStrategies NullablePropertiesDecisionStrategy { get; init; }
    internal string? FamilyNamePrefix { get; init; }
  }
  
  public static Person Generate(PreDefines? preDefines, Options options)
  {

    string ID = preDefines?.ID ?? GenerateID();

    string familyName =
        preDefines?.FamilyName ??
        (options.FamilyNamePrefix ?? "") + RandomizerFactory.GetRandomizer(new FieldOptionsLastName()).Generate();

    string givenName =
        preDefines?.GivenName ??
        RandomizerFactory.GetRandomizer(new FieldOptionsFirstName()).Generate() + "";
    
    byte? age = DataMocking.DecideOptionalValue(
      new DataMocking.NullablePropertiesDecisionSourceDataAndOptions<byte?>
      {
        PreDefinedValue = preDefines?.Age,
        RandomValueGenerator = () => RandomValuesGenerator.GetRandomByte(minimalValue: 7, maximalValue: 110),
        Strategy = options.NullablePropertiesDecisionStrategy
      }
    );
    
    string? emailAddress = DataMocking.DecideOptionalValue(
      new DataMocking.NullablePropertiesDecisionSourceDataAndOptions<string?>
      {
        PreDefinedValue = preDefines?.EmailAddress,
        RandomValueGenerator = RandomValuesGenerator.GetRandomEmailAddress,
        Strategy = options.NullablePropertiesDecisionStrategy,
      }
    );

    string? phoneNumber = DataMocking.DecideOptionalValue(
      new DataMocking.NullablePropertiesDecisionSourceDataAndOptions<string?>()
      {
        PreDefinedValue = preDefines?.PhoneNumber,
        RandomValueGenerator = RandomValuesGenerator.GenerateRandomJapanesePhoneNumber,
        Strategy = options.NullablePropertiesDecisionStrategy
      }
    );
    
    return new Person
    {
      ID = ID,
      FamilyName = familyName,
      GivenName = givenName,
      Age = age,
      EmailAddress = emailAddress,
      PhoneNumber = phoneNumber
    };
    
  }

  
  private static uint counterForID_Generating;

  private static string GenerateID()
  {
    counterForID_Generating++;
    return $"PERSON-{counterForID_Generating}__GENERATED";
  }
  
}
