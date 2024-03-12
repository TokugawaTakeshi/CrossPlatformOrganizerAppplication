using CommonSolution.Gateways;

using ClientAndFrontServer;

using System.Text;
using System.Text.Json;
using CommonSolution.Entities;
using Utils;
using YamatoDaiwa.CSharpExtensions;
using YamatoDaiwa.CSharpExtensions.Exceptions;


namespace Client.Data.FromServer;


public class PersonHTTP_ClientGateway : PersonGateway
{

  private readonly HTTP_Client HTTP_Client = HTTP_Client.getSoleInstance();
  private readonly JsonSerializerOptions serializerOptions = new() { PropertyNamingPolicy = null };
  
  
  /* ━━━ Retrieving ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public override async Task<Person[]> RetrieveAll()
  {

    HttpResponseMessage response = await this.HTTP_Client.GetAsync(
      new Uri(String.Format(PeopleTransactions.RetrievingOfAll.URN_PATH))
    );

    if (response.IsSuccessStatusCode)
    {
      return JsonSerializer.Deserialize<Person[]>(await response.Content.ReadAsStringAsync(), this.serializerOptions)!;
    }
    
    
    throw new Exception(response.ReasonPhrase);
    
  }
  
  public override async Task<SelectionRetrieving.ResponseData> RetrieveSelection(
    SelectionRetrieving.RequestParameters? requestParameters
  )
  {
    
    HttpResponseMessage response = await this.HTTP_Client.GetAsync(
      URI_Builder.Build(
        new URI_Builder.SourceData
        {
          origin = ClientToFrontServerConnection.ORIGIN,
          path = PeopleTransactions.RetrievingOfSelection.URN_PATH,
          queryParameters = new Dictionary<string, object>().
              SetPairIfValueNotIsNull(
                PeopleTransactions.RetrievingOfSelection.QueryParameters.searchingByFullOrPartialNameOrItsSpell, 
                requestParameters?.SearchingByFullOrPartialNameOrItsSpell
              )
        }
      )
    );
    
    if (response.IsSuccessStatusCode)
    {
      return JsonSerializer.Deserialize<PersonGateway.SelectionRetrieving.ResponseData>(
        await response.Content.ReadAsStringAsync(),
        this.serializerOptions
      );
    }
    
    
    throw new DataRetrievingFailedException(
      $"Failed to retrieve people selection.\n{ response.ReasonPhrase }"
    );
    
  }
  
  /* ━━━ Adding ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public override async System.Threading.Tasks.Task<Person> Add(Adding.RequestData requestData)
  {
    
    HttpResponseMessage response = await this.HTTP_Client.PostAsync(
      URI_Builder.Build(
        new URI_Builder.SourceData
        {
          origin = ClientToFrontServerConnection.ORIGIN,
          path = PeopleTransactions.Adding.URN_PATH
        }
      ),
      new StringContent(
        JsonSerializer.Serialize(requestData, this.serializerOptions),
        Encoding.UTF8,
        "application/json"
      )
    );

    if (response.IsSuccessStatusCode)
    {
      return JsonSerializer.Deserialize<Person>(
        await response.Content.ReadAsStringAsync(),
        this.serializerOptions
      );
    }
    
    
    throw new DataRetrievingFailedException($"Failed add the new person.\n{ response.ReasonPhrase }");
    
  }
  
  
  /* ━━━ Updating ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public override async System.Threading.Tasks.Task<CommonSolution.Entities.Person> Update(
    Updating.RequestData requestData
  )
  {
    
    HttpResponseMessage response = await this.HTTP_Client.PutAsync(
      URI_Builder.Build(
        new URI_Builder.SourceData
        {
          origin = ClientToFrontServerConnection.ORIGIN,
          path = PeopleTransactions.Updating.URN_PATH
        }
      ),
      new StringContent(
        JsonSerializer.Serialize(requestData, this.serializerOptions),
        Encoding.UTF8,
        "application/json"
      )
    );
    
    if (response.IsSuccessStatusCode)
    {
      return JsonSerializer.Deserialize<CommonSolution.Entities.Person>(
        await response.Content.ReadAsStringAsync(),
        this.serializerOptions
      );
    }
    
    throw new DataRetrievingFailedException(
      $"Failed to update the person with ID \"{ requestData.ID }\".\n{ response.ReasonPhrase }"
    );
    
  }
  
  
  /* ━━━ Delete ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public override async System.Threading.Tasks.Task Delete(string targetPersonID)
  {
    await this.HTTP_Client.DeleteAsync(
      new Uri(
        URI_Builder.Build(
          new URI_Builder.SourceData
          {
            origin = ClientToFrontServerConnection.ORIGIN,
            path = PeopleTransactions.Deleting.buildURN(targetPersonID)
          }
        )
      )
    );
  }
  
}