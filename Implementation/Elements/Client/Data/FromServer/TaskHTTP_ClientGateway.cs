using CommonSolution.Gateways;

using ClientAndFrontServer;

using System.Text;
using System.Text.Json;
using ClientAndFrontServer.Transactions.Task;
using CommonSolution.Gateways.Task;
using YamatoDaiwa.CSharpExtensions;
using YamatoDaiwa.CSharpExtensions.Exceptions;


namespace Client.Data.FromServer;


public class TaskHTTP_ClientGateway : TaskGateway
{
  
  private readonly HTTP_Client HTTP_Client = HTTP_Client.getSoleInstance();
  private readonly System.Text.Json.JsonSerializerOptions serializerOptions = new() { PropertyNamingPolicy = null };
  
  
  /* ━━━ Retrieving ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public override async System.Threading.Tasks.Task<TaskGateway.SelectionRetrieving.ResponseData> RetrieveSelection(
    TaskGateway.SelectionRetrieving.RequestParameters requestParameters
  )
  {
    
    HttpResponseMessage response = await this.HTTP_Client.GetAsync(
      URI_Builder.Build(
        new URI_Builder.SourceData
        {
          origin = ClientToFrontServerConnection.ORIGIN,
          path = TasksTransactions.RetrievingOfSelection.URN_PATH,
          queryParameters = new Dictionary<string, object>().
              SetPair(
                TasksTransactions.RetrievingOfSelection.QueryParameters.ForcedFiltering.ProgressStatus.FULL_QUALIFIED_NAME, 
                requestParameters.forcedFiltering.progressStatus
              ).
              SetPairIfValueIsNotNull(
                TasksTransactions.RetrievingOfSelection.QueryParameters.OptionalFiltering.StartingDate.FULL_QUALIFIED_NAME,
                requestParameters.optionalFiltering?.startingDate
              ).
              SetPairIfValueIsNotNull(
                TasksTransactions.RetrievingOfSelection.QueryParameters.OptionalFiltering.EndingDate.FULL_QUALIFIED_NAME, 
                requestParameters.optionalFiltering?.endingDate
              ).
              SetPairIfValueIsNotNull(
                TasksTransactions.RetrievingOfSelection.QueryParameters.OptionalFiltering.
                      SearchingByFullOrPartialTitleOrDescription.FULL_QUALIFIED_NAME, 
                requestParameters.optionalFiltering?.searchingByFullOrPartialTitleOrDescription
              )
        }
      )
    );
    
    if (response.IsSuccessStatusCode)
    {
      return await response.Content.ReadExpectedToBeNonEmptyFromJsonAsync<TaskGateway.SelectionRetrieving.ResponseData>();
    }

    
    throw new DataRetrievingFailedException(
      "Failed to retrieve tasks selection.", 
      response,
      await DataRetrievingFailedException.TryToExtractResponseDataForLogging(response)
    );

  }
  
  
  /* ━━━ Adding ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public override async System.Threading.Tasks.Task<CommonSolution.Entities.Task.Task> Add(
    TaskGateway.Adding.RequestData requestData
  )
  {
    
    HttpResponseMessage response = await this.HTTP_Client.PostAsync(
      URI_Builder.Build(
        new URI_Builder.SourceData
        {
          origin = ClientToFrontServerConnection.ORIGIN,
          path = TasksTransactions.Adding.URN_PATH
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
      return JsonSerializer.Deserialize<CommonSolution.Entities.Task.Task>(
        await response.Content.ReadAsStringAsync(),
        this.serializerOptions
      );
    }
    
    
    throw new DataRetrievingFailedException($"Failed add the new task.\n{ response.ReasonPhrase }");
    
  }
  
  
  /* ━━━ Updating ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public override async System.Threading.Tasks.Task<CommonSolution.Entities.Task.Task> Update(
    Updating.RequestData requestData
  )
  {
    
    HttpResponseMessage response = await this.HTTP_Client.PutAsync(
      URI_Builder.Build(
        new URI_Builder.SourceData
        {
          origin = ClientToFrontServerConnection.ORIGIN,
          path = TasksTransactions.Updating.URN_PATH
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
      return JsonSerializer.Deserialize<CommonSolution.Entities.Task.Task>(
        await response.Content.ReadAsStringAsync(),
        this.serializerOptions
      );
    }
    
    throw new DataRetrievingFailedException(
      $"Failed to update the task with ID \"{ requestData.ID }\".\n{ response.ReasonPhrase }"
    );
    
  }
  
  public override async Task ToggleCompletion(string targetTaskID)
  {
    
    HttpResponseMessage response = await this.HTTP_Client.PatchAsync(
      new Uri(
        URI_Builder.Build(
          new URI_Builder.SourceData
          {
            origin = ClientToFrontServerConnection.ORIGIN,
            path = TasksTransactions.TogglingCompletion.buildURN(targetTaskID)
          }
        )
      ),
      null
    );
    
    if (!response.IsSuccessStatusCode)
    {
      throw new DataRetrievingFailedException(
        $"Failed to update the completion status of task with \"{ targetTaskID }\" new task." +
        response.ReasonPhrase
      );
    }
    
  }

  
  /* ━━━ Delete ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public override async Task Delete(string targetTaskId)
  {
    await this.HTTP_Client.DeleteAsync(
      new Uri(
        URI_Builder.Build(
          new URI_Builder.SourceData
          {
            origin = ClientToFrontServerConnection.ORIGIN,
            path = TasksTransactions.Deleting.buildURN(targetTaskId)
          }
        )
      )
    );
  }
  
}
