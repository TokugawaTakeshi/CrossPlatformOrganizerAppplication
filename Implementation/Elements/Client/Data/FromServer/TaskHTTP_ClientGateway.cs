using CommonSolution.Gateways;

using ClientAndFrontServer;

using System.Text;
using System.Text.Json;
using Utils;
using YamatoDaiwa.CSharpExtensions;
using YamatoDaiwa.CSharpExtensions.Exceptions;


namespace Client.Data.FromServer;


public class TaskHTTP_ClientGateway : TaskGateway
{
  
  private readonly HTTP_Client HTTP_Client = HTTP_Client.getSoleInstance();
  private readonly JsonSerializerOptions serializerOptions = new() { PropertyNamingPolicy = null };
  
  
  /* ━━━ Retrieving ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public override async System.Threading.Tasks.Task<CommonSolution.Entities.Task[]> RetrieveAll()
  {

    HttpResponseMessage response = await this.HTTP_Client.GetAsync(
      new Uri(String.Format(TasksTransactions.RetrievingOfAll.URN_PATH))
    );
    
    if (response.IsSuccessStatusCode)
    {
      return JsonSerializer.Deserialize<CommonSolution.Entities.Task[]>(
        await response.Content.ReadAsStringAsync(), this.serializerOptions
      )!;
    }
    
    
    throw new Exception(response.ReasonPhrase);        
    
  }
  
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
              SetPairIf(
                TasksTransactions.RetrievingOfSelection.QueryParameters.onlyTasksWithAssociatedDateTime, 
                true,
                requestParameters.OnlyTasksWithAssociatedDateTime is true
              ).
              SetPairIf(
                TasksTransactions.RetrievingOfSelection.QueryParameters.onlyTasksWithAssociatedDate, 
                true,
                requestParameters.OnlyTasksWithAssociatedDate is true
              ).
              SetPairIfValueNotIsNull(
                TasksTransactions.RetrievingOfSelection.QueryParameters.searchingByFullOrPartialTitleOrDescription, 
                requestParameters.SearchingByFullOrPartialTitleOrDescription
              )
        }
      )
    );
    
    if (response.IsSuccessStatusCode)
    {
      return JsonSerializer.Deserialize<TaskGateway.SelectionRetrieving.ResponseData>(
        await response.Content.ReadAsStringAsync(),
        this.serializerOptions
      );
    }

    
    throw new DataRetrievingFailedException(
      $"Failed to retrieve tasks selection.\n{ response.ReasonPhrase }"
    );

  }
  
  
  /* ━━━ Adding ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public override async System.Threading.Tasks.Task<CommonSolution.Entities.Task> Add(
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
      return JsonSerializer.Deserialize<CommonSolution.Entities.Task>(
        await response.Content.ReadAsStringAsync(),
        this.serializerOptions
      );
    }
    
    
    throw new DataRetrievingFailedException($"Failed add the new task.\n{ response.ReasonPhrase }");
    
  }
  
  
  /* ━━━ Updating ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public override async System.Threading.Tasks.Task<CommonSolution.Entities.Task> Update(
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
      return JsonSerializer.Deserialize<CommonSolution.Entities.Task>(
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
