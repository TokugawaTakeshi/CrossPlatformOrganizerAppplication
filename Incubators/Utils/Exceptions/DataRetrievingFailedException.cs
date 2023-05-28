namespace Utils.Exceptions;


public class DataRetrievingFailedException : Exception
{
  
  public DataRetrievingFailedException(string? message) : base(message)
  {
  }

  public DataRetrievingFailedException(string? message, Exception? innerException) : base(message, innerException)
  {
  }
  
}