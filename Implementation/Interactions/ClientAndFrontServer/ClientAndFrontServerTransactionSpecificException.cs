namespace ClientAndFrontServer;


public class ClientAndFrontServerTransactionSpecificException(
  ClientAndFrontServerTransactionSpecificException.Payload payload
) : 
    Exception
{
  
  public record Payload {
    public required string code { get; init; }
    public required string publicLocalizedErrorMessage { get; init; }
    public required string technicalMessage { get; init; }
  }

  public string code => payload.code;
  public string publicLocalizedErrorMessage => payload.publicLocalizedErrorMessage;
  public string technicalMessage => payload.technicalMessage;
  
}
