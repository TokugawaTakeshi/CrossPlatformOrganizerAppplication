using CommonSolution.Entities;
using CommonSolution.Gateways;
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace EntityFramework.Gateways;


public class PersonEntityFrameworkGateway(
  Microsoft.EntityFrameworkCore.IDbContextFactory<DatabaseContext> contextFactory
) : PersonGateway
{
  
  /* ━━━ Retrieving ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public override System.Threading.Tasks.Task<Person[]> RetrieveAll()
  {
    
    using DatabaseContext databaseContext = contextFactory.CreateDbContext();
    
    return System.Threading.Tasks.Task.FromResult(
      databaseContext.PeopleModels.Select(personModel => personModel.ToBusinessRulesEntity()).ToArray()
    );
    
  }
  
  public override Task<SelectionRetrieving.ResponseData> RetrieveSelection(
    SelectionRetrieving.RequestParameters? requestParameters
  )
  {
    
    using DatabaseContext databaseContext = contextFactory.CreateDbContext();
    
    Person[] allPeople = databaseContext.
        PeopleModels.
        Select(personModel => personModel.ToBusinessRulesEntity()).
        ToArray();
    
    uint totalItemsCount = Convert.ToUInt32(allPeople.Length);

    Person[] peopleSelection = PersonGateway.Filter(allPeople, requestParameters);
    
    return System.Threading.Tasks.Task.FromResult(
      new PersonGateway.SelectionRetrieving.ResponseData
      {
        Items = peopleSelection,
        TotalItemsCountInSelection = Convert.ToUInt32(peopleSelection.Length),
        TotalItemsCount = Convert.ToUInt32(totalItemsCount)
      }
    );
    
  }

  
  /* ━━━ Adding ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public override async System.Threading.Tasks.Task<Person> Add(Adding.RequestData requestData)
  {
    
    await using DatabaseContext databaseContext = await contextFactory.CreateDbContextAsync();
    
    EntityEntry<PersonModel> newPerson = databaseContext.PeopleModels.Add(
      new PersonModel
      {
        FamilyName = requestData.FamilyName,
        GivenName = requestData.GivenName,
        FamilyNameSpell = requestData.FamilyNameSpell,
        GivenNameSpell = requestData.GivenNameSpell,
        Gender = requestData.Gender,
        BirthYear = requestData.BirthYear,
        BirthMonthNumber__NumerationFrom1 = requestData.BirthMonthNumber__NumerationFrom1,
        BirthDayOfMonth__NumerationFrom1 = requestData.BirthDayOfMonth__NumerationFrom1,
        EmailAddress = requestData.EmailAddress,
        PhoneNumber__DigitsOnly = requestData.PhoneNumber__DigitsOnly
      }
    );

    await databaseContext.SaveChangesAsync();

    return newPerson.Entity.ToBusinessRulesEntity();

  }
  
  
  /* ━━━ Updating ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public override async System.Threading.Tasks.Task<Person> Update(
    PersonGateway.Updating.RequestData requestData
  )
  {
    
    await using DatabaseContext databaseContext = await contextFactory.CreateDbContextAsync();
    
    PersonModel targetPersonModel = databaseContext.PeopleModels.
      First(personModel => personModel.ID == requestData.ID);
    
    targetPersonModel.FamilyName = requestData.FamilyName;
    targetPersonModel.GivenName = requestData.GivenName;
    targetPersonModel.FamilyNameSpell = requestData.FamilyNameSpell;
    targetPersonModel.GivenNameSpell = requestData.GivenNameSpell;

    targetPersonModel.Gender = requestData.Gender;
    targetPersonModel.BirthYear = requestData.BirthYear;
    targetPersonModel.BirthMonthNumber__NumerationFrom1 = requestData.BirthMonthNumber__NumerationFrom1;
    targetPersonModel.BirthDayOfMonth__NumerationFrom1 = requestData.BirthDayOfMonth__NumerationFrom1;
    
    targetPersonModel.EmailAddress = requestData.EmailAddress;
    targetPersonModel.PhoneNumber__DigitsOnly = requestData.PhoneNumber__DigitsOnly;

    await databaseContext.SaveChangesAsync();

    return targetPersonModel.ToBusinessRulesEntity();

  }

  
  /* ━━━ Deleting ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public override async System.Threading.Tasks.Task Delete(string targetPersonID)
  {
    await using DatabaseContext databaseContext = await contextFactory.CreateDbContextAsync();
    await databaseContext.PeopleModels.Where(personModel => personModel.ID == targetPersonID).ExecuteDeleteAsync();
  }
  
}