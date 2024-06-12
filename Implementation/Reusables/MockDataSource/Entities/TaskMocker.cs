using CommonSolution.Entities;
using Task = CommonSolution.Entities.Task;

using RandomDataGenerator.FieldOptions;
using RandomDataGenerator.Randomizers;

using YamatoDaiwa.CSharpExtensions.DataMocking;


namespace MockDataSource.Entities;


internal abstract class TaskMocker
{

  public struct PreDefines
  {
    internal string? ID { get; init; }
    internal string? title { get; init; }
    internal string? description { get; init; }
    internal bool? isComplete { get; init; }
    internal List<Task>? subtasks { get; init; }
    internal DateTime? associatedDateTime { get; init; }
    internal DateOnly? associatedDate { get; init; }
    internal Location? associatedLocation { get; init; }
  }

  public struct Dependencies
  {
    internal Location[] Locations { get; init; }
  }
  
  public struct Options
  {
    internal required DataMocking.NullablePropertiesDecisionStrategies NullablePropertiesDecisionStrategy { get; init; }
  }

  
  public static Task Generate(PreDefines? preDefines, Dependencies dependencies, Options options)
  {

    string ID = preDefines?.ID ?? GenerateID();

    
    string title =
        preDefines?.title ??
        RandomizerFactory.GetRandomizer(new FieldOptionsTextWords { Min = 1, Max = 10 }).Generate() + "";
    
    
    string? description = DataMocking.DecideOptionalValue(
      new DataMocking.NullablePropertiesDecisionSourceDataAndOptions<string?>
      {
        PreDefinedValue = preDefines?.description,
        RandomValueGenerator = () => RandomizerFactory.GetRandomizer(new FieldOptionsTextLipsum()).Generate(),
        Strategy = options.NullablePropertiesDecisionStrategy
      }
    );

    
    DateOnly today = DateOnly.FromDateTime(DateTime.UtcNow.Date);
    DateOnly oneYearLater = DateOnly.FromDateTime(DateTime.Today).AddYears(1);

    bool isComplete = preDefines?.isComplete ?? YamatoDaiwa.CSharpExtensions.RandomValuesGenerator.GetRandomBoolean();

    
    DateTime? deadlineDateTime = null; 
    DateOnly? deadlineDate = null;
    
    switch (options.NullablePropertiesDecisionStrategy)
    {

      case DataMocking.NullablePropertiesDecisionStrategies.mustGenerateAll:
      {
        
        deadlineDateTime = DataMocking.DecideOptionalValue(
          new DataMocking.NullablePropertiesDecisionSourceDataAndOptions<DateTime?>
          {
            PreDefinedValue = preDefines?.associatedDateTime,
            RandomValueGenerator = () => YamatoDaiwa.CSharpExtensions.RandomValuesGenerator.GetRandomDateTime(
              earliestDate: today, latestDate: oneYearLater
            ),
            Strategy = DataMocking.NullablePropertiesDecisionStrategies.
              mustGenerateWith50PercentageProbabilityIfHasNotBeenPreDefined
          }
        );

        if (deadlineDateTime is null)
        {
            
          deadlineDate = DataMocking.DecideOptionalValue(
            new DataMocking.NullablePropertiesDecisionSourceDataAndOptions<DateOnly?>
            {
              PreDefinedValue = preDefines?.associatedDate,
              RandomValueGenerator = () => YamatoDaiwa.CSharpExtensions.RandomValuesGenerator.GetRandomDate(
                earliestDate: today, latestDate: oneYearLater
              ),
              Strategy = DataMocking.NullablePropertiesDecisionStrategies.mustGenerateAll
            }
          );
      
        }
        
        break;
        
      }

      case DataMocking.NullablePropertiesDecisionStrategies.mustGenerateWith50PercentageProbabilityIfHasNotBeenPreDefined:
      {

        bool mustGenerateEitherAssociatedDateTimeOrDateOnly = YamatoDaiwa.CSharpExtensions.RandomValuesGenerator.
          GetRandomBoolean();
        
        deadlineDateTime = DataMocking.DecideOptionalValue(
          new DataMocking.NullablePropertiesDecisionSourceDataAndOptions<DateTime?>
          {
            PreDefinedValue = preDefines?.associatedDateTime,
            RandomValueGenerator = () => YamatoDaiwa.CSharpExtensions.RandomValuesGenerator.GetRandomDateTime(
              earliestDate: today, latestDate: oneYearLater
            ),
            Strategy = DataMocking.NullablePropertiesDecisionStrategies.
                mustGenerateWith50PercentageProbabilityIfHasNotBeenPreDefined
          }
        );

        if (deadlineDateTime is null)
        {
    
          deadlineDate = DataMocking.DecideOptionalValue(
            new DataMocking.NullablePropertiesDecisionSourceDataAndOptions<DateOnly?>
            {
              PreDefinedValue = preDefines?.associatedDate,
              RandomValueGenerator = () => YamatoDaiwa.CSharpExtensions.RandomValuesGenerator.GetRandomDate(
                earliestDate: today, latestDate: oneYearLater
              ),
              Strategy = mustGenerateEitherAssociatedDateTimeOrDateOnly ? 
                  DataMocking.NullablePropertiesDecisionStrategies.mustGenerateAll :
                  DataMocking.NullablePropertiesDecisionStrategies.
                      mustGenerateWith50PercentageProbabilityIfHasNotBeenPreDefined
            }
          );
      
        }
       
        break;
        
      }


      case DataMocking.NullablePropertiesDecisionStrategies.mustSkipIfHasNotBeenPreDefined:
      {
        
        deadlineDateTime = preDefines?.associatedDateTime;
        deadlineDate = preDefines?.associatedDate;
        
        break;
        
      }
      
    }
    
    
    Location? associatedLocation = DataMocking.DecideOptionalValue(
      new DataMocking.NullablePropertiesDecisionSourceDataAndOptions<Location?>
      {
        PreDefinedValue = preDefines?.associatedLocation,
        RandomValueGenerator = () => YamatoDaiwa.CSharpExtensions.RandomValuesGenerator.GetRandomArrayElement(dependencies.Locations),
        Strategy = options.NullablePropertiesDecisionStrategy
      }
    ); 
    
    
    return new Task
    {
      ID = ID,
      title = title,
      description = description,
      isComplete = isComplete,
      subtasks = preDefines?.subtasks ?? [],
      deadlineDateTime = deadlineDateTime,
      deadlineDate = deadlineDate,
      associatedLocation = associatedLocation
    };

  }


  private static (DateTime? deadlineDateTime, DateOnly? deadlineDate) generateDeadlineFields(
    PreDefines? preDefines, Options options
  )
  {
   
    DateOnly today = DateOnly.FromDateTime(DateTime.UtcNow.Date);
    DateOnly oneYearLater = DateOnly.FromDateTime(DateTime.Today).AddYears(1);
    
    DateTime? deadlineDateTime = null; 
    DateOnly? deadlineDate = null;
    
    switch (options.NullablePropertiesDecisionStrategy)
    {

      case DataMocking.NullablePropertiesDecisionStrategies.mustGenerateAll:
      {
        
        deadlineDateTime = DataMocking.DecideOptionalValue(
          new DataMocking.NullablePropertiesDecisionSourceDataAndOptions<DateTime?>
          {
            PreDefinedValue = preDefines?.associatedDateTime,
            RandomValueGenerator = () => YamatoDaiwa.CSharpExtensions.RandomValuesGenerator.GetRandomDateTime(
              earliestDate: today, latestDate: oneYearLater
            ),
            Strategy = DataMocking.NullablePropertiesDecisionStrategies.
              mustGenerateWith50PercentageProbabilityIfHasNotBeenPreDefined
          }
        );

        if (deadlineDateTime is null)
        {
            
          deadlineDate = DataMocking.DecideOptionalValue(
            new DataMocking.NullablePropertiesDecisionSourceDataAndOptions<DateOnly?>
            {
              PreDefinedValue = preDefines?.associatedDate,
              RandomValueGenerator = () => YamatoDaiwa.CSharpExtensions.RandomValuesGenerator.GetRandomDate(
                earliestDate: today, latestDate: oneYearLater
              ),
              Strategy = DataMocking.NullablePropertiesDecisionStrategies.mustGenerateAll
            }
          );
      
        }
        
        break;
        
      }

      case DataMocking.NullablePropertiesDecisionStrategies.mustGenerateWith50PercentageProbabilityIfHasNotBeenPreDefined:
      {

        bool mustGenerateEitherAssociatedDateTimeOrDateOnly = YamatoDaiwa.CSharpExtensions.RandomValuesGenerator.
          GetRandomBoolean();
        
        deadlineDateTime = DataMocking.DecideOptionalValue(
          new DataMocking.NullablePropertiesDecisionSourceDataAndOptions<DateTime?>
          {
            PreDefinedValue = preDefines?.associatedDateTime,
            RandomValueGenerator = () => YamatoDaiwa.CSharpExtensions.RandomValuesGenerator.GetRandomDateTime(
              earliestDate: today, latestDate: oneYearLater
            ),
            Strategy = DataMocking.NullablePropertiesDecisionStrategies.
                mustGenerateWith50PercentageProbabilityIfHasNotBeenPreDefined
          }
        );

        if (deadlineDateTime is null)
        {
    
          deadlineDate = DataMocking.DecideOptionalValue(
            new DataMocking.NullablePropertiesDecisionSourceDataAndOptions<DateOnly?>
            {
              PreDefinedValue = preDefines?.associatedDate,
              RandomValueGenerator = () => YamatoDaiwa.CSharpExtensions.RandomValuesGenerator.GetRandomDate(
                earliestDate: today, latestDate: oneYearLater
              ),
              Strategy = mustGenerateEitherAssociatedDateTimeOrDateOnly ? 
                  DataMocking.NullablePropertiesDecisionStrategies.mustGenerateAll :
                  DataMocking.NullablePropertiesDecisionStrategies.
                      mustGenerateWith50PercentageProbabilityIfHasNotBeenPreDefined
            }
          );
      
        }
       
        break;
        
      }


      case DataMocking.NullablePropertiesDecisionStrategies.mustSkipIfHasNotBeenPreDefined:
      {
        
        deadlineDateTime = preDefines?.associatedDateTime;
        deadlineDate = preDefines?.associatedDate;
        
        break;
        
      }
      
    }


    return (deadlineDateTime: deadlineDateTime, deadlineDate: deadlineDate);

  }
  
  
  private static uint counterForID_Generating;

  private static string GenerateID()
  {
    counterForID_Generating++;
    return $"TASK-{counterForID_Generating}__GENERATED";
  }
  
}