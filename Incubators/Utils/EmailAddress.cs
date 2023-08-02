using System.Text.RegularExpressions;

namespace Utils;


public abstract class EmailAddress
{
  
  /* [ Theory ] https://www.w3resource.com/javascript/form/email-validation.php */
  public static readonly Regex VALID_PATTERN = new(
    @"^\w+(?:[.-]?\w+)*@\w+(?:[.-]?\w+)*(?:\.\w{2,3})+$", 
    RegexOptions.Compiled | RegexOptions.IgnoreCase
  );

  public static bool IsValid(string potentialEmail)
  {
    return EmailAddress.VALID_PATTERN.IsMatch(potentialEmail);
  }
  
}