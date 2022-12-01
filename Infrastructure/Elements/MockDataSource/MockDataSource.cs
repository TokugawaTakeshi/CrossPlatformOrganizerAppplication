﻿using BusinessRules.Enterprise;
using Task = BusinessRules.Enterprise.Tasks.Task;

using Gateways;

using MockDataSource.Collections;
using MockDataSource.Entities;


namespace MockDataSource;


public class MockDataSource
{

  /* === データ ======================================================================================================= */
  public readonly List<Person> People;
  public readonly List<Task> Tasks;

  
  /* === 初期化 ======================================================================================================= */
  private static MockDataSource? _selfSoleInstance;

  public static MockDataSource GetInstance()
  {

    if (_selfSoleInstance == null)
    {
      _selfSoleInstance = new MockDataSource();
      Console.WriteLine("Mock data source has been initialized.");
    }

    return _selfSoleInstance;
    
  }
  
  private MockDataSource()
  {
    
    People = PeopleCollectionsMocker.Generate(new List<PeopleCollectionsMocker.Subset> {
      new() { Quantity = 10 },
      new() { Quantity = 10, NamePrefix = "SEARCH_TEST-" }
    });
    
    Tasks = new List<Task>(
      TasksCollectionsMocker.Generate(new [] {
        new TasksCollectionsMocker.Subset(quantity: 10),
        new TasksCollectionsMocker.Subset(quantity: 10) { Quantity = 10, AllOptionals = true }
      })
    );

  }



  /* === 人 ========================================================================================================= */
  public List<Person> RetrieveAllPeople()
  {
    return People;
  }

  public IPersonGateway.Adding.ResponseData AddPerson(IPersonGateway.Adding.RequestData requestData)
  {

    Person newPerson = PersonMocker.Generate(new PersonMocker.Options
    {
      Name = requestData.Name,
      Age = requestData.Age,
      EmailAddress = requestData.Email,
      PhoneNumber = requestData.PhoneNumber
    });

    People.Insert(0, newPerson);

    return new IPersonGateway.Adding.ResponseData(newPerson.ID);
  }

  public void UpdatePerson(IPersonGateway.Updating.RequestData requestData)
  {

    Person targetPerson = People.Find(person => person.ID == requestData.ID);

    targetPerson.Name = requestData.Name;
    targetPerson.Email = requestData.Email;
    targetPerson.PhoneNumber = requestData.PhoneNumber;
    targetPerson.Age = requestData.Age;
  }

  public void DeletePerson(uint targetPersonID)
  {
    People.RemoveAll(person => person.ID == targetPersonID);
  }
  
  
  /* === 課題 ======================================================================================================= */
  public Task[] RetrieveAllTasks()
  {
    return Tasks.ToArray();
  }

}