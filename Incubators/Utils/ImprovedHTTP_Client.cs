namespace Utils;


public class ImprovedHTTP_Client
{

  protected static System.Net.Http.HttpClient? _standardHTTP_ClientInstance = null;

  protected static System.Net.Http.HttpClient standardHTTP_ClientInstance =>
      ImprovedHTTP_Client._standardHTTP_ClientInstance ??
      (ImprovedHTTP_Client._standardHTTP_ClientInstance = new System.Net.Http.HttpClient());

  protected static string? API_SERVER_URI_CONSTANT_PART__WITHOUT_TRAILING_SLASH = null;
  
}