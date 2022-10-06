using BusinessRules.Enterprise;
using Gateways;
using Client.LocalDataBase.Models;


namespace Client.LocalDataBase.Gateways;


// TODO パフォーマンス対策を行う https://github.com/TokugawaTakeshi/ExperimentalCSharpApplication1/issues/5
public class PersonLocalEF_SQLiteGateway : IPersonGateway
{
  
  // TODO 再利用方法を考える https://github.com/TokugawaTakeshi/ExperimentalCSharpApplication1/issues/6
  private readonly LocalDataBaseContext _dataBaseContext = new LocalDataBaseContext(); 
  
  // TODO エラーを修正する
  public Task<List<Person>> RetrieveAll()
  {
    return Task.FromResult(_dataBaseContext.PeopleModels.ToList());
  }

  // TODO 相談の上実装 https://github.com/TokugawaTakeshi/ExperimentalCSharpApplication1/issues/8
  public Task<IPersonGateway.SelectionRetrieving.ResponseData> RetrieveSelection(IPersonGateway.SelectionRetrieving.RequestParameters requestParameters)
  {
    throw new NotImplementedException();
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