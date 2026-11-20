using User = CommonSolution.Entities.AccessControl.User; 

namespace ClientAndFrontServer.Transactions.AccessControl;


public static class AccessControlTransactions
{
  
  public static class SigningIn
  {
    
    public const string HTTP_METHOD = "POST";
    public const string URI_PATH = "/sign_in";
    public const byte MAXIMAL_REQUEST_BODY_SIZE__KILOBYTES = 100;

    public static class RequestData
    {
      
      public static class EmailAddress
      {
        public const bool IS_REQUIRED = true;
        public const byte MINIMAL_ONE_BYTE_CHARACTERS_COUNT = User.EmailAddress.MINIMAL_ONE_BYTE_CHARACTERS_COUNT;
        public const ushort MAXIMAL_ONE_BYTE_CHARACTERS_COUNT = User.EmailAddress.MAXIMAL_ONE_BYTE_CHARACTERS_COUNT;
        public static readonly System.Text.RegularExpressions.Regex REGULAR_EXPRESSION = User.EmailAddress.REGULAR_EXPRESSION;
      }
      
      public static class Password
      {
        public const bool IS_REQUIRED = true;
        public const byte MINIMAL_ONE_BYTE_CHARACTERS_COUNT = User.Password.MINIMAL_ONT_BYTE_CHARACTERS_COUNT;
        public const ushort MAXIMAL_ONE_BYTE_CHARACTERS_COUNT = User.Password.MAXIMAL_ONE_BYTE_CHARACTERS_COUNT;
        public static readonly string[] ALLOWED_NON_WORD_CHARACTERS = User.Password.ALLOWED_NON_WORD_CHARACTERS;
      }
      
    }
    
    public enum SpecificErrorsCodes
    {
      invalidEmailAndPasswordCombination
    }
    
  }
  
  public abstract record Localization(Localization.SigningIn signingIn)
  {
    
    public record SigningIn(SigningIn.SpecificErrors specificErrors)
    {
      
      public record SpecificErrors(string invalidCombinationOfEmailAndPassword);
      
    }
    
  }
  
}