using ClientAndFrontServer;
using ClientAndFrontServer.Transactions.Task;
using CommonSolution.Entities.Task;
using CommonSolution.Gateways.Task;
using YamatoDaiwa.CSharpExtensions;
using YamatoDaiwa.CSharpExtensions.Exceptions;


namespace Client.Data.FromServer;


public class TaskCustomFolderHTTP_ClientGateway : TaskCustomFolderGateway
{
  
  private readonly HTTP_Client HTTP_Client = HTTP_Client.getSoleInstance();
  private readonly System.Text.Json.JsonSerializerOptions serializerOptions = new() { PropertyNamingPolicy = null };
  
  
  public async System.Threading.Tasks.Task<TaskCustomFolder[]> RetrieveTreeOfAll()
  {

    HttpResponseMessage response = await this.HTTP_Client.GetAsync(
      URI_Builder.Build(
        new URI_Builder.SourceData
        {
          origin = ClientToFrontServerConnection.ORIGIN,
          path = TaskCustomFolderTransactions.RetrievingOfTreeOfAll.URN_PATH,
        }
      )
    );
    
    if (response.IsSuccessStatusCode)
    {
      return await response.Content.ReadExpectedToBeNonEmptyFromJsonAsync<TaskCustomFolder[]>();
    }
    
    
    throw new DataRetrievingFailedException(
      "Failed to retrieve tasks custom folders.", 
      response,
      await DataRetrievingFailedException.TryToExtractResponseDataForLogging(response)
    );
    
  }
  
}