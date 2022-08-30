using BusinessRules.Enterprise;
using Gateways;
using MockDataSource.Collections;
using MockDataSource.Entities;


namespace MockDataSource
{
  public class MockDataSource
  {

    private static MockDataSource selfSoleInstance;


    public static MockDataSource getInstance()
    {

      if (selfSoleInstance == null)
      {
        selfSoleInstance = new MockDataSource();
        Console.WriteLine("Mock data source has been initialized.");
      }

      return selfSoleInstance;
    }


    private MockDataSource()
    {
      People = PeopleCollectionsMocker.Generate(new List<PeopleCollectionsMocker.Subset> {
        new PeopleCollectionsMocker.Subset { Quantity = 10 },
        new PeopleCollectionsMocker.Subset { Quantity = 10, NamePrefix = "SEARCH_TEST-" }
      });
    }


    /* === 人 ======================================================================================================= */
    public readonly List<Person> People;


    /* --- 取得 ----------------------------------------------------------------------------------------------------- */
    public List<Person> RetrieveAllPeople()
    {
      return People;
    }


    /* --- 追加 ------------------------------------------------------------------------------------------------------ */
    public IPersonGateway.Adding.ResponseData AddPerson(IPersonGateway.Adding.RequestData requestData)
    {

      Person newPerson = PersonMocker.GenerateEntity(new PersonMocker.Options
      {
        Name = requestData.Name,
        Age = requestData.Age,
        EmailAddress = requestData.Email,
        PhoneNumber = requestData.PhoneNumber
      });

      People.Insert(0, newPerson);

      return new IPersonGateway.Adding.ResponseData(newPerson.ID);
    }


    /* --- 編集 ----------------------------------------------------------------------------------------------------- */
    public void UpdatePerson(IPersonGateway.Updating.RequestData requestData)
    {

      Person targetPerson = People.Find(person => person.ID == requestData.ID);

      targetPerson.Name = requestData.Name;
      targetPerson.Email = requestData.Email;
      targetPerson.PhoneNumber = requestData.PhoneNumber;
      targetPerson.Age = requestData.Age;
    }

    /* --- 削除 ----------------------------------------------------------------------------------------------------- */
    public void DeletePerson(uint targetPersonID)
    {
      People.RemoveAll(person => person.ID == targetPersonID);
    }
  }
}
