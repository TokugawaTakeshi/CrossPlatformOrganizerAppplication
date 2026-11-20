using Fundamentals;

namespace CommonSolution.Entities.AccessControl;


public class User
{
   
  public required string ID { get; init; }


  /* ━━━ Email Address ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public required string emailAddress { get; set; }

  public static class EmailAddress
  {
    public const bool IS_REQUIRED = true;
    public const byte MINIMAL_ONE_BYTE_CHARACTERS_COUNT = Email.MINIMAL_CHARACTERS_COUNT;
    public const ushort MAXIMAL_ONE_BYTE_CHARACTERS_COUNT = Email.MAXIMAL_CHARACTERS_COUNT;
    public static readonly System.Text.RegularExpressions.Regex REGULAR_EXPRESSION = Email.VALID_PATTERN;
  }
  
  
  /* ━━━ Displaying Name ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public required string displayingName { get; set; }

  public static class DisplayingName
  {
    public const bool IS_REQUIRED = true;
    public const byte MINIMAL_ONE_BYTE_CHARACTERS_COUNT = 1;
    public const byte MAXIMAL_ONE_BYTE_CHARACTERS_COUNT = Byte.MaxValue;
  }
  
  
  /* ━━━ Phone Number ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public required string phoneNumber { get; set; }

  public static class PhoneNumber
  {
    public const bool IS_REQUIRED = true;
    public const byte MINIMAL_ONE_BYTE_CHARACTERS_COUNT = 7;
    public const byte MAXIMAL_ONE_BYTE_CHARACTERS_COUNT = Byte.MaxValue;
  }
  
  /* ━━━ Authority Role ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public required AuthorityRoles authorityRole { get; set; }

  public static class AuthorityRole
  {
    public const bool IS_REQUIRED = true;
  }

  public enum AuthorityRoles {
    client,
    administrator
  }
  
  
  /* ━━━ Hashed Password ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public required string hashedPassword { get; set; }

  public static class HashedPassword
  {
    public const bool IS_REQUIRED = true;
    public const byte MINIMAL_ONT_BYTE_CHARACTERS_COUNT = 12;
    public const byte MAXIMAL_ONE_BYTE_CHARACTERS_COUNT = 100;
  }
  
  public static class Password
  {
    
    public const byte MINIMAL_ONT_BYTE_CHARACTERS_COUNT = 16;
    public const byte MAXIMAL_ONE_BYTE_CHARACTERS_COUNT = 32;
    
    public static readonly string[] ALLOWED_NON_WORD_CHARACTERS = [
      "!",
      "@",
      "#",
      "$",
      "^",
      "*",
      "-",
      "_",
      "+",
      "=",
      "{",
      "}",
      "[",
      "]",
      "|",
      "\\",
      "/",
      ":",
      ";",
      "<",
      ">",
      ",",
      ".",
      "?"
    ];
    
  }
  
}