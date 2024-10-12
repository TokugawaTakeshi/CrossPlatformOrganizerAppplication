using CommonSolution.Entities;
using CommonSolution.Gateways;

using MockDataSource.Entities;
using MockDataSource.Collections;
using MockDataSource.SamplesRepositories;
using MockDataSource.AdditionalStructures;

using CommonSolution.Entities.Task;
using CommonSolution.Gateways.Task;
using YamatoDaiwa.CSharpExtensions.DataMocking;
using Task = CommonSolution.Entities.Task.Task;


namespace MockDataSource;


public static class MockDataSource
{

  /* ━━━ Data ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public static readonly List<Person> People;
  public static readonly List<Task> Tasks;
  public static readonly List<TaskCustomFolder> TaskCustomFolders;
  public static readonly List<Location> Locations;


  /* ━━━ Initialization ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  static MockDataSource()
  {
    
    MockDataSource.People = PeopleCollectionsMocker.Generate([
      new PeopleCollectionsMocker.Subset
      {
        NullablePropertiesDecisionStrategy = DataMocking.NullablePropertiesDecisionStrategies.
            mustGenerateWith50PercentageProbabilityIfHasNotBeenPreDefined,
        WithNames = PeopleNamesRepository.PeopleNames,
        Quantity = (uint)PeopleNamesRepository.PeopleNames.Length
      },
      new PeopleCollectionsMocker.Subset
      {
        NullablePropertiesDecisionStrategy = DataMocking.NullablePropertiesDecisionStrategies.mustGenerateAll, 
        Quantity = 5
      },
      new PeopleCollectionsMocker.Subset
      {
        NullablePropertiesDecisionStrategy = DataMocking.NullablePropertiesDecisionStrategies.
            mustGenerateWith50PercentageProbabilityIfHasNotBeenPreDefined,
        Quantity = 5
      },
      new PeopleCollectionsMocker.Subset
      {
        FamilyNamePrefix = "SEARCH_TEST-", 
        NullablePropertiesDecisionStrategy = DataMocking.NullablePropertiesDecisionStrategies.
            mustGenerateWith50PercentageProbabilityIfHasNotBeenPreDefined,
        Quantity = 5
      },
      new PeopleCollectionsMocker.Subset
      {
        NullablePropertiesDecisionStrategy = DataMocking.NullablePropertiesDecisionStrategies.
            mustGenerateWith50PercentageProbabilityIfHasNotBeenPreDefined,
        WithNames =
        [
          new PersonNameData
          {
            FamilyName = "OverflowTest:ÀÇĤfhjgpjklbĜiEstosTreMalfacileEnvolverLaVicoAbcdefghijklmnopqrstuvwxyza",
            FamilyNameSpell = "OverflowTest:ÀÇĤfhjgpjklbĜiEstosTreMalfacileEnvolverLaVicoAbcdefghijklmnopqrstuvwxyza",
            GivenName = "OverflowTest:ÀÇĤfhjgpjklbĜiEstosTreMalfacileEnvolverLaVicoAbcdefghijklmnopqrstuvwxyza",
            GivenNameSpell = "OverflowTest:ÀÇĤfhjgpjklbĜiEstosTreMalfacileEnvolverLaVicoAbcdefghijklmnopqrstuvwxyza",
            IsGivenNameForMales = true
          }
        ],
        Quantity = 1
      }
    ]).ToList();

    MockDataSource.Locations = LocationSamplesRepository.Locations.ToList();
    
    MockDataSource.Tasks = SampleTasksRepository.Tasks.Concat(
      TasksCollectionsMocker.Generate(
        [
          new TasksCollectionsMocker.Subset
          {
            NullablePropertiesDecisionStrategy = DataMocking.NullablePropertiesDecisionStrategies.mustGenerateAll,
            Quantity = 10
          },
          new TasksCollectionsMocker.Subset
          {
            NullablePropertiesDecisionStrategy = DataMocking.NullablePropertiesDecisionStrategies.mustGenerateWith50PercentageProbabilityIfHasNotBeenPreDefined,
            Quantity = 5
          }
        ],
        new TasksCollectionsMocker.Dependencies
        {
          Locations = MockDataSource.Locations.ToArray()
        }
      )
    ).ToList();

    MockDataSource.TaskCustomFolders = SampleTasksCustomFoldersRepository.taskCustomFolders;

  }
  
  public static void SetRelationships()
  {
    SampleTasksCustomFoldersRepository.SetRelationships();
  } 


  /* ━━━ People ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public static Person[] RetrieveAllPeople()
  {
    return People.Select(person => person.clone()).ToArray();
  }

  public static Person AddPerson(PersonGateway.Adding.RequestData requestData)
  {

    Person newPerson = PersonMocker.Generate(
      new PersonMocker.PreDefines 
      {
        familyName = requestData.FamilyName,
        givenName = requestData.GivenName,
        familyNameSpell = requestData.FamilyNameSpell,
        givenNameSpell = requestData.GivenNameSpell,
        gender = requestData.Gender,
        avatarURI = requestData.AvatarURI,
        birthYear = requestData.BirthYear, 
        birthMonthNumber__numerationFrom1 = requestData.BirthMonthNumber__NumerationFrom1,
        birthDayOfMonth__numerationFrom1 = requestData.BirthDayOfMonth__NumerationFrom1,
        emailAddress = requestData.EmailAddress,
        phoneNumber = requestData.PhoneNumber__DigitsOnly
      },
      new PersonMocker.Options
      {
        NullablePropertiesDecisionStrategy = DataMocking.NullablePropertiesDecisionStrategies.mustSkipIfHasNotBeenPreDefined
      }
    );

    People.Insert(0, newPerson);

    return newPerson;

  }

  public static Person UpdatePerson(PersonGateway.Updating.RequestData requestData)
  {

    Person? targetPerson = People.Find(person => person.ID == requestData.ID);

    if (targetPerson == null)
    {
      throw new InvalidDataException($"The person with ID \"{ requestData.ID }\" not found.");
    }
    
    
    targetPerson.familyName = requestData.FamilyName;
    targetPerson.givenName = requestData.GivenName;
    targetPerson.familyNameSpell = requestData.FamilyNameSpell;
    targetPerson.givenNameSpell = requestData.GivenNameSpell;
    targetPerson.gender = requestData.Gender;
    targetPerson.birthYear = requestData.BirthYear;
    targetPerson.birthMonthNumber__numerationFrom1 = requestData.BirthMonthNumber__NumerationFrom1;
    targetPerson.birthDayOfMonth__numerationFrom1 = requestData.BirthDayOfMonth__NumerationFrom1;
    targetPerson.emailAddress = requestData.EmailAddress;
    targetPerson.phoneNumber__digitsOnly = requestData.PhoneNumber__DigitsOnly;

    return targetPerson;

  }

  public static void DeletePerson(string targetPersonID)
  {
    People.RemoveAll(person => person.ID == targetPersonID);
  }
  
  
  /* ━━━ Tasks ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public static Task[] RetrieveAllTasks()
  {
    return Tasks.Select(task => task.clone()).ToArray();
  }

  public static Task AddTask(TaskGateway.Adding.RequestData requestData)
  {

    Task newTask = TaskMocker.Generate(
      new TaskMocker.PreDefines
      {
        title = requestData.Title,
        description = requestData.Description,
        isComplete = requestData.IsComplete,
        subtasks = requestData.SubtasksIDs == null ? 
          null : Tasks.FindAll(task => requestData.SubtasksIDs.Any(task.ID.Contains)),
        // associatedDateTime = requestData.AssociatedDate__ISO8601 is not null ? 
        //     DateTimeExtensions.CreateDateTimeFromISO8601_String(requestData.AssociatedDate__ISO8601) : null,
        // associatedDate = requestData.AssociatedDate__ISO8601 is not null ?
        //     DateOnlyExtensions.CreateDateOnlyFromISO8601_String(requestData.AssociatedDate__ISO8601) : null,
        associatedLocation = requestData.AssociatedLocation
      },
      new TaskMocker.Dependencies
      {
        Locations = MockDataSource.Locations.ToArray()
      },
      new TaskMocker.Options
      {
        NullablePropertiesDecisionStrategy =
          DataMocking.NullablePropertiesDecisionStrategies.mustSkipIfHasNotBeenPreDefined
      }
    );
    
    Tasks.Insert(0, newTask);

    return newTask;

  }

  public static Task UpdateTask(TaskGateway.Updating.RequestData requestData)
  {

    Task? targetTask = Tasks.Find(task => task.ID == requestData.ID);

    if (targetTask == null)
    {
      throw new InvalidDataException($"The task with ID \"{ requestData.ID }\" not found.");
    }

    targetTask.title = requestData.Title;
    targetTask.description = requestData.Description;
    targetTask.isCompleted = requestData.IsCompleted;
    
    if (requestData.SubtasksIDs != null)
    {
      targetTask.subtasks = Tasks.FindAll(task => requestData.SubtasksIDs.Any(task.ID.Contains));
    }

    targetTask.deadlineDateTime = targetTask.deadlineDateTime;
    targetTask.deadlineDate = targetTask.deadlineDate;

    targetTask.associatedLocation = targetTask.associatedLocation;

    return targetTask;

  }

  public static void DeleteTask(string targetTaskID)
  {
    Tasks.RemoveAll(tasks => tasks.ID == targetTaskID);
  }

}