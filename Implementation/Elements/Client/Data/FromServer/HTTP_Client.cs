namespace Client.Data.FromServer;


public class HTTP_Client : HttpClient
{

  private static HTTP_Client? selfSoleInstance = null;

  public static HTTP_Client getSoleInstance()
  {
    return HTTP_Client.selfSoleInstance ?? (HTTP_Client.selfSoleInstance = new HTTP_Client()); 
  }
  
}