using CommonSolution.Entities;
using CommonSolution.Gateways;
using Task = CommonSolution.Entities.Task.Task;

using MockDataSource.Collections;
using MockDataSource.Entities;
using MockDataSource.Utils;

using System.Diagnostics;


namespace MockDataSource;


public class MockDataSource
{

  /* === データ ======================================================================================================= */
  public readonly List<Person> People;
  public readonly List<Task> Tasks;

  
  /* === 初期化 ====================================================================================================== */
  private static MockDataSource? _selfSoleInstance;

  public static MockDataSource GetInstance()
  {

    if (_selfSoleInstance == null)
    {
      _selfSoleInstance = new MockDataSource();
      Debug.WriteLine("Mock data source has been initialized.");
    }

    return _selfSoleInstance;
    
  }
  
  private MockDataSource()
  {
    
    People = PeopleCollectionsMocker.Generate(new PeopleCollectionsMocker.Subset[] {
      new()
      {
        NullablePropertiesDecisionStrategy = DataMocking.NullablePropertiesDecisionStrategies.mustGenerateAll, 
        Quantity = 5
      },
      new()
      {
        NullablePropertiesDecisionStrategy = DataMocking.NullablePropertiesDecisionStrategies.mustGenerateWith50PercentageProbability,
        Quantity = 5
      },
      new()
      {
        FamilyNamePrefix = "SEARCH_TEST-", 
        NullablePropertiesDecisionStrategy = DataMocking.NullablePropertiesDecisionStrategies.mustGenerateWith50PercentageProbability,
        Quantity = 5
      }
    }).ToList();

    Tasks = TasksCollectionsMocker.Generate(new TasksCollectionsMocker.Subset[] {
      new()
      {
        NullablePropertiesDecisionStrategy = DataMocking.NullablePropertiesDecisionStrategies.mustGenerateAll,
        Quantity = 5
      },
      new()
      {
        NullablePropertiesDecisionStrategy = DataMocking.NullablePropertiesDecisionStrategies.mustGenerateWith50PercentageProbability,
        Quantity = 5
      }
    }).ToList();

  }


  /* === 人 ========================================================================================================= */
  public Person[] RetrieveAllPeople()
  {
    return People.ToArray();
  }

  public IPersonGateway.Adding.ResponseData AddPerson(IPersonGateway.Adding.RequestData requestData)
  {

    Person newPerson = PersonMocker.Generate(
      new PersonMocker.PreDefines 
      {
        FamilyName = requestData.FamilyName,
        GivenName = requestData.GivenName,
        Age = requestData.Age,
        EmailAddress = requestData.EmailAddress,
        PhoneNumber = requestData.PhoneNumber
      },
      new PersonMocker.Options
      {
        NullablePropertiesDecisionStrategy = DataMocking.NullablePropertiesDecisionStrategies.mustSkipIfHasNotBeenPreDefined
      }
    );

    People.Insert(0, newPerson);

    return new IPersonGateway.Adding.ResponseData { AddedPersonID = newPerson.ID };
    
  }

  public void UpdatePerson(IPersonGateway.Updating.RequestData requestData)
  {

    Person? targetPerson = People.Find(person => person.ID == requestData.ID);

    if (targetPerson == null)
    {
      throw new InvalidDataException($"ID「${ requestData.ID }」の人が発見されず。");
    }

    targetPerson.FamilyName = requestData.FamilyName;
    targetPerson.GivenName = requestData.GivenName;
    targetPerson.Age = requestData.Age;
    targetPerson.EmailAddress = requestData.EmailAddress;
    targetPerson.PhoneNumber = requestData.PhoneNumber;
    
  }

  public void DeletePerson(string targetPersonID)
  {
    People.RemoveAll(person => person.ID == targetPersonID);
  }
  
  
  /* === 課題 ======================================================================================================= */
  public Task[] RetrieveAllTasks()
  {
    return Tasks.ToArray();
  }

  public ITaskGateway.Adding.ResponseData AddTask(ITaskGateway.Adding.RequestData requestData)
  {

    Task newTask = TaskMocker.Generate(
      new TaskMocker.PreDefines
      {
        Title = requestData.Title,
        Description = requestData.Description,
        Subtasks = requestData.SubtasksIDs == null ? 
          null : Tasks.FindAll(task => requestData.SubtasksIDs.Any(task.ID.Contains)) 
      },
      new TaskMocker.Options()
      {
        NullablePropertiesDecisionStrategy =
          DataMocking.NullablePropertiesDecisionStrategies.mustSkipIfHasNotBeenPreDefined
      }
    );
    
    Tasks.Insert(0, newTask);

    return new ITaskGateway.Adding.ResponseData() { AddedTaskID = newTask.ID };

  }

  public void UpdateTask(ITaskGateway.Updating.RequestData requestData)
  {

    Task? targetTask = Tasks.Find(task => task.ID == requestData.ID);

    if (targetTask == null)
    {
      throw new InvalidDataException($"ID「${ requestData.ID }」の課題が発見されず。");
    }

    targetTask.Title = requestData.Title;
    targetTask.Description = requestData.Description;

    if (requestData.SubtasksIDs != null)
    {
      targetTask.Subtasks = Tasks.FindAll(task => requestData.SubtasksIDs.Any(task.ID.Contains));
    }

    targetTask.IsComplete = requestData.IsComplete;

  }

  public void DeleteTask(string targetTaskID)
  {
    Tasks.RemoveAll(tasks => tasks.ID == targetTaskID);
  }

}