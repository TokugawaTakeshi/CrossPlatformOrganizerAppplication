using BusinessRules.Enterprise;
using Gateways;
using Client.LocalDataBase.Models;


namespace Client.LocalDataBase.Gateways;


// TODO パフォーマンス対策を行う https://github.com/TokugawaTakeshi/ExperimentalCSharpApplication1/issues/5
public class PersonLocalEF_SQLiteGateway : IPersonGateway
{
  
  private readonly LocalDataBaseContext _dataBaseContext = LocalDataBaseContext.GetInstance(); 
  
  public Task<List<Person>> RetrieveAll()
  {
    // TODO 何をやったか、理解する https://github.com/TokugawaTakeshi/ExperimentalCSharpApplication1/issues/7
    return Task.FromResult(_dataBaseContext.PeopleModels.Select(_ => (Person)_).ToList());
  }

  // TODO 相談の上実装 https://github.com/TokugawaTakeshi/ExperimentalCSharpApplication1/issues/8
  public Task<IPersonGateway.SelectionRetrieving.ResponseData> RetrieveSelection(
    IPersonGateway.SelectionRetrieving.RequestParameters requestParameters
  )
  {

    List<PersonModel> filteredItems;

    if (String.IsNullOrEmpty(requestParameters.FilteringByName))
    {
      filteredItems = _dataBaseContext.PeopleModels.ToList();
    }
    else
    {
      filteredItems = _dataBaseContext.PeopleModels.Where(
        personModel => personModel.Name.Contains(requestParameters.FilteringByName)
      ).ToList(); 
    }

    return Task.FromResult(new IPersonGateway.SelectionRetrieving.ResponseData(
      totalItemsCount: (uint)_dataBaseContext.PeopleModels.Count(),
      totalItemsCountInSelection: (uint)filteredItems.Count,
      selectionItemsOfSpecifiedPaginationPage: filteredItems.
        Skip((int)(requestParameters.PaginationPageNumber * requestParameters.ItemsCountPerPaginationPage)).
        Take((int)requestParameters.ItemsCountPerPaginationPage).
        Select(_ => (Person)_).ToList())
    );
  }

  // TODO 相談の上実装　https://github.com/TokugawaTakeshi/ExperimentalCSharpApplication1/issues/3
  public Task<IPersonGateway.Adding.ResponseData> Add(IPersonGateway.Adding.RequestData requestData)
  {
    _dataBaseContext.Add(new PersonModel());
    throw new NotImplementedException();
  }

  public Task Update(IPersonGateway.Updating.RequestData requestData)
  {
    
    Person targetPerson = _dataBaseContext.PeopleModels.First(personModel => personModel.ID == requestData.ID);

    targetPerson.Name = requestData.Name;
    targetPerson.Email = requestData.Email;
    targetPerson.PhoneNumber = requestData.PhoneNumber;
    targetPerson.Age = requestData.Age;

    _dataBaseContext.Update(targetPerson);
    return _dataBaseContext.SaveChangesAsync();
  }

  public Task Delete(uint targetPersonID)
  {
    _dataBaseContext.Remove(_dataBaseContext.PeopleModels.First(personModel => personModel.ID == targetPersonID));
    return _dataBaseContext.SaveChangesAsync();
  }
}