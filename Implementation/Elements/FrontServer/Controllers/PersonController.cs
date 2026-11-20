using Person = CommonSolution.Entities.Person;
using CommonSolution.Gateways;
using ClientAndFrontServer.Transactions;


namespace FrontServer.Controllers;


[Microsoft.AspNetCore.Mvc.ApiController]
public class PersonController(
  PersonGateway personGateway
) : Microsoft.AspNetCore.Mvc.ControllerBase
{
  
  /* ━━━ Retrieving ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  [Microsoft.AspNetCore.Mvc.HttpGet(PeopleTransactions.RetrievingOfAll.URN_PATH)]
  public async System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.ActionResult<Person[]>> RetrieveAllPeople()
  {
    return base.Ok(await personGateway.RetrieveAll());
  }
  
  [Microsoft.AspNetCore.Mvc.HttpGet(PeopleTransactions.RetrievingOfSelection.URN_PATH)]
  public async System.Threading.Tasks.Task<
    Microsoft.AspNetCore.Mvc.ActionResult<PersonGateway.SelectionRetrieving.ResponseData>
  > RetrievePeopleSelection(
    [
      Microsoft.AspNetCore.Mvc.FromQuery(
        Name=PeopleTransactions.RetrievingOfSelection.QueryParameters.searchingByFullOrPartialNameOrItsSpell
      )
    ] string? searchingByFullOrPartialNameOrItsSpell
  ) {
    return base.Ok(
      await personGateway.RetrieveSelection(
      new PersonGateway.SelectionRetrieving.RequestParameters
      {
        SearchingByFullOrPartialNameOrItsSpell = searchingByFullOrPartialNameOrItsSpell
      }
    ));
    
  }
  
  
  /* ━━━ Adding ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  [Microsoft.AspNetCore.Mvc.HttpPost(PeopleTransactions.Adding.URN_PATH)]
  public async System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.ActionResult<Person>> AddTask(
    [Microsoft.AspNetCore.Mvc.FromBody] PersonGateway.Adding.RequestData requestData
  ) {
    return base.Ok(
      await personGateway.Add(requestData)
    );
  }
  
  
  /* ━━━ Updating ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  [Microsoft.AspNetCore.Mvc.HttpPut(PeopleTransactions.Updating.URN_PATH)]
  public async System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.ActionResult> UpdateTask(
    [Microsoft.AspNetCore.Mvc.FromBody] PersonGateway.Updating.RequestData requestData
  ) {
    return base.Ok(
      await personGateway.Update(requestData)
    );
  }

  
  /* ━━━ Deleting ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  [Microsoft.AspNetCore.Mvc.HttpDelete(PeopleTransactions.Deleting.URN_PATH_TEMPLATE)]
  public async System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.ActionResult> Delete(string targetPersonID) {
    await personGateway.Delete(targetPersonID);
    return base.Ok();
  }
  
}